using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands
{
    public class QuitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Quiting the application");
            Environment.Exit(0);
        }

        public string GetDescription()
        {
            return "Quit";
        }
    }
}
