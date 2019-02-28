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
        Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

        /*void CreateExit()
        {
            Exit exit = new Exit();
            exit.KeyString = "north";
            exit.ExitDescription = "You walk north.";
            exit.ValueRoom = rooms[1];
        }*/

        public void GenerateWorld()
        {
            AddRoom("Home", "This is your home", null, 0, 0);
            AddRoom("North corridor", "This is a test room", null, 0, 1);
            //AddRoom("East corridor", "Still just testing", 1, 0);
            //AddRoom("Northeast corridor", "Yes, we are just testing", 1, 1);
        }

        public void AddRoom(string name, string description, Exit[] exits, int xCoordinate, int yCoordinate)
        {
            Room room = new Room
            {
                Name = name,
                Description = description,
                Exits = exits,
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
