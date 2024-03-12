using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    public class Library
    {
        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public void RegisterCommand(string name, ICommand command)
        {
            commands[name] = command;
        }

        public void RunCommand(string name)
        {
            if (commands.TryGetValue(name, out var command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }
    }
}
