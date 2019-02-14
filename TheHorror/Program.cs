using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheHorror
{

    public static class KeyWords
    {
        public static string[] keyWords = { "quit", "north", "east", "south", "west" };
    }

    class Program
    {
        static string Prompt = ">> ";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to THE HORROR!");
            Console.Write("Please enter your name, before entering the house of horrors: ");
            string name = Console.ReadLine();

            Console.WriteLine("Okay, " + name + " we are happy to have you here. I'm sure you won't be so happy. BWAHAHAHAHA!");

            do
            {
                Console.WriteLine(Prompt + GetInput(Console.ReadLine()));
            } while (GetInput(Console.ReadLine()) != KeyWords.keyWords[0]);

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
                        case "north":
                            Console.WriteLine("Moving north");
                            break;
                        case "east":
                            Console.WriteLine("Moving east");
                            break;
                        case "south":
                            Console.WriteLine("Moving south");
                            break;
                        case "west":
                            Console.WriteLine("Moving west");
                            break;
                        case "quit":
                            Console.WriteLine("Quitting.....");
                            break;
                        default:
                            break;
                    }
                    return command[i];
                }
            }
            return Prompt;
        }
    }
}
