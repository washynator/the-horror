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
        public static Commands.Prompt PlayerPrompt = new Commands.Prompt();
        public static Commands.Look Look = new Commands.Look();
        public static Commands.Echo Echo = new Commands.Echo();
        public static readonly ConsoleColor defaultConsoleTextColor = ConsoleColor.Gray;

        public static bool EchoState = true;

        static void Main(string[] args)
        {
            CurrentSession.StartGame();

            do
            {
                Console.Write(CurrentRoom.Name);
                Console.Write(CurrentSession.PrintExits());
                Console.Write(Commands.Prompt.CurrentPrompt);
                } while (CurrentSession.GetInput(Console.ReadLine()) != "quit");
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

        string PrintExits()
        {
            string exitPrompt = " (";

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

            return exitPrompt + ")\n";

        }

        public string GetInput(string playerInput)
        {
            playerInput = playerInput.ToLower();
            // Removes extra spaces
            string formattedPlayerInput = Regex.Replace(playerInput, " {2,}", " ");

            string[] input = formattedPlayerInput.Split(' ');

            foreach (string command in input)
            {
                if (EchoState == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(command);
                    Console.ForegroundColor = defaultConsoleTextColor;
                }
                
                switch (command)
                {
                    case "north":
                    case "n":
                        North.ExecuteCommand(command);
                        break;
                    case "east":
                    case "e":
                        East.ExecuteCommand(command);
                        break;
                    case "south":
                    case "s":
                        South.ExecuteCommand(command);
                        break;
                    case "west":
                    case "w":
                        West.ExecuteCommand(command);
                        break;
                    case "prompt":
                        PlayerPrompt.ExecuteCommand(command);
                        break;
                    case "echo":
                        // todo: don't do this
                        if (input.Length - 1 > 0)
                        {
                            Echo.ExecuteCommand(input[1]);
                        }
                        else
                        {
                            Echo.ExecuteCommand(command);
                        }
                        break;
                    case "look":
                    case "l":
                        // todo: don't do this
                        if (input.Length - 1 > 0)
                        {
                            Look.ExecuteCommand(input[1]);
                        }
                        else
                        {
                            Look.ExecuteCommand(command);
                        }
                        break;
                    default:
                        break;
                }
                
                return command;
            }
            return Commands.Prompt.CurrentPrompt;
        }
    }
}
