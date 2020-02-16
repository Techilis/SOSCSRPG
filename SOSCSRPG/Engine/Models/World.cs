using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        // Create private _locations variable to store a list of locations, right side to instantiate new list
        // Without new List<Location>, there will be no empty list for _locations
        private List<Location> _locations = new List<Location>();

        // Create function to add locations to list
        // void means that function will not return anything
        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            // Create new location object and then set properties
            Location loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imageName;

            _locations.Add(loc);

        }

        // Function to check if there is a location at the given coordinates, return loc or null
        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach(Location loc in _locations)
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    return loc;
                }
            }
            return null;
        }
    }
}
