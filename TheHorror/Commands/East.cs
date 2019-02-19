using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror.Commands
{
    public class East : BaseCommand
    {
        public override void ExecuteCommand(string command)
        {
            if (Program.CurrentWorld.GetRoom(Program.CurrentRoom.XCoordinate + 1, Program.CurrentRoom.YCoordinate) != null)
            {
                Program.CurrentRoom = Program.CurrentWorld.GetRoom(Program.CurrentRoom.XCoordinate + 1, Program.CurrentRoom.YCoordinate);
                Console.WriteLine("Moving " + command);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move there!");
                Console.ForegroundColor = Program.defaultConsoleTextColor;
            }
        }
    }
}
