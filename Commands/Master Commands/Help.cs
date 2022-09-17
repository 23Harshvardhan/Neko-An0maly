using System;
namespace Neko_An0maly.Commands
{
    public class Help : Command
    {
        public Help(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Black;   
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("exit - Exit's the application.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("help - Use any command name as argument for detailed description.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ping - Check the victim's status.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("test - Quick debug.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("srsht - Take screenshot of victim's display.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("open - Open a file.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("clear - Clears terminal screen.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("getproclist - Gets a list of processes running on victim's device.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("killproc - Kills a specific process on victim's device.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("startproc - Starts a specific process on victim's device.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("listdir - List's the directory and contents on victim's device.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("delete - Deletes a file or folder on victim's device.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("changecreds - Changes the master login credentials.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("create - Creates a file or folder on victim's device.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("getfile - Gets a file from victim's device.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("infect - Creates a new patient 0 file for new victim.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("sendfile - Send a file from server to victim.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("clouddel - Delete a file from cloud.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("cloudupld - Upload a file to cloud.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("getinfected - Gets the list of infected PCs.");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("addinfected - Adds new infected user name in the list of infected PCs.");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("tree - Gets the tree of victim's desk.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else if(args.Length == 1)
            {
                string command = args[0];
                switch(command)
                {
                    case "exit":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to close An0maly Control Panel. This command does not use any arguments.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "help":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("This command shows all the commands that can be used. Use any command as an argument for detailed description.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "ping":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("This command can be used to check if the victim's device is online or offline for further attacks. Use victim's name as argument." +
                            " (Try using this command at least twice before to any conclusions!)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "test":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("This command takes victim's name as argument and creates a test file in victim's device for quick checking. (Does not return any " +
                            "response on the An0maly console!)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "srsht":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to take a screenshot of the victim's screen. Use victim's name as argument. (This command is currently not " +
                            "working and is under work in progress!)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "open":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to open file. (This command is currently not working and is under work in progress!)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "clear":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to clear the screen of the An0maly terminal. (Note: An0maly logo will not be removed and will be printed again!)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "getproclist":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to get a list of all the running process on victim's device. Use victim's name as argument.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "killproc":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to kill any running process on victim's device. Use victim's name as argument 1 and process name as argument 2.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "startproc":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to start or open file on victim's device. Use victim's name as argument 1 and file path as argument 2. (" +
                            "This command is currently not working and is under work in progress!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "listdir":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to get a list of directories on victim's device. Use victim's name as argument 1 and parent path as argument 2.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "delete":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to delete any file on victim's device. Use victim's name as argument 1, type(file/folder) as argument 2 and path " +
                            "to the file to delete as argument 3");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "create":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to create any file on victim's device. Use victim's name as argument 1 and path to the file to create as argument 2");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "changecreds":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to enter your old username and password to change to a new one.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "getfile":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to get any file from victim's device. Use victim's name as argument 1 and path to the file to get as argument 2. " +
                            "(Note: Use this command at least twice before coming to any conclusions. Downloaded file is located in ProgramData.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "infect":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Use this command to create a new patient 0 file to infect new targets. Uses new victim's name as argument 1. (Note: " +
                            "This command is currently not working as intended and in under development!)");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "sendfile":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Send a file from server to victim. Use victim's name as argument 1, file to send as argument 2 and download location on victim's " +
                            "device as argument 3.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "clouddel":
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.WriteLine("Deletes a file from the cloud if exists. Use the file to delete(including extension) as argument 1 and extension type(without " +
                            "period) as argument 2.");
                        break;
                    case "cloudupld":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Uploads a file to the cloud from server. Use the path of the file to upload as argument 1.");
                        break;
                    case "getinfected":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Gets the list of infected PCs which can be added or removed manually. Uses 0 argument(s).");
                        break;
                    case "addinfected":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Adds to the list of infected PCs. Use the name of the victim as argument 1.");
                        break;
                    case "tree":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Get's the tree of victim' disk. Use the name of the victim as argument 1.");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Command '" + args[0] + "' does not exist!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'help'. Requires either 0 argument(s) or 1 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }
    }
}
