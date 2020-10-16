// Information about a Miner's Upgrade module.

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
    /// Information about a Miner's Upgrade module.
    /// </summary>
    public class Upgrade : Coreminer.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of cargo capacity this Upgrade has.
        /// </summary>
        public int CargoCapacity { get; protected set; }

        /// <summary>
        /// The maximum amount of health this Upgrade has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The amount of mining power this Upgrade has per turn.
        /// </summary>
        public int MiningPower { get; protected set; }

        /// <summary>
        /// The number of moves this Upgrade can make per turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Upgrade title.
        /// </summary>
        public string Title { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Upgrade. Used during game initialization, do not call directly.
        /// </summary>
        protected Upgrade() : base()
        {
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
