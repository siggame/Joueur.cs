// A unit in the game.

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
    /// A unit in the game.
    /// </summary>
    public class Unit : Coreminer.GameObject
    {
        #region Properties
        /// <summary>
        /// The number of bombs being carried by this Unit. (0 to job cargo capacity - other carried materials).
        /// </summary>
        public int Bombs { get; protected set; }

        /// <summary>
        /// The number of building materials carried by this Unit. (0 to job cargo capacity - other carried materials).
        /// </summary>
        public int BuildingMaterials { get; protected set; }

        /// <summary>
        /// The amount of dirt carried by this Unit. (0 to job cargo capacity - other carried materials).
        /// </summary>
        public int Dirt { get; protected set; }

        /// <summary>
        /// The remaining health of a Unit.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The Job this Unit has.
        /// </summary>
        public Coreminer.Job Job { get; protected set; }

        /// <summary>
        /// The maximum amount of cargo this Unit can carry.
        /// </summary>
        public int MaxCargoCapacity { get; protected set; }

        /// <summary>
        /// The maximum health of this Unit.
        /// </summary>
        public int MaxHealth { get; protected set; }

        /// <summary>
        /// The maximum mining power of this Unit.
        /// </summary>
        public int MaxMiningPower { get; protected set; }

        /// <summary>
        /// The maximum moves this Unit can have.
        /// </summary>
        public int MaxMoves { get; protected set; }

        /// <summary>
        /// The remaining mining power this Unit has this turn.
        /// </summary>
        public int MiningPower { get; protected set; }

        /// <summary>
        /// The number of moves this Unit has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The amount of ore carried by this Unit. (0 to job capacity - other carried materials).
        /// </summary>
        public int Ore { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit.
        /// </summary>
        public Coreminer.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile this Unit is on.
        /// </summary>
        public Coreminer.Tile Tile { get; protected set; }

        /// <summary>
        /// The upgrade level of this unit. Starts at 0.
        /// </summary>
        public int UpgradeLevel { get; protected set; }


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
        /// Builds a support, shield, or ladder on Unit's tile, or an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile to build on.</param>
        /// <param name="type">The structure to build (support, ladder, or shield).</param>
        /// <returns>True if successfully built, False otherwise.</returns>
        public bool Build(Coreminer.Tile tile, string type)
        {
            return this.RunOnServer<bool>("build", new Dictionary<string, object> {
                {"tile", tile},
                {"type", type}
            });
        }

        /// <summary>
        /// Purchase a resource from the player's base or hopper.
        /// </summary>
        /// <param name="resource">The type of resource to buy.</param>
        /// <param name="amount">The amount of resource to buy.</param>
        /// <returns>True if successfully purchased, false otherwise.</returns>
        public bool Buy(string resource, int amount)
        {
            return this.RunOnServer<bool>("buy", new Dictionary<string, object> {
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Dumps materials from cargo to an adjacent tile. If the tile is a base or hopper tile, materials are sold instead of placed.
        /// </summary>
        /// <param name="tile">The tile the materials will be dumped on.</param>
        /// <param name="material">The material the Unit will drop. 'dirt', 'ore', or 'bomb'.</param>
        /// <param name="amount">The number of materials to drop. Amounts &lt;= 0 will drop all the materials.</param>
        /// <returns>True if successfully dumped materials, false otherwise.</returns>
        public bool Dump(Coreminer.Tile tile, string material, int amount)
        {
            return this.RunOnServer<bool>("dump", new Dictionary<string, object> {
                {"tile", tile},
                {"material", material},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Mines the Tile the Unit is on or an adjacent tile.
        /// </summary>
        /// <param name="tile">The Tile the materials will be mined from.</param>
        /// <param name="amount">The amount of material to mine up. Amounts &lt;= 0 will mine all the materials that the Unit can.</param>
        /// <returns>True if successfully mined, false otherwise.</returns>
        public bool Mine(Coreminer.Tile tile, int amount)
        {
            return this.RunOnServer<bool>("mine", new Dictionary<string, object> {
                {"tile", tile},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Moves this Unit from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Unit should move to.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(Coreminer.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Transfers a resource from the one Unit to another.
        /// </summary>
        /// <param name="unit">The Unit to transfer materials to.</param>
        /// <param name="resource">The type of resource to transfer.</param>
        /// <param name="amount">The amount of resource to transfer.</param>
        /// <returns>True if successfully transfered, false otherwise.</returns>
        public bool Transfer(Coreminer.Unit unit, string resource, int amount)
        {
            return this.RunOnServer<bool>("transfer", new Dictionary<string, object> {
                {"unit", unit},
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Upgrade this Unit.
        /// </summary>
        /// <returns>True if successfully upgraded, False otherwise.</returns>
        public bool Upgrade()
        {
            return this.RunOnServer<bool>("upgrade", new Dictionary<string, object> {
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
