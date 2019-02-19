using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheHorror
{
    class Program
    {
        public static Program CurrentSession = new Program();
        public static Player CurrentPlayer = new Player();
        public static World CurrentWorld = new World();
        public static Room CurrentRoom = new Room();
        public static Commands.North North = new Commands.North();
        public static Commands.South South= new Commands.South();
        public static Commands.East East = new Commands.East();
        public static Commands.West West = new Commands.West();

        public static readonly ConsoleColor defaultConsoleTextColor = ConsoleColor.Gray;
        public string PlayerPrompt = ">> ";

        static void Main(string[] args)
        {
            CurrentSession.StartGame();

            do
            {
                CurrentSession.PrintExits();
                CurrentSession.PrintPrompt();
            } while (CurrentSession.GetInput(Console.ReadLine()) != KeyWords.keyWords[0]);
        }

        void StartGame()
        {
            Console.WriteLine("Welcome to THE HORROR!");
            Console.Write("Please enter your name, before entering the house of horrors: ");
            CurrentPlayer.Name = Console.ReadLine();
            Console.WriteLine("Okay, " + CurrentPlayer.Name + " we are happy to have you here. I'm sure you won't be so happy. BWAHAHAHAHA!");
            CurrentWorld.GenerateWorld();
            CurrentRoom = CurrentWorld.GetRoom(0, 0);
        }

        void PrintPrompt()
        {
            Console.WriteLine(CurrentRoom.Name);
            Console.Write(PlayerPrompt);
        }

        void PrintExits()
        {
            string exitPrompt = "(";

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1) != null)
            {
                exitPrompt += " north ";
            }

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate) != null)
            {
                exitPrompt += " east ";
            }

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1) != null)
            {
                exitPrompt += " south ";
            }

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate) != null)
            {
                exitPrompt += " west ";
            }

            Console.Write(exitPrompt + ") ");

        }

        void EditPrompt()
        {
            Console.Write("Now you can input any kind of prompt you would like (space will not be added): ");
            PlayerPrompt = Console.ReadLine();
        }

        public string GetInput(string playerInput)
        {
            playerInput = playerInput.ToLower();
            string formattedPlayerInput = Regex.Replace(playerInput, " {2,}", " ");

            string[] command = formattedPlayerInput.Split(' ');

            //North.ExecuteCommand(command[0]);

            for (int i = 0; i < command.Length; i++)
            {
                for (int j = 0; j < KeyWords.keyWords.Length; j++)
                {
                    switch (command[i])
                    {
                        case "quit":
                            return "quit";
                        case "exit":
                            return "quit";
                        case "north":
                            North.ExecuteCommand(command[i]);
                            break;
                        case "east":
                            East.ExecuteCommand(command[i]);
                            break;
                        case "south":
                            South.ExecuteCommand(command[i]);
                            break;
                        case "west":
                            West.ExecuteCommand(command[i]);
                            break;
                        case "prompt":
                            Console.WriteLine("Your current prompt is: " + PlayerPrompt);
                            EditPrompt();
                            break;
                        case "look":
                            Console.WriteLine(CurrentRoom.Description);
                            break;
                        default:
                            break;
                    }
                    return command[i];
                }
            }
            return PlayerPrompt;
        }

        #region MovementMethods
        void MoveNorth()
        {
            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1) != null)
            {
                CurrentRoom = CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1);
                Console.WriteLine("Moving north");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move there!");
                Console.ForegroundColor = defaultConsoleTextColor;
            }
        }

        void MoveEast()
        {
            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate) != null)
            {
                CurrentRoom = CurrentWorld.GetRoom(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate);
                Console.WriteLine("Moving east");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move there!");
                Console.ForegroundColor = defaultConsoleTextColor;
            }
        }

        void MoveSouth()
        {
            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1) != null)
            {
                CurrentRoom = CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1);
                Console.WriteLine("Moving south");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move there!");
                Console.ForegroundColor = defaultConsoleTextColor;
            }
        }

        void MoveWest()
        {
            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate) != null)
            {
                CurrentRoom = CurrentWorld.GetRoom(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate);
                Console.WriteLine("Moving west");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot move there!");
                Console.ForegroundColor = defaultConsoleTextColor;
            }
        }
        #endregion
    }
}
