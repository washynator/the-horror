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
                // todo: fix this so it doesn't respond to other valid commands
                if (args.Command == "north")
                {
                    Console.WriteLine("North is here, yay! ");
                }
                else
                {
                    Console.WriteLine("What?");
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
