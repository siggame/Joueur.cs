// Combine elements and be the first scientists to create fusion.

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
/// Combine elements and be the first scientists to create fusion.
/// </summary>
namespace Joueur.cs.Games.Newtonian
{
    /// <summary>
    /// Combine elements and be the first scientists to create fusion.
    /// </summary>
    public class Game : BaseGame
    {
        /// <summary>
        /// The game version hash, used to compare if we are playing the same version on the server.
        /// </summary>
        new protected static string GameVersion = "7c19f909ee5faa0ac3faf4e989032b5a37ba94aeb5d6ae7654a15a2bb1401bbe";

        #region Properties
        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Newtonian.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The maximum number of interns a player can have.
        /// </summary>
        public int InternCap { get; protected set; }

        /// <summary>
        /// A list of all jobs. The first element is intern, second is physicists, and third is manager.
        /// </summary>
        public IList<Newtonian.Job> Jobs { get; protected set; }

        /// <summary>
        /// Every Machine in the game.
        /// </summary>
        public IList<Newtonian.Machine> Machines { get; protected set; }

        /// <summary>
        /// The maximum number of managers a player can have.
        /// </summary>
        public int ManagerCap { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the y (vertical) axis.
        /// </summary>
        public int MapHeight { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the x (horizontal) axis.
        /// </summary>
        public int MapWidth { get; protected set; }

        /// <summary>
        /// The number of materials that spawn per spawn cycle.
        /// </summary>
        public int MaterialSpawn { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The maximum number of physicists a player can have.
        /// </summary>
        public int PhysicistCap { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Newtonian.Player> Players { get; protected set; }

        /// <summary>
        /// The amount of victory points added when a refined ore is consumed by the generator.
        /// </summary>
        public int RefinedValue { get; protected set; }

        /// <summary>
        /// The percent of max HP regained when a unit end their turn on a tile owned by their player.
        /// </summary>
        public double RegenerateRate { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The amount of turns it takes a unit to spawn.
        /// </summary>
        public int SpawnTime { get; protected set; }

        /// <summary>
        /// The amount of turns a unit cannot do anything when stunned.
        /// </summary>
        public int StunTime { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Newtonian.Tile> Tiles { get; protected set; }

        /// <summary>
        /// The amount of time (in nano-seconds) added after each player performs a turn.
        /// </summary>
        public int TimeAddedPerTurn { get; protected set; }

        /// <summary>
        /// The number turns a unit is immune to being stunned.
        /// </summary>
        public int TimeImmune { get; protected set; }

        /// <summary>
        /// Every Unit in the game.
        /// </summary>
        public IList<Newtonian.Unit> Units { get; protected set; }

        /// <summary>
        /// The amount of combined heat and pressure that you need to win.
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
            this.Name = "Newtonian";

            this.Jobs = new List<Newtonian.Job>();
            this.Machines = new List<Newtonian.Machine>();
            this.Players = new List<Newtonian.Player>();
            this.Tiles = new List<Newtonian.Tile>();
            this.Units = new List<Newtonian.Unit>();
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
