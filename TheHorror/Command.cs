using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheHorror
{
    public static class Command
    {
        private static string _currentDirectory = Directory.GetCurrentDirectory();

        public static string[] GetCommands()
        {
            return Directory.GetFiles(_currentDirectory).ToArray();
        }
    }
}
