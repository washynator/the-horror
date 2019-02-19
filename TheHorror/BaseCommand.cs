using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror
{
    public abstract class BaseCommand
    {
        public abstract void ExecuteCommand(string command);
    }
}
