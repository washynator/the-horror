using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror
{
    public static class World
    {
        //List<Room> Rooms = new List<Room>();
        public static List<Location> locations = new List<Location>();
        public static Location home = null;
        public static Location testRoom = null;

        public static void GenerateWorld()
        {
            home = new Location("Home", "This is your home", 0, 0);
            testRoom = new Location("Test room", "This is a test room", 0, 1);
            locations.Add(home);
            locations.Add(testRoom);
        }

        public static Location GetLocation(int xCoordinate, int yCoordinate)
        {
            foreach(Location location in locations)
            {
                if (location.XCoordinate == xCoordinate && location.YCoordinate == yCoordinate)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
