using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheHorror
{
    public delegate void InputEventHandler(object sender, InputManagerEventArgs args);

    public class InputManager
    {
        public event InputEventHandler Input;

        public Commands.Prompt PlayerPrompt = new Commands.Prompt();
        public Commands.Look Look = new Commands.Look();
        public Commands.Echo Echo = new Commands.Echo();

        public string GetInput(string playerInput)
        {
            if (Game.EchoState == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(playerInput);
                Console.ForegroundColor = Game.defaultConsoleTextColor;
            }

            playerInput = playerInput.ToLower();
            // Removes extra spaces
            string formattedPlayerInput = Regex.Replace(playerInput, " {2,}", " ");

            string[] input = formattedPlayerInput.Split(' ');

            if (Input != null)
            {
                

                Input(this, new InputManagerEventArgs { Command = input[0] });
            }
            else
            {
                Console.WriteLine("Input() is null, please fix me!");
            }
            

            /*foreach (string command in input)
            {
                if (Game.EchoState == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(command);
                    Console.ForegroundColor = Game.defaultConsoleTextColor;
                }

                switch (command)
                {
                    case "north":
                    case "n":
                        //North.ExecuteCommand(command);
                        
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
                        // todo: use events
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
                        // todo: use events
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
            }*/
            return Commands.Prompt.CurrentPrompt;
        }
    }
}
