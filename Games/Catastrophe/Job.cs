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

namespace Joueur.cs.Games.Catastrophe
{
    /// <summary>
    /// Information about a Unit's job.
    /// </summary>
    public class Job : Catastrophe.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of energy this Job normally uses to perform its actions.
        /// </summary>
        public double ActionCost { get; protected set; }

        /// <summary>
        /// How many combined resources a Unit with this Job can hold at once.
        /// </summary>
        public int CarryLimit { get; protected set; }

        /// <summary>
        /// The number of moves this Job can make per turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The amount of energy normally regenerated when resting at a shelter.
        /// </summary>
        public double RegenRate { get; protected set; }

        /// <summary>
        /// The Job title.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// The amount of food per turn this Unit consumes. If there isn't enough food for every Unit, all Units become starved and do not consume food.
        /// </summary>
        public int Upkeep { get; protected set; }


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
