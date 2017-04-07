// Gather branches and build up your lodge as beavers fight to survive.

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

namespace Joueur.cs.Games.Stumped
{
    /// <summary>
    /// Gather branches and build up your lodge as beavers fight to survive.
    /// </summary>
    class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// Every Beaver in the game.
        /// </summary>
        public IList<Stumped.Beaver> Beavers { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Stumped.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// When a Player has less Beavers than this number, then recruiting other Beavers is free.
        /// </summary>
        public int FreeBeaversCount { get; protected set; }

        /// <summary>
        /// All the Jobs that Beavers can have in the game.
        /// </summary>
        public IList<Stumped.Job> Jobs { get; protected set; }

        /// <summary>
        /// Constant number used to calculate what it costs to spawn a new lodge.
        /// </summary>
        public double LodgeCostConstant { get; protected set; }

        /// <summary>
        /// How many lodges must be owned by a Player at once to win the game.
        /// </summary>
        public int LodgesToWin { get; protected set; }

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
        /// List of all the players in the game.
        /// </summary>
        public IList<Stumped.Player> Players { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// Every Spawner in the game.
        /// </summary>
        public IList<Stumped.Spawner> Spawner { get; protected set; }

        /// <summary>
        /// Constant number used to calculate how many branches/food Beavers harvest from Spawners.
        /// </summary>
        public double SpawnerHarvestConstant { get; protected set; }

        /// <summary>
        /// All the types of Spawners in the game.
        /// </summary>
        public IList<string> SpawnerTypes { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Stumped.Tile> Tiles { get; protected set; }


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
            this.Name = "Stumped";

            this.Beavers = new List<Stumped.Beaver>();
            this.Jobs = new List<Stumped.Job>();
            this.Players = new List<Stumped.Player>();
            this.Spawner = new List<Stumped.Spawner>();
            this.SpawnerTypes = new List<string>();
            this.Tiles = new List<Stumped.Tile>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
