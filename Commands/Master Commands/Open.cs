using System;
using System.IO;
using System.Diagnostics;

namespace Neko_An0maly.Commands
{
    public class Open : Command
    {
        public Open(string name): base(name) { }

        public override string execute(string[] args)
        {
            if(args.Length == 1)
            {
                string command = args[0];
                 
                switch (command)
                {
                    case "root":
                        Console.WriteLine("Opening root directory.");
                        Process.Start(@"C:\ProgramData\");
                        break;
                    case "srsht":
                        Console.WriteLine("Opening screenshot.");
                        Process.Start(@"C:\ProgramData\ss.png");
                        break;
                    case "desk":
                        Console.WriteLine("Opening desktop.");
                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                        break;
                    case "tree":
                        Console.WriteLine("Opening latest received tree of victim's disk.");
                        Process.Start(@"C:\ProgramData\tree.txt");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid argument for open!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'open'.Requires 1 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
