using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheHorror
{
    public class Room
    {
        public List<string> Exits = new List<string>();
    }

    class Program
    {
        static string PlayerPrompt = ">> ";
        static string PlayerName = "";
        static Room TestRoom = new Room();

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
            TestRoom.Exits.Add("north");
            TestRoom.Exits.Add("west");

            Console.WriteLine("Welcome to THE HORROR!");
            Console.Write("Please enter your name, before entering the house of horrors: ");
            PlayerName = Console.ReadLine();
            Console.WriteLine("Okay, " + PlayerName + " we are happy to have you here. I'm sure you won't be so happy. BWAHAHAHAHA!");
        }

        static void PrintPrompt()
        {
            Console.Write(PlayerPrompt);
        }

        static void PrintExits()
        {
            foreach(string exit in TestRoom.Exits)
            {
                Console.Write("(" + exit + ") ");
            }
        }

        static void EditPrompt()
        {
            Console.Write("Now you can input any kind of prompt you would like (space will not be added): ");
            PlayerPrompt = Console.ReadLine();
        }

        static bool CheckExits(string direction)
        {
            return TestRoom.Exits.Contains(direction);
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
                            if (CheckExits("north"))
                            {
                                Console.WriteLine("Moving north");
                            }
                            else
                            {
                                Console.WriteLine("That way is blocked");
                            }
                            break;
                        case "east":
                            if (CheckExits("east"))
                            {
                                Console.WriteLine("Moving east");
                            }
                            else
                            {
                                Console.WriteLine("That way is blocked");
                            }
                            break;
                        case "south":
                            if (CheckExits("south"))
                            {
                                Console.WriteLine("Moving south");
                            }
                            else
                            {
                                Console.WriteLine("That way is blocked");
                            }
                            break;
                        case "west":
                            if (CheckExits("west"))
                            {
                                Console.WriteLine("Moving west");
                            }
                            else
                            {
                                Console.WriteLine("That way is blocked");
                            }
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
