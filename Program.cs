using System;
using System.IO;
using System.Text;
using Neko_An0maly.CORE;
using Neko_An0maly.Commands;

namespace Neko_An0maly
{
    internal class Program
    {
        private static CommandHandler ch;
        static string config = @"C:\ProgramData\config.cfg";
        static string infectionList = @"C:\ProgramData\infected.cfg";
        public static string title = @"
    _   __     __            ___          ____                  __     
   / | / /__  / /______     /   |  ____  / __ \____ ___  ____ _/ /_  __
  /  |/ / _ \/ //_/ __ \   / /| | / __ \/ / / / __ `__ \/ __ `/ / / / /
 / /|  /  __/ ,< / /_/ /  / ___ |/ / / / /_/ / / / / / / /_/ / / /_/ / 
/_/ |_/\___/_/|_|\____/  /_/  |_/_/ /_/\____/_/ /_/ /_/\__,_/_/\__, /  
                                                              /____/   
Version " + CoreConfig.version;

        static void Main(string[] args)
        {
            Console.Title = "Neko An0maly Control Panel";

            if (!File.Exists(config))
            {
                using (FileStream fs = File.Create(config))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes("admin\n");
                    fs.Write(line1, 0, line1.Length);
                    Byte[] line2 = new UTF8Encoding(true).GetBytes("root");
                    fs.Write(line2, 0, line2.Length);
                }
            }

            if(!File.Exists(infectionList))
            {
                using(FileStream fs2 = File.Create(infectionList)) { }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;

            ch = new CommandHandler();

            string[] loginToken = File.ReadAllLines(config);

            login:
            Console.Write("Username: ");
            string usr = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            if(loginToken[0] == usr)
            {
                if(loginToken[1] == pass)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome to An0maly Control Panel");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto start;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect credentials!\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto login;
            }

        start:
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(">>> ");
            Console.ForegroundColor = ConsoleColor.White;   
            ch.runCommand(Console.ReadLine());

            goto start;
        }
    }
}