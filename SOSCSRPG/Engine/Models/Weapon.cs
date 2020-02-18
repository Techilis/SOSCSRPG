using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {   
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        // Passes in the itemTypeID, name and price when Weapon class is instantiated, these values are sent to the base class which is GameItem
        public Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage)
            : base(itemTypeID, name,price, true)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;  
        }

        // Clone function to return the item from _standardGameItem list in ItemFactory.cs
        // Take in property values and instantiate a new Weapon object
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}
