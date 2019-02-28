using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror.Commands
{
    public class Echo : BaseCommand
    {
        public override void ExecuteCommand(string command)
        {
            if (command == "on")
            {
                Game.EchoState = true;
            }
            if (command == "off")
            {
                Game.EchoState = false;
            }
        }
    }
}
