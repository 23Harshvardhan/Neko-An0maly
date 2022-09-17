using System;
using System.Diagnostics;

namespace Neko_An0maly.Commands
{
    public class Exit : Command
    {
        public Exit(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 0)
            {
                Environment.Exit(0);

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'exit'. Requires 0 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
