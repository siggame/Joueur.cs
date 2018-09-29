// A unit in the game. May be a manager, intern, or physicist.

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

namespace Joueur.cs.Games.Newtonian
{
    /// <summary>
    /// A unit in the game. May be a manager, intern, or physicist.
    /// </summary>
    public class Unit : Newtonian.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether or not this Unit has performed its action this turn.
        /// </summary>
        public bool Acted { get; protected set; }

        /// <summary>
        /// The amount of blueium carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int Blueium { get; protected set; }

        /// <summary>
        /// The amount of blueium ore carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int BlueiumOre { get; protected set; }

        /// <summary>
        /// The remaining health of a unit.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The Job this Unit has.
        /// </summary>
        public Newtonian.Job Job { get; protected set; }

        /// <summary>
        /// The number of moves this unit has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit.
        /// </summary>
        public Newtonian.Player Owner { get; protected set; }

        /// <summary>
        /// The amount of redium carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int Redium { get; protected set; }

        /// <summary>
        /// The amount of redium ore carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int RediumOre { get; protected set; }

        /// <summary>
        /// Duration of stun immunity. (0 to timeImmune).
        /// </summary>
        public int StunImmune { get; protected set; }

        /// <summary>
        /// Duration the unit is stunned. (0 to the game constant stunTime).
        /// </summary>
        public int StunTime { get; protected set; }

        /// <summary>
        /// The Tile this Unit is on.
        /// </summary>
        public Newtonian.Tile Tile { get; protected set; }


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
        /// Makes the unit do something to a machine adjacent to its tile. Interns sabotage, physicists work. Interns stun physicist, physicist stuns manager, manager stuns intern.
        /// </summary>
        /// <param name="tile">The tile the unit acts on.</param>
        /// <returns>True if successfully acted, false otherwise.</returns>
        public bool Act(Newtonian.Tile tile)
        {
            return this.RunOnServer<bool>("act", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Attacks a unit on an adjacent tile.
        /// </summary>
        /// <param name="tile">The Tile to attack.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Newtonian.Tile tile)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Drops materials at the units feet or adjacent tile.
        /// </summary>
        /// <param name="tile">The tile the materials will be dropped on.</param>
        /// <param name="amount">The number of materials to dropped. Amounts &lt;= 0 will drop all the materials.</param>
        /// <param name="material">The material the unit will drop.</param>
        /// <returns>True if successfully deposited, false otherwise.</returns>
        public bool Drop(Newtonian.Tile tile, int amount, string material)
        {
            return this.RunOnServer<bool>("drop", new Dictionary<string, object> {
                {"tile", tile},
                {"amount", amount},
                {"material", material}
            });
        }

        /// <summary>
        /// Moves this Unit from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Unit should move to.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(Newtonian.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Picks up material at the units feet or adjacent tile.
        /// </summary>
        /// <param name="tile">The tile the materials will be picked up from.</param>
        /// <param name="amount">The amount of materials to pick up. Amounts &lt;= 0 will pick up all the materials that the unit can.</param>
        /// <param name="material">The material the unit will pick up.</param>
        /// <returns>True if successfully deposited, false otherwise.</returns>
        public bool Pickup(Newtonian.Tile tile, int amount, string material)
        {
            return this.RunOnServer<bool>("pickup", new Dictionary<string, object> {
                {"tile", tile},
                {"amount", amount},
                {"material", material}
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
