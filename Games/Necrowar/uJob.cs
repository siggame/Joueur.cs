// Information about a unit's job/type.

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
    /// Information about a unit's job/type.
    /// </summary>
    public class uJob : Necrowar.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of damage this type does per attack.
        /// </summary>
        public int Damage { get; protected set; }

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
        /// The number of moves this type can make per turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// How many of this type of unit can take up one tile.
        /// </summary>
        public int PerTile { get; protected set; }

        /// <summary>
        /// Amount of tiles away this type has to be in order to be effective.
        /// </summary>
        public int Range { get; protected set; }

        /// <summary>
        /// The type title. 'worker', 'zombie', 'ghoul', 'hound', 'abomination', 'wraith' or 'horseman'.
        /// </summary>
        public string Title { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of uJob. Used during game initialization, do not call directly.
        /// </summary>
        protected uJob() : base()
        {
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
