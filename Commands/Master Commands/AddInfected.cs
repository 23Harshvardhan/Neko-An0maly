using System;
using System.IO;

namespace Neko_An0maly.Commands
{
    public class AddInfected : Command
    {
        public AddInfected(string name) : base(name) { }
        public static string infectedPath = @"C:\ProgramData\infected.cfg";

        public override string execute(string[] args)
        {
            if (args.Length == 1)
            {
                if (File.Exists(infectedPath))
                {
                    string nameToAdd = args[0];
                    using (StreamWriter sr = new StreamWriter(infectedPath, append: true))
                    {
                        sr.WriteLine(nameToAdd);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Added to list!");
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
                Console.WriteLine("Invalid arguments for 'addinfected'. Requires 1 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
