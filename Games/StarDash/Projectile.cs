// Tracks any projectiles moving through space.

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
    /// Tracks any projectiles moving through space.
    /// </summary>
    public class Projectile : Stardash.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of remaining distance the projectile can move.
        /// </summary>
        public int Fuel { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit.
        /// </summary>
        public Stardash.Player Owner { get; protected set; }

        /// <summary>
        /// The unit that is being attacked by this projectile.
        /// </summary>
        public Stardash.Unit Target { get; protected set; }

        /// <summary>
        /// The x value this projectile is on.
        /// </summary>
        public double X { get; protected set; }

        /// <summary>
        /// The y value this projectile is on.
        /// </summary>
        public double Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Projectile. Used during game initialization, do not call directly.
        /// </summary>
        protected Projectile() : base()
        {
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
