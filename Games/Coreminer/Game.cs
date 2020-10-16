// Mine resources to obtain more value than your opponent.

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

/// <summary>
/// Mine resources to obtain more value than your opponent.
/// </summary>
namespace Joueur.cs.Games.Coreminer
{
    /// <summary>
    /// Mine resources to obtain more value than your opponent.
    /// </summary>
    public class Game : BaseGame
    {
        /// <summary>
        /// The game version hash, used to compare if we are playing the same version on the server.
        /// </summary>
        new protected static string GameVersion = "ce6c632876295900d0b2fc6db0f63dfc8a20533396c67b472fa03817cb82edc4";

        #region Properties
        /// <summary>
        /// The monetary price of a bomb when bought or sold.
        /// </summary>
        public int BombPrice { get; protected set; }

        /// <summary>
        /// The amount of cargo space taken up by a Bomb.
        /// </summary>
        public int BombSize { get; protected set; }

        /// <summary>
        /// Every Bomb in the game.
        /// </summary>
        public IList<Coreminer.Bomb> Bombs { get; protected set; }

        /// <summary>
        /// The monetary price of building materials when bought.
        /// </summary>
        public int BuildingMaterialPrice { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Coreminer.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The monetary price of dirt when bought or sold.
        /// </summary>
        public int DirtPrice { get; protected set; }

        /// <summary>
        /// The amount of damage taken per Tile fallen.
        /// </summary>
        public int FallDamage { get; protected set; }

        /// <summary>
        /// The amount of extra damage taken for falling while carrying a large amount of cargo.
        /// </summary>
        public int FallWeightDamage { get; protected set; }

        /// <summary>
        /// The amount of building material required to build a ladder.
        /// </summary>
        public int LadderCost { get; protected set; }

        /// <summary>
        /// The amount of mining power needed to remove a ladder from a Tile.
        /// </summary>
        public int LadderHealth { get; protected set; }

        /// <summary>
        /// The amount deemed as a large amount of cargo.
        /// </summary>
        public int LargeCargoSize { get; protected set; }

        /// <summary>
        /// The amount deemed as a large amount of material.
        /// </summary>
        public int LargeMaterialSize { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the y (vertical) axis.
        /// </summary>
        public int MapHeight { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the x (horizontal) axis.
        /// </summary>
        public int MapWidth { get; protected set; }

        /// <summary>
        /// The maximum amount of shielding possible on a Tile.
        /// </summary>
        public int MaxShielding { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The highest upgrade level allowed on a Miner.
        /// </summary>
        public int MaxUpgradeLevel { get; protected set; }

        /// <summary>
        /// Every Miner in the game.
        /// </summary>
        public IList<Coreminer.Miner> Miners { get; protected set; }

        /// <summary>
        /// The amount of money awarded when ore is dumped in the base and sold.
        /// </summary>
        public int OrePrice { get; protected set; }

        /// <summary>
        /// The amount of value awarded when ore is dumped in the base and sold.
        /// </summary>
        public int OreValue { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Coreminer.Player> Players { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The amount of building material required to shield a Tile.
        /// </summary>
        public int ShieldCost { get; protected set; }

        /// <summary>
        /// The amount of mining power needed to remove one unit of shielding off a Tile.
        /// </summary>
        public int ShieldHealth { get; protected set; }

        /// <summary>
        /// The monetary price of spawning a Miner.
        /// </summary>
        public int SpawnPrice { get; protected set; }

        /// <summary>
        /// The amount of damage taken when suffocating inside a filled Tile.
        /// </summary>
        public int SuffocationDamage { get; protected set; }

        /// <summary>
        /// The amount of extra damage taken for suffocating under a large amount of material.
        /// </summary>
        public int SuffocationWeightDamage { get; protected set; }

        /// <summary>
        /// The amount of building material required to build a support.
        /// </summary>
        public int SupportCost { get; protected set; }

        /// <summary>
        /// The amount of mining power needed to remove a support from a Tile.
        /// </summary>
        public int SupportHealth { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Coreminer.Tile> Tiles { get; protected set; }

        /// <summary>
        /// The amount of time (in nano-seconds) added after each player performs a turn.
        /// </summary>
        public int TimeAddedPerTurn { get; protected set; }

        /// <summary>
        /// The cost to upgrade a Miner.
        /// </summary>
        public int UpgradePrice { get; protected set; }

        /// <summary>
        /// Every Upgrade for a Miner in the game.
        /// </summary>
        public IList<Coreminer.Upgrade> Upgrades { get; protected set; }

        /// <summary>
        /// The amount of victory points (value) required to win.
        /// </summary>
        public int VictoryAmount { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Game. Used during game initialization, do not call directly.
        /// </summary>
        protected Game() : base()
        {
            this.Name = "Coreminer";

            this.Bombs = new List<Coreminer.Bomb>();
            this.Miners = new List<Coreminer.Miner>();
            this.Players = new List<Coreminer.Player>();
            this.Tiles = new List<Coreminer.Tile>();
            this.Upgrades = new List<Coreminer.Upgrade>();
        }


        /// <summary>
        /// Gets the Tile at a specified (x, y) position
        /// </summary>
        /// <param name="x">integer between 0 and the MapWidth</param>
        /// <param name="y">integer between 0 and the MapHeight</param>
        /// <returns>the Tile at (x, y) or null if out of bounds</returns>
        public Tile GetTileAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.MapWidth || y >= this.MapHeight)
            {
                // out of bounds
                return null;
            }

            return this.Tiles[x + y * this.MapWidth];
        }

        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
