// Use cowboys to have a good time and play some music on a Piano, while brawling with enemy Cowboys.

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

namespace Joueur.cs.Games.Saloon
{
    /// <summary>
    /// Use cowboys to have a good time and play some music on a Piano, while brawling with enemy Cowboys.
    /// </summary>
    class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// How many turns a Bartender will be busy for after throwing a Bottle.
        /// </summary>
        public int BartenderCooldown { get; protected set; }

        /// <summary>
        /// All the beer Bottles currently flying across the saloon in the game.
        /// </summary>
        public IList<Saloon.Bottle> Bottles { get; protected set; }

        /// <summary>
        /// How much damage is applied to neighboring things bit by the Sharpshooter between turns.
        /// </summary>
        public int BrawlerDamage { get; protected set; }

        /// <summary>
        /// Every Cowboy in the game.
        /// </summary>
        public IList<Saloon.Cowboy> Cowboys { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Saloon.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// Every furnishing in the game.
        /// </summary>
        public IList<Saloon.Furnishing> Furnishings { get; protected set; }

        /// <summary>
        /// All the jobs that Cowboys can be called in with.
        /// </summary>
        public IList<string> Jobs { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the y (vertical) axis.
        /// </summary>
        public int MapHeight { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the x (horizontal) axis.
        /// </summary>
        public int MapWidth { get; protected set; }

        /// <summary>
        /// The maximum number of Cowboys a Player can bring into the saloon of each specific job.
        /// </summary>
        public int MaxCowboysPerJob { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Saloon.Player> Players { get; protected set; }

        /// <summary>
        /// When a player's rowdiness reaches or exceeds this number their Cowboys take a collective siesta.
        /// </summary>
        public int RowdinessToSiesta { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// How much damage is applied to things hit by Sharpshooters when they act.
        /// </summary>
        public int SharpshooterDamage { get; protected set; }

        /// <summary>
        /// How long siestas are for a player's team.
        /// </summary>
        public int SiestaLength { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Saloon.Tile> Tiles { get; protected set; }

        /// <summary>
        /// How many turns a Cowboy will be drunk for if a bottle breaks on it.
        /// </summary>
        public int TurnsDrunk { get; protected set; }


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
            this.Name = "Saloon";

            this.Bottles = new List<Saloon.Bottle>();
            this.Cowboys = new List<Saloon.Cowboy>();
            this.Furnishings = new List<Saloon.Furnishing>();
            this.Jobs = new List<string>();
            this.Players = new List<Saloon.Player>();
            this.Tiles = new List<Saloon.Tile>();
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
