using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror.Commands
{
    public class North : BaseCommand
    {
        private InputManager _inputManager;

        public North(InputManager inputManager)
        {
            _inputManager = inputManager;
            _inputManager.Input += (object sender, InputManagerEventArgs args) =>
            {
                // todo: add correct else-clause to handle invalid input, get the command-files and go from there
                if (args.Command == "north")
                {
                    Console.WriteLine("North is here, yay! ");
                }
            };
        }

        public override void ExecuteCommand(string command)
        {
            if (Game.CurrentWorld.GetRoom(Game.CurrentRoom.XCoordinate, Game.CurrentRoom.YCoordinate + 1) != null)
            {
                Game.CurrentRoom = Game.CurrentWorld.GetRoom(Game.CurrentRoom.XCoordinate, Game.CurrentRoom.YCoordinate + 1);
                Console.WriteLine("Moving " + command);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move there!");
                Console.ForegroundColor = Game.defaultConsoleTextColor;
            }
        }
    }
}
