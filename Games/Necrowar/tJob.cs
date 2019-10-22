// Information about a tower's job/type.

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

namespace Joueur.cs.Games.Necrowar
{
    /// <summary>
    /// Information about a tower's job/type.
    /// </summary>
    public class tJob : Necrowar.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether this tower type hits all of the units on a tile (true) or one at a time (false).
        /// </summary>
        public bool AllUnits { get; protected set; }

        /// <summary>
        /// How much does this type cost in gold.
        /// </summary>
        public int GoldCost { get; protected set; }

        /// <summary>
        /// The amount of starting health this type has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// How much does this type cost in mana.
        /// </summary>
        public int ManaCost { get; protected set; }

        /// <summary>
        /// The number of tiles this type can attack from.
        /// </summary>
        public int Range { get; protected set; }

        /// <summary>
        /// The type title. 'arrow', 'aoe', 'ballista', or 'cleansing'.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// How many turns this tower type needs to take between attacks.
        /// </summary>
        public int TurnsBetweenAttacks { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of tJob. Used during game initialization, do not call directly.
        /// </summary>
        protected tJob() : base()
        {
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
