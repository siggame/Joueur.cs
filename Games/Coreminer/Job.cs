// Information about a Unit's job.

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

namespace Joueur.cs.Games.Coreminer
{
    /// <summary>
    /// Information about a Unit's job.
    /// </summary>
    public class Job : Coreminer.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of cargo capacity this Unit starts with.
        /// </summary>
        public int CargoCapacity { get; protected set; }

        /// <summary>
        /// The amount of starting health this Job has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The maximum amount of cargo capacity this Unit can have.
        /// </summary>
        public int MaxCargoCapacity { get; protected set; }

        /// <summary>
        /// The maximum amount of health this Job can have.
        /// </summary>
        public int MaxHealth { get; protected set; }

        /// <summary>
        /// The maximum amount of mining power this Unit can have.
        /// </summary>
        public int MaxMiningPower { get; protected set; }

        /// <summary>
        /// The maximum number of moves this Job can have.
        /// </summary>
        public int MaxMoves { get; protected set; }

        /// <summary>
        /// The amount of mining power this Unit has per turn.
        /// </summary>
        public int MiningPower { get; protected set; }

        /// <summary>
        /// The number of moves this Job can make per turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Job title. 'miner' or 'bomb'.
        /// </summary>
        public string Title { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Job. Used during game initialization, do not call directly.
        /// </summary>
        protected Job() : base()
        {
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
