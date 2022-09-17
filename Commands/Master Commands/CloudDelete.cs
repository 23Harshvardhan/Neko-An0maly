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
    public class CloudDelete : Command
    {
        public static string path = @"C:\ProgramData\";
        public static string filetodel;
        public static string ext;
        public CloudDelete(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 2)
            {
                filetodel = args[0];
                ext = args[1];
                TransferProtocol.delete(filetodel , ext);

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'clouddel'. Requires 2 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
