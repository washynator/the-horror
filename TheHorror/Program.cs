using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheHorror
{
    class Program
    {
        public static Program CurrentSession = new Program();
        public static InputManager inputManager = new InputManager();
        public Player CurrentPlayer = new Player();
        public static World CurrentWorld = new World();
        public static Room CurrentRoom = new Room();

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
                } while (inputManager.GetInput(Console.ReadLine()) != "quit");
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
