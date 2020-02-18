using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    // Create list that holds all the items in the world, call factory for item when 'created' in the world
    // Static class has no constructor because it never gets constructed
    // But first time can call to load up game items
    public static class ItemFactory
    {
        // You can only set readonly item once
        private static readonly List<GameItem> _standardGameItems;

        // This function is run the first time it is called (aka when game is first loaded)
        static ItemFactory() 
        {
            // Initialize new empty list, if not the _standardGameItems is null
            _standardGameItems = new List<GameItem>();
            _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
            _standardGameItems.Add(new GameItem(9001, "Snake fang", 1));
            _standardGameItems.Add(new GameItem(9002, "Snakeskin", 2));
            _standardGameItems.Add(new GameItem(9003, "Rat tail", 1));
            _standardGameItems.Add(new GameItem(9004, "Rat fur", 2));
            _standardGameItems.Add(new GameItem(9005, "Spider fang", 1));
            _standardGameItems.Add(new GameItem(9006, "Spider silk", 2));
        }

        // Returns a GameItem object with the itemTypeID, use LINQ to query list to find the item
        public static GameItem CreateGameItem(int itemTypeID)
        {
            // Use LINQ to find first item that has the ItemTypeID property matching itemTypeID
            // If cannot find, will return the default value which is null
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();
                }
                return standardItem.Clone();
            }
            return null;
        }
    }
}
