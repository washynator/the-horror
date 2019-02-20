using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror.Commands
{
    class Look : BaseCommand
    {
        public override void ExecuteCommand(string command)
        {
            //todo: make this work
            if (command == "at" || command == "a")
            {
                Console.WriteLine("Look at what ?");
            }
            else
            {
                Console.WriteLine(Program.CurrentRoom.Description);
            }
        }
    }
}
