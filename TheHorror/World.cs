using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHorror
{
    public class World
    {
        List<Room> rooms = new List<Room>();

        public void GenerateWorld()
        {
            AddRoom("Home", "This is your home", 0, 0);
            AddRoom("North corridor", "This is a test room", 0, 1);
            AddRoom("East corridor", "Still just testing", 1, 0);
            AddRoom("Northeast corridor", "Yes, we are just testing", 1, 1);
        }

        public void AddRoom(string name, string description, int xCoordinate, int yCoordinate)
        {
            Room room = new Room
            {
                Name = name,
                Description = description,
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            };

            rooms.Add(room);
        }

        public Room GetRoom(int xCoordinate, int yCoordinate)
        {
            foreach(Room room in rooms)
            {
                if (room.XCoordinate == xCoordinate && room.YCoordinate == yCoordinate)
                {
                    return room;
                }
            }

            return null;
        }
    }
}
