// Steal from merchants and become the most infamous pirate.

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

namespace Joueur.cs.Games.Pirates
{
    /// <summary>
    /// Steal from merchants and become the most infamous pirate.
    /// </summary>
    public class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// The rate buried gold increases each turn.
        /// </summary>
        public double BuryInterestRate { get; protected set; }

        /// <summary>
        /// How much gold it costs to construct a single crew.
        /// </summary>
        public int CrewCost { get; protected set; }

        /// <summary>
        /// How much damage crew deal to each other.
        /// </summary>
        public int CrewDamage { get; protected set; }

        /// <summary>
        /// The maximum amount of health a crew member can have.
        /// </summary>
        public int CrewHealth { get; protected set; }

        /// <summary>
        /// The number of moves Units with only crew are given each turn.
        /// </summary>
        public int CrewMoves { get; protected set; }

        /// <summary>
        /// A crew's attack range. Range is circular.
        /// </summary>
        public double CrewRange { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Pirates.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// How much health a Unit recovers when they rest.
        /// </summary>
        public double HealFactor { get; protected set; }

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
        /// How much gold merchant Ports get each turn.
        /// </summary>
        public double MerchantGoldRate { get; protected set; }

        /// <summary>
        /// When a merchant ship spawns, the amount of additional gold it has relative to the Port's investment.
        /// </summary>
        public double MerchantInterestRate { get; protected set; }

        /// <summary>
        /// Every Port in the game. Merchant ports have owner set to null.
        /// </summary>
        public IList<Pirates.Port> MerchantPorts { get; protected set; }

        /// <summary>
        /// The Euclidean distance buried gold must be from the Player's Port to accumulate interest.
        /// </summary>
        public double MinInterestDistance { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Pirates.Player> Players { get; protected set; }

        /// <summary>
        /// How far a Unit can be from a Port to rest. Range is circular.
        /// </summary>
        public double RestRange { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// How much gold it costs to construct a ship.
        /// </summary>
        public int ShipCost { get; protected set; }

        /// <summary>
        /// How much damage ships deal to ships and ports.
        /// </summary>
        public int ShipDamage { get; protected set; }

        /// <summary>
        /// The maximum amount of health a ship can have.
        /// </summary>
        public int ShipHealth { get; protected set; }

        /// <summary>
        /// The number of moves Units with ships are given each turn.
        /// </summary>
        public int ShipMoves { get; protected set; }

        /// <summary>
        /// A ship's attack range. Range is circular.
        /// </summary>
        public double ShipRange { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Pirates.Tile> Tiles { get; protected set; }

        /// <summary>
        /// Every Unit in the game. Merchant units have targetPort set to a port.
        /// </summary>
        public IList<Pirates.Unit> Units { get; protected set; }


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
            this.Name = "Pirates";

            this.MerchantPorts = new List<Pirates.Port>();
            this.Players = new List<Pirates.Player>();
            this.Tiles = new List<Pirates.Tile>();
            this.Units = new List<Pirates.Unit>();
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
