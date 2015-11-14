// This is where you build your AI for the Anarchy game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// you can add addtional using(s) here

namespace Joueur.cs.Games.Anarchy
{
    class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself, it contains all the information about the current game
        /// </summary>
        public readonly Anarchy.Game Game;
        /// <summary>
        /// This is your AI's player. This AI class is not a player, but it should command this Player.
        /// </summary>
        public readonly Anarchy.Player Player;
        #pragma warning restore 0169
        #pragma warning restore 0649

        // you can add additional properties here for your AI to use
        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>string of you AI's name.</returns>
        public override string GetName()
        {
            return "Anarchy C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game object and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI, or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
            base.GameUpdated();
        }

        /// <summary>
        /// This is automatically called when the game ends.
        /// </summary>
        /// <remarks>
        /// You can do any cleanup of you AI here, or do custom logging. After this function returns the application will close.
        /// </remarks>
        /// <param name="won">true if your player won, false otherwise</param>
        /// <param name="reason">a string explaining why you won or lost</param>
        public override void Ended(bool won, string reason)
        {
            base.Ended(won, reason);
        }


        /// <summary>
        /// This is called every time the AI is asked to respond with a command during their turn
        /// </summary>
        /// <returns>represents if you want to end your turn. true means end the turn, false means to keep your turn going and re-call runTurn()</returns>
        public bool RunTurn()
        {
            // Put your game logic here for runTurn

            // Get my first warehouse
            Warehouse warehouse = Player.Warehouses[0];
            if(canBeBribed(warehouse))
            {
                // Ignite the enemy player's building unless it is a headquarters
                Building toIgnite = Player.OtherPlayer.Buildings[0];
                if(!toIgnite.IsHeadquarters)
                {
                    warehouse.Ignite(toIgnite);
                }
            }
            // Get my first fire department
            FireDepartment fireDepartment = Player.FireDepartments[0];
            if(canBeBribed(fireDepartment))
            {
                // Extinguish my first building unless it is a headquarters
                Building toExtinguish = Player.Buildings[0];
                if(!toExtinguish.IsHeadquarters)
                {
                    fireDepartment.Extinguish(toExtinguish);
                }
            }
            // Get my first police department
            PoliceDepartment policeDepartment = Player.PoliceDepartments[0];
            if(canBeBribed(policeDepartment))
            {
                Warehouse target = Player.OtherPlayer.Warehouses[0];
                // Make sure the target is alive and has exposure
                if(Player.BribesRemaining > 0 && target.Health > 0 && target.Exposure > 0)
                {
                    // Raid the first enemy warehouse
                    policeDepartment.Raid(target);
                }
            }
            // Get my first weather station
            WeatherStation weatherStation1 = Player.WeatherStations[0];
            if(canBeBribed(weatherStation1))
            {
                if(Player.BribesRemaining > 0)
                {
                    // Make sure the intensity isn't at max
                    if(Game.NextForecast.Intensity < Game.MaxForecastIntensity)
                    {
                        weatherStation1.Intensify(false);
                    }
                    else
                    {
                        // Otherwise decrease the intensity
                        weatherStation1.Intensify(true);
                    }
                }
            }
            // Get my second weather station
            WeatherStation weatherStation2 = Player.WeatherStations[1];
            if (canBeBribed(weatherStation2))
            {
                if (Player.BribesRemaining > 0)
                {
                    // Rotate clockwise
                    weatherStation2.Rotate();
                }
            }

            return true;
        }

        /// <summary>
        /// Convenience method for checking if you can use a bribe on a building
        /// </summary>
        /// <remarks>
        /// This is an example of how you can create your own methods to use
        /// </remarks>
        /// <returns>true if building can be bribed this turn, false if the building cannot be bribed this turn</returns>
        public bool canBeBribed(Building building)
        {
            // Make sure it has health, hasn't been bribed, and you are the owner
            return (building.Health > 0 && building.Owner == Player && !building.Bribed);
        }
        #endregion
    }
}
