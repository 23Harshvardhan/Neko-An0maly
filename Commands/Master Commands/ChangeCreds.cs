using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko_An0maly.Commands
{
    public class ChangeCreds : Command
    {
        public ChangeCreds(string name) : base(name) { }
        static string config = @"C:\ProgramData\config.cfg";

        public override string execute(string[] args)
        {
            if (args.Length == 0)
            {
                string usr;
                string pass;
                string newUsr;
                string newUsrConfirm;
                string newPass;
                string newPassConfirm;

                Console.Write("Old Username: ");
                usr = Console.ReadLine();
                Console.Write("Old Password: ");
                pass = Console.ReadLine();

                string[] loginToken = File.ReadAllLines(config);

                if (loginToken[0] == usr)
                {
                    if (loginToken[1] == pass)
                    {
                        Console.Write("New Username: ");
                        newUsr = Console.ReadLine();
                        Console.Write("Confirm New Username: ");
                        newUsrConfirm = Console.ReadLine();

                        if (newUsr == newUsrConfirm)
                        {
                            Console.Write("New Password: ");
                            newPass = Console.ReadLine();
                            Console.Write("Confirm New Password: ");
                            newPassConfirm = Console.ReadLine();

                            if (newPass == newPassConfirm)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Master credentials have been changed successfully!");
                                Console.ForegroundColor = ConsoleColor.White;

                                using (StreamWriter sr = new StreamWriter(config))
                                {
                                    sr.Write(newUsrConfirm);
                                    sr.Write("\n" + newPassConfirm);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("New passwords don't match.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("New usernames don't match.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("incorrect credentials!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'changecreds'.Requires 0 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
