using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        // Property currentPlayer takes in a player class as an object
        public Player CurrentPlayer { get; set; }

        // This is a constructor to create the GameSession object
        public GameSession()
        {
            // This creates a new Player object and set to CurrentPlay when GameSession is ran
            CurrentPlayer = new Player();
            // Need to set Player class and properties to public
            CurrentPlayer.Name = "Scott";
            CurrentPlayer.CharacterClass = "Fighter";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.Gold = 1000000;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
        }
    }
}
