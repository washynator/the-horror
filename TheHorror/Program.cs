using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheHorror
{
    class Program
    {
        static string PlayerPrompt = ">> ";
        static string PlayerName = "";
        static Location CurrentLocation;

        static void Main(string[] args)
        {
            StartGame();

            do
            {
                PrintExits();
                PrintPrompt();
            } while (GetInput(Console.ReadLine()) != KeyWords.keyWords[0]);
        }

        static void StartGame()
        {
            Console.WriteLine("Welcome to THE HORROR!");
            Console.Write("Please enter your name, before entering the house of horrors: ");
            PlayerName = Console.ReadLine();
            Console.WriteLine("Okay, " + PlayerName + " we are happy to have you here. I'm sure you won't be so happy. BWAHAHAHAHA!");
            World.GenerateWorld();
            CurrentLocation = World.home;
        }

        static void PrintPrompt()
        {
            Console.WriteLine(CurrentLocation.Name);
            Console.WriteLine(CurrentLocation.Description);
            Console.Write(PlayerPrompt);
        }

        static void PrintExits()
        {
            /*foreach(string exit in TestRoom.Exits)
            {
                Console.Write("(" + exit + ") ");
            }*/
        }

        static void EditPrompt()
        {
            Console.Write("Now you can input any kind of prompt you would like (space will not be added): ");
            PlayerPrompt = Console.ReadLine();
        }

        static void HandleMovement(string direction)
        {
            switch(direction)
            {
                case "north":
                    if (World.GetLocation(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null)
                    {
                        CurrentLocation.YCoordinate += 1;
                        //CurrentLocation = World.GetLocation(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);
                        Console.WriteLine("Moving north");
                    }
                    else
                    {
                        Console.WriteLine("Cannot move there!");
                    }
                    
                    break;
            }
        }

        public static string GetInput(string playerInput)
        {
            playerInput = playerInput.ToLower();
            string formattedPlayerInput = Regex.Replace(playerInput, " {2,}", " ");

            string[] command = formattedPlayerInput.Split(' ');

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
                            HandleMovement("north");
                            break;
                        case "east":
                            HandleMovement("east");
                            break;
                        case "south":
                            HandleMovement("south");
                            break;
                        case "west":
                            HandleMovement("west");
                            break;
                        case "prompt":
                            Console.WriteLine("Your current prompt is: " + PlayerPrompt);
                            EditPrompt();
                            break;
                        default:
                            break;
                    }
                    return command[i];
                }
            }
            return PlayerPrompt;
        }
    }
}
