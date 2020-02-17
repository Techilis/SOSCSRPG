using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    // BaseNotificationClass is the parent and GameSession is the child who inherits the function and event capabilities
    public class GameSession : BaseNotificationClass
    {
        // Have current location raised as INotifyPropertyChanged, creating backing variable and raise whenever value changes
        private Location _currentLocation;
        private Monster _currentMonster;

        public World CurrentWorld { get; set; }
        // Property currentPlayer takes in a player class as an object
        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set 
            { 
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToSouth));

                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
            }
        }

        private void GetMonsterAtLocation()
        {
            // From function at Location.cs
            CurrentMonster = CurrentLocation.GetMonster();
        }

        public bool HasMonster => CurrentMonster != null;

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;

                // Notify UI if CurrentMonster or HasMonster property has changed
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
            }
        }

        // Check for possible locations to NSEW of current location
        public bool HasLocationToNorth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null; }
        }
        public bool HasLocationToWest
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null; }
        }
        public bool HasLocationToEast
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null; }
        }
        public bool HasLocationToSouth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null; }
        }
        // This is a constructor to create the GameSession object
        public GameSession()
        {
            // This creates a new Player object and set to CurrentPlayer when GameSession is ran
            CurrentPlayer = new Player
            {
                // Need to set Player class and properties to public
                Name = "Gaston",
                CharacterClass = "Fighter",
                HitPoints = 10,
                Gold = 1000000,
                ExperiencePoints = 0,
                Level = 1
            };

            // Player is an instance class but WorldFactory should be a static class (aka global)
            CurrentWorld = WorldFactory.CreateWorld();


            /* If WorldFactory is not static, have to type the following:
             * 
                // Instantiate a WorldFactory object and store in factory variable
                WorldFactory factory = new WorldFactory();
                // Call CreateWorld function to create World object to store in CurrentWorld variable
                CurrentWorld = factory.CreateWorld();
            */

            // Set current location
            CurrentLocation = CurrentWorld.LocationAt(0, -1);

        }

        // Set public because GameSession class is in Engine project but WPFUI Project needs to call it
        public void MoveNorth() 
        {
            // Guard
            if (HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }
        public void MoveWest()
        {
            if (HasLocationToWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }
        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
        }
        public void MoveSouth()
        {
            if (HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
            
        }

        private void GivePlayerQuestsAtLocation()
        {
            foreach(Quest quest in CurrentLocation.QuestAvailableHere)
            {
                // Assign quest if CurrentPlayer does not have a quest matching the quest at location
                if(!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }
    }
}
