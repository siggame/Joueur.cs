// An furnishing in the Saloon that must be pathed around, or destroyed.

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
    /// An furnishing in the Saloon that must be pathed around, or destroyed.
    /// </summary>
    class Furnishing : Saloon.GameObject
    {
        #region Properties
        /// <summary>
        /// How much health this Furnishing currently has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// If this Furnishing has been destroyed, and has been removed from the game.
        /// </summary>
        public bool IsDestroyed { get; protected set; }

        /// <summary>
        /// True if this Furnishing is a piano and can be played, False otherwise.
        /// </summary>
        public bool IsPiano { get; protected set; }

        /// <summary>
        /// If this is a piano and a Cowboy is playing it this turn.
        /// </summary>
        public bool IsPlaying { get; protected set; }

        /// <summary>
        /// The Tile that this Furnishing is located on.
        /// </summary>
        public Saloon.Tile Tile { get; protected set; }


        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.

        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Furnishing. Used during game initialization, do not call directly.
        /// </summary>
        protected Furnishing() : base()
        {
        }


        // you can add addtional method(s) here.

        #endregion
    }
}
