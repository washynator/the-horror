using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror.Commands
{
    public class Prompt : BaseCommand
    {
        public static string CurrentPrompt = ">> ";

        public override void ExecuteCommand(string command)
        {
            Console.WriteLine("Your current prompt is: " + CurrentPrompt);
            Console.Write("Now you can input any kind of prompt you would like (space will not be added): ");
            CurrentPrompt = Console.ReadLine();
        }
    }
}
