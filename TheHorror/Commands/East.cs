﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror.Commands
{
    public class East : BaseCommand
    {
        private InputManager _inputManager;

        public East(InputManager inputManager)
        {
            _inputManager = inputManager;
            _inputManager.Input += (object sender, InputManagerEventArgs args) =>
            {
                // todo: add correct else-clause to handle invalid input, get the command-files and go from there
                if (args.Command == "east")
                {
                    ExecuteCommand(args.Command);
                }
            };
        }

        public override void ExecuteCommand(string command)
        {
            if (Game.CurrentWorld.GetRoom(Game.CurrentRoom.XCoordinate + 1, Game.CurrentRoom.YCoordinate) != null)
            {
                Game.CurrentRoom = Game.CurrentWorld.GetRoom(Game.CurrentRoom.XCoordinate + 1, Game.CurrentRoom.YCoordinate);
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
