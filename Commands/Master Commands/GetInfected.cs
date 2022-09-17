using System;
using System.IO;

namespace Neko_An0maly.Commands
{
    public class GetInfected : Command
    {
        public GetInfected(string name) : base(name) { }
        public static string infectedPath = @"C:\ProgramData\infected.cfg";

        public override string execute(string[] args)
        {
            if (args.Length == 0)
            {
                if(File.Exists(infectedPath))
                {
                    string[] names = File.ReadAllLines(infectedPath);
                    Console.WriteLine("");
                    foreach(string name in names)
                    {
                        Console.WriteLine(name);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Terminating list!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File does not exist! Restart application to create file automatically.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'getinfected'. Requires either 0 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
