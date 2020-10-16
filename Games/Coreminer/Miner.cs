// A Miner in the game.

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
    /// A Miner in the game.
    /// </summary>
    public class Miner : Coreminer.GameObject
    {
        #region Properties
        /// <summary>
        /// The number of bombs being carried by this Miner.
        /// </summary>
        public int Bombs { get; protected set; }

        /// <summary>
        /// The number of building materials carried by this Miner.
        /// </summary>
        public int BuildingMaterials { get; protected set; }

        /// <summary>
        /// The amount of dirt carried by this Miner.
        /// </summary>
        public int Dirt { get; protected set; }

        /// <summary>
        /// The remaining health of this Miner.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The remaining mining power this Miner has this turn.
        /// </summary>
        public int MiningPower { get; protected set; }

        /// <summary>
        /// The number of moves this Miner has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The amount of ore carried by this Miner.
        /// </summary>
        public int Ore { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Miner.
        /// </summary>
        public Coreminer.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile this Miner is on.
        /// </summary>
        public Coreminer.Tile Tile { get; protected set; }

        /// <summary>
        /// The Upgrade this Miner is on.
        /// </summary>
        public Coreminer.Upgrade Upgrade { get; protected set; }

        /// <summary>
        /// The upgrade level of this Miner. Starts at 0.
        /// </summary>
        public int UpgradeLevel { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Miner. Used during game initialization, do not call directly.
        /// </summary>
        protected Miner() : base()
        {
        }

        /// <summary>
        /// Builds a support, shield, or ladder on Miner's Tile, or an adjacent Tile.
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
        /// Purchase a resource from the Player's base or hopper.
        /// </summary>
        /// <param name="resource">The type of resource to buy.</param>
        /// <param name="amount">The amount of resource to buy. Amounts &lt;= 0 will buy all of that material Player can.</param>
        /// <returns>True if successfully purchased, false otherwise.</returns>
        public bool Buy(string resource, int amount)
        {
            return this.RunOnServer<bool>("buy", new Dictionary<string, object> {
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Dumps materials from cargo to an adjacent Tile. If the Tile is a base or a hopper Tile, materials are sold instead of placed.
        /// </summary>
        /// <param name="tile">The Tile the materials will be dumped on.</param>
        /// <param name="material">The material the Miner will drop. 'dirt', 'ore', or 'bomb'.</param>
        /// <param name="amount">The number of materials to drop. Amounts &lt;= 0 will drop all of the material.</param>
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
        /// Mines the Tile the Miner is on or an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile the materials will be mined from.</param>
        /// <param name="amount">The amount of material to mine up. Amounts &lt;= 0 will mine all the materials that the Miner can.</param>
        /// <returns>True if successfully mined, false otherwise.</returns>
        public bool Mine(Coreminer.Tile tile, int amount)
        {
            return this.RunOnServer<bool>("mine", new Dictionary<string, object> {
                {"tile", tile},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Moves this Miner from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Miner should move to.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(Coreminer.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Transfers a resource from the one Miner to another.
        /// </summary>
        /// <param name="miner">The Miner to transfer materials to.</param>
        /// <param name="resource">The type of resource to transfer.</param>
        /// <param name="amount">The amount of resource to transfer. Amounts &lt;= 0 will transfer all the of the material.</param>
        /// <returns>True if successfully transferred, false otherwise.</returns>
        public bool Transfer(Coreminer.Miner miner, string resource, int amount)
        {
            return this.RunOnServer<bool>("transfer", new Dictionary<string, object> {
                {"miner", miner},
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Upgrade this Miner by installing an upgrade module.
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
