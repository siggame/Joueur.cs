// A tower in the game. Used to combat enemy waves.

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
    /// A tower in the game. Used to combat enemy waves.
    /// </summary>
    public class Tower : Necrowar.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether this tower has attacked this turn or not.
        /// </summary>
        public bool Attacked { get; protected set; }

        /// <summary>
        /// How many turns are left before it can fire again.
        /// </summary>
        public int Cooldown { get; protected set; }

        /// <summary>
        /// How much remaining health this tower has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// What type of tower this is (it's job).
        /// </summary>
        public Necrowar.TowerJob Job { get; protected set; }

        /// <summary>
        /// The player that built / owns this tower.
        /// </summary>
        public Necrowar.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile this Tower is on.
        /// </summary>
        public Necrowar.Tile Tile { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Tower. Used during game initialization, do not call directly.
        /// </summary>
        protected Tower() : base()
        {
        }

        /// <summary>
        /// Attacks an enemy unit on an tile within it's range.
        /// </summary>
        /// <param name="tile">The Tile to attack.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Necrowar.Tile tile)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"tile", tile}
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
