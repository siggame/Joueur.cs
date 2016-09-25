// A bottle thrown by a bartender at a Tile.

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
    /// A bottle thrown by a bartender at a Tile.
    /// </summary>
    class Bottle : Saloon.GameObject
    {
        #region Properties
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
        public Saloon.Tile Location { get; protected set; }

        /// <summary>
        /// The Tile this Bottle will fly to next turn, if it does not impact anything on its path between the two.
        /// </summary>
        public Saloon.Tile NextLocation { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Bottle. Used during game initialization, do not call directly.
        /// </summary>
        protected Bottle() : base()
        {
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
