// A bottle thrown by a bartender at a Tile.

// DO NOT MODIFY THIS FILE
// Never try to directly create an instance of this class, or modify its member variables.
// Instead, you should only be reading its variables and calling its functions.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// you can add addtional using(s) here


namespace Joueur.cs.Games.Saloon
{
    /// <summary>
    /// A bottle thrown by a bartender at a Tile.
    /// </summary>
    class Bottle : Saloon.GameObject
    {
        #region Properties
        /// <summary>
        /// The Direction this Bottle is flying and will move to between turns, can be 'North', 'East', 'South', or 'West'.
        /// </summary>
        public string Direction { get; protected set; }

        /// <summary>
        /// The direction any Cowboys hit by this will move, can be 'North', 'East', 'South', or 'West'.
        /// </summary>
        public string DrunkDirection { get; protected set; }

        /// <summary>
        /// True if this Bottle has impacted and has been destroyed (removed from the Game). False if still in the game flying through the saloon.
        /// </summary>
        public bool IsDestroyed { get; protected set; }

        /// <summary>
        /// The Tile this bottle is currently flying over.
        /// </summary>
        public Saloon.Tile Tile { get; protected set; }


        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.

        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Bottle. Used during game initialization, do not call directly.
        /// </summary>
        protected Bottle() : base()
        {
        }


        // you can add addtional method(s) here.

        #endregion
    }
}
