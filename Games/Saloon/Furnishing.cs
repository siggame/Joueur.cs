// An furnishing in the Saloon that must be pathed around, or destroyed.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add addtional using(s) here
// <<-- /Creer-Merge: usings -->>

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
        /// True if this Furnishing is a piano and can be played, False otherwise.
        /// </summary>
        public bool IsPiano { get; protected set; }

        /// <summary>
        /// The Tile that this Furnishing is located on.
        /// </summary>
        public Saloon.Tile Tile { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Furnishing. Used during game initialization, do not call directly.
        /// </summary>
        protected Furnishing() : base()
        {
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
