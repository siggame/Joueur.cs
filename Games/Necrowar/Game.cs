// Send hordes of the undead at your opponent while defending yourself against theirs to win.

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
/// Send hordes of the undead at your opponent while defending yourself against theirs to win.
/// </summary>
namespace Joueur.cs.Games.Necrowar
{
    /// <summary>
    /// Send hordes of the undead at your opponent while defending yourself against theirs to win.
    /// </summary>
    public class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Necrowar.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The amount of gold income per turn per unit in a mine.
        /// </summary>
        public int GoldIncomePerUnit { get; protected set; }

        /// <summary>
        /// The amount of gold income per turn per unit in the island mine.
        /// </summary>
        public int IslandIncomePerUnit { get; protected set; }

        /// <summary>
        /// The Amount of gold income per turn per unit fishing on the river side.
        /// </summary>
        public int ManaIncomePerUnit { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the y (vertical) axis.
        /// </summary>
        public int MapHeight { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the x (horizontal) axis.
        /// </summary>
        public int MapWidth { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The maximum number of workers that can occupy a mine at a given time.
        /// </summary>
        public int MineUnitCap { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Necrowar.Player> Players { get; protected set; }

        /// <summary>
        /// The amount of turns it takes between the river changing phases.
        /// </summary>
        public int RiverPhase { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// A list of every tower type / job.
        /// </summary>
        public IList<Necrowar.tJob> TJobs { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Necrowar.Tile> Tiles { get; protected set; }

        /// <summary>
        /// The amount of time (in nano-seconds) added after each player performs a turn.
        /// </summary>
        public int TimeAddedPerTurn { get; protected set; }

        /// <summary>
        /// Every Tower in the game.
        /// </summary>
        public IList<Necrowar.Tower> Towers { get; protected set; }

        /// <summary>
        /// A list of every unit type / job.
        /// </summary>
        public IList<Necrowar.uJob> UJobs { get; protected set; }

        /// <summary>
        /// Every Unit in the game.
        /// </summary>
        public IList<Necrowar.Unit> Units { get; protected set; }


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
            this.Name = "Necrowar";

            this.Players = new List<Necrowar.Player>();
            this.TJobs = new List<Necrowar.tJob>();
            this.Tiles = new List<Necrowar.Tile>();
            this.Towers = new List<Necrowar.Tower>();
            this.UJobs = new List<Necrowar.uJob>();
            this.Units = new List<Necrowar.Unit>();
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
