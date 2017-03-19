// Information about a beaver's job.

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
    /// Information about a beaver's job.
    /// </summary>
    class Job : Stumped.GameObject
    {
        #region Properties
        /// <summary>
        /// The number of actions this job can make per turn.
        /// </summary>
        public int Actions { get; protected set; }

        /// <summary>
        /// How many resources a beaver with this job can hold at once.
        /// </summary>
        public int CarryLimit { get; protected set; }

        /// <summary>
        /// Scalar for how many branches this job harvests at once.
        /// </summary>
        public int Chopping { get; protected set; }

        /// <summary>
        /// How many fish this Job costs to recruit.
        /// </summary>
        public int Cost { get; protected set; }

        /// <summary>
        /// The amount of damage this job does per attack.
        /// </summary>
        public int Damage { get; protected set; }

        /// <summary>
        /// How many turns a beaver attacked by this job is distracted by.
        /// </summary>
        public int DistractionPower { get; protected set; }

        /// <summary>
        /// Scalar for how many fish this job harvests at once.
        /// </summary>
        public int Fishing { get; protected set; }

        /// <summary>
        /// The amount of starting health this job has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The number of moves this job can make per turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The job title ('builder', 'fisher', etc).
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

        /// <summary>
        /// Recruits a Beaver of this Job to a lodge
        /// </summary>
        /// <param name="tile">The Tile that is a lodge owned by you that you wish to spawn the Beaver of this Job on.</param>
        /// <returns>The recruited Beaver if successful, null otherwise.</returns>
        public Stumped.Beaver Recruit(Stumped.Tile tile)
        {
            return this.RunOnServer<Stumped.Beaver>("recruit", new Dictionary<string, object> {
                {"tile", tile}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
