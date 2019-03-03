using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheHorror
{
    public static class Game
    {
        public static Player CurrentPlayer = new Player();
        public static World CurrentWorld = new World();
        public static Room CurrentRoom = new Room();

        public static readonly ConsoleColor defaultConsoleTextColor = ConsoleColor.Gray;

        public static bool EchoState = true;

        static void Main(string[] args)
        {
            var inputManager = GetReferences();
            PrintStartGame();
            
            do
            {
                Console.Write(CurrentRoom.Name);
                Console.Write(PrintExits());
                Console.Write(Commands.Prompt.CurrentPrompt);
                } while (inputManager.GetInput(Console.ReadLine()) != "quit");
        }

        static void PrintStartGame()
        {
            Console.WriteLine("Welcome to THE HORROR!");
            Console.Write("Please enter your name, before entering the house of horrors: ");
            CurrentPlayer.Name = Console.ReadLine();
            Console.WriteLine("Okay, " + CurrentPlayer.Name + " we are happy to have you here. I'm sure you won't be so happy. BWAHAHAHAHA!");
            CurrentWorld.GenerateWorld();
            CurrentRoom = CurrentWorld.GetRoom(0, 0);
        }

        static InputManager GetReferences()
        {
            var inputManager = new InputManager();
            var north = new Commands.North(inputManager);
            var south = new Commands.South(inputManager);
            var east = new Commands.East(inputManager);
            var west = new Commands.West(inputManager);

            return inputManager;
        }

        static string PrintExits()
        {
            //todo: fix this
            string exitPrompt = " (";

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1) != null)
            {
                exitPrompt += "n, ";
            }

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate) != null)
            {
                exitPrompt += "e, ";
            }

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1) != null)
            {
                exitPrompt += "s, ";
            }

            if (CurrentWorld.GetRoom(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate) != null)
            {
                exitPrompt += "w";
            }

            return exitPrompt + ")\n";
        }

        
    }
}
