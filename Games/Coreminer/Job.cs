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
        /// The amount of cargo capacity this Unit starts with per level.
        /// </summary>
        public IList<int> CargoCapacity { get; protected set; }

        /// <summary>
        /// The amount of starting health this Job has per level.
        /// </summary>
        public IList<int> Health { get; protected set; }

        /// <summary>
        /// The amount of mining power this Unit has per turn per level.
        /// </summary>
        public IList<int> MiningPower { get; protected set; }

        /// <summary>
        /// The number of moves this Job can make per turn per level.
        /// </summary>
        public IList<int> Moves { get; protected set; }

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
            this.CargoCapacity = new List<int>();
            this.Health = new List<int>();
            this.MiningPower = new List<int>();
            this.Moves = new List<int>();
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
