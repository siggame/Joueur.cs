// A celestial body located within the game.

// DO NOT MODIFY THIS FILE
// Never try to directly create an instance of this class, or modify its member variables.
// Instead, you should only be reading its variables and calling its functions.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add additional using(s) here
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Stardash
{
    /// <summary>
    /// A celestial body located within the game.
    /// </summary>
    public class Body : Stardash.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of material the object has, or energy if it is a planet.
        /// </summary>
        public int Amount { get; protected set; }

        /// <summary>
        /// The type of celestial body it is. Either 'planet', 'asteroid', or 'sun'.
        /// </summary>
        public string BodyType { get; protected set; }

        /// <summary>
        /// The type of material the celestial body has. Either 'none', 'genarium', 'rarium', 'legendarium', or 'mythicite'.
        /// </summary>
        public string MaterialType { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Body.
        /// </summary>
        public Stardash.Player Owner { get; protected set; }

        /// <summary>
        /// The radius of the circle that this body takes up.
        /// </summary>
        public double Radius { get; protected set; }

        /// <summary>
        /// The x value this celestial body is on.
        /// </summary>
        public double X { get; protected set; }

        /// <summary>
        /// The y value this celestial body is on.
        /// </summary>
        public double Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Body. Used during game initialization, do not call directly.
        /// </summary>
        protected Body() : base()
        {
        }

        /// <summary>
        /// The x value of this body a number of turns from now. (0-how many you want).
        /// </summary>
        /// <param name="num">The number of turns in the future you wish to check.</param>
        /// <returns>The x position of the body the input number of turns in the future.</returns>
        public int NextX(int num)
        {
            return this.RunOnServer<int>("nextX", new Dictionary<string, object> {
                {"num", num}
            });
        }

        /// <summary>
        /// The x value of this body a number of turns from now. (0-how many you want).
        /// </summary>
        /// <param name="num">The number of turns in the future you wish to check.</param>
        /// <returns>The x position of the body the input number of turns in the future.</returns>
        public int NextY(int num)
        {
            return this.RunOnServer<int>("nextY", new Dictionary<string, object> {
                {"num", num}
            });
        }

        /// <summary>
        /// Spawn a unit on some value of this celestial body.
        /// </summary>
        /// <param name="x">The x value of the spawned unit.</param>
        /// <param name="y">The y value of the spawned unit.</param>
        /// <param name="title">The job title of the unit being spawned.</param>
        /// <returns>True if successfully taken, false otherwise.</returns>
        public bool Spawn(double x, double y, string title)
        {
            return this.RunOnServer<bool>("spawn", new Dictionary<string, object> {
                {"x", x},
                {"y", y},
                {"title", title}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
