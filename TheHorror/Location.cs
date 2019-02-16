using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Location(string name, string description, int xCoordinate, int yCoordinate)
        {
            Name = name;
            Description = description;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
