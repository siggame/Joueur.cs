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
        /// Determins the rate at which the highest value victory points degrade.
        /// </summary>
        public double DegradeRate { get; protected set; }

        /// <summary>
        /// How many interns a player can have.
        /// </summary>
        public int InternCap { get; protected set; }

        /// <summary>
        /// Every job in the game.
        /// </summary>
        public IList<Newtonian.Job> Jobs { get; protected set; }

        /// <summary>
        /// Every Machine in the game.
        /// </summary>
        public IList<Newtonian.Machine> Machines { get; protected set; }

        /// <summary>
        /// How many managers a player can have.
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
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// How many physicists a player can have.
        /// </summary>
        public int PhysicistCap { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Newtonian.Player> Players { get; protected set; }

        /// <summary>
        /// How much each refined ore adds when put in the generator.
        /// </summary>
        public int RefinedValue { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The number of turns between spawning unit waves.
        /// </summary>
        public int SpawnTime { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Newtonian.Tile> Tiles { get; protected set; }

        /// <summary>
        /// The amount of time (in nano-seconds) added after each player performs a turn.
        /// </summary>
        public int TimeAddedPerTurn { get; protected set; }

        /// <summary>
        /// Every Unit in the game.
        /// </summary>
        public IList<Newtonian.Unit> Units { get; protected set; }


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
