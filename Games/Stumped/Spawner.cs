// A resource spawner that generates branches or fish.

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

namespace Joueur.cs.Games.Stumped
{
    /// <summary>
    /// A resource spawner that generates branches or fish.
    /// </summary>
    class Spawner : Stumped.GameObject
    {
        #region Properties
        /// <summary>
        /// True if this Spawner has been harvested this turn, and it will not heal at the end of the turn, false otherwise.
        /// </summary>
        public bool HasBeenHarvested { get; protected set; }

        /// <summary>
        /// How much health this spawner has, which is used to calculate how much of its resource can be harvested.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The tile this Spawner is on.
        /// </summary>
        public Stumped.Tile Tile { get; protected set; }

        /// <summary>
        /// What type of resource this is ('Fish' or 'Branch').
        /// </summary>
        public string Type { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Spawner. Used during game initialization, do not call directly.
        /// </summary>
        protected Spawner() : base()
        {
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
