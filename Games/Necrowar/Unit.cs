// A unit in the game. May be a worker, zombie, ghoul, hound, abomination, wraith or horseman.

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
    /// A unit in the game. May be a worker, zombie, ghoul, hound, abomination, wraith or horseman.
    /// </summary>
    public class Unit : Necrowar.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether or not this Unit has attacked this turn or not.
        /// </summary>
        public bool Attacked { get; protected set; }

        /// <summary>
        /// Whether or not this Unit has built a tower (workers only) this turn or not.
        /// </summary>
        public bool Built { get; protected set; }

        /// <summary>
        /// The remaining health of a unit.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// Whether or not this Unit has moved yet this turn.
        /// </summary>
        public bool Moved { get; protected set; }

        /// <summary>
        /// The number of moves this unit has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit.
        /// </summary>
        public Necrowar.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile this Unit is on.
        /// </summary>
        public Necrowar.Tile Tile { get; protected set; }

        /// <summary>
        /// The type of unit this is.
        /// </summary>
        public Necrowar.uJob UJob { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Unit. Used during game initialization, do not call directly.
        /// </summary>
        protected Unit() : base()
        {
        }

        /// <summary>
        /// Attacks an enemy tower on an adjacent tile.
        /// </summary>
        /// <param name="tile">The Tile to attack.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Necrowar.Tile tile)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Unit, if it is a worker, builds a tower on the tile it is on, only workers can do this.
        /// </summary>
        /// <param name="tile">The tile the unit is on/builds on.</param>
        /// <param name="tJob">The type of tower that is being built. 'arrow', 'aoe', 'ballista', or 'cleansing'.</param>
        /// <returns>True if successfully built, false otherwise.</returns>
        public bool Build(Necrowar.Tile tile, Necrowar.tJob tJob)
        {
            return this.RunOnServer<bool>("build", new Dictionary<string, object> {
                {"tile", tile},
                {"tJob", tJob}
            });
        }

        /// <summary>
        /// Stops adjacent to a river tile and begins fishing for mana.
        /// </summary>
        /// <param name="tile">The tile the unit will stand on as it fishes.</param>
        /// <returns>True if successfully began fishing for mana, false otherwise.</returns>
        public bool Fish(Necrowar.Tile tile)
        {
            return this.RunOnServer<bool>("fish", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Enters an empty mine tile and is put to work gathering resources.
        /// </summary>
        /// <param name="tile">The tile the mine is located on.</param>
        /// <returns>True if successfully entered mine and began mining, false otherwise.</returns>
        public bool Mine(Necrowar.Tile tile)
        {
            return this.RunOnServer<bool>("mine", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Moves this Unit from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Unit should move to.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(Necrowar.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
