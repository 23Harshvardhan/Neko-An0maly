using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neko_An0maly.CORE;

namespace Neko_An0maly.Commands
{
    public class Clear : Command
    {
        public Clear(string name): base(name) { }
        public static string title = @"
    _   __     __            ___          ____                  __     
   / | / /__  / /______     /   |  ____  / __ \____ ___  ____ _/ /_  __
  /  |/ / _ \/ //_/ __ \   / /| | / __ \/ / / / __ `__ \/ __ `/ / / / /
 / /|  /  __/ ,< / /_/ /  / ___ |/ / / / /_/ / / / / / / /_/ / / /_/ / 
/_/ |_/\___/_/|_|\____/  /_/  |_/_/ /_/\____/_/ /_/ /_/\__,_/_/\__, /  
                                                              /____/   
Version " +  CoreConfig.version;

        public override string execute(string[] args)
        {
            if(args.Length == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'clear'.Requires 0 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
