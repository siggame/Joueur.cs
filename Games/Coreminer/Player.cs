// A player in this game. Every AI controls one player.

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
    /// A player in this game. Every AI controls one player.
    /// </summary>
    public class Player : Coreminer.GameObject
    {
        #region Properties
        /// <summary>
        /// The Tile this Player's base is on.
        /// </summary>
        public Coreminer.Tile BaseTile { get; protected set; }

        /// <summary>
        /// Every Bomb owned by this Player.
        /// </summary>
        public IList<Coreminer.Bomb> Bombs { get; protected set; }

        /// <summary>
        /// What type of client this is, e.g. 'Python', 'JavaScript', or some other language. For potential data mining purposes.
        /// </summary>
        public string ClientType { get; protected set; }

        /// <summary>
        /// The Tiles this Player's hoppers are on.
        /// </summary>
        public IList<Coreminer.Tile> HopperTiles { get; protected set; }

        /// <summary>
        /// If the player lost the game or not.
        /// </summary>
        public bool Lost { get; protected set; }

        /// <summary>
        /// Every Miner owned by this Player.
        /// </summary>
        public IList<Coreminer.Miner> Miners { get; protected set; }

        /// <summary>
        /// The amount of money this Player currently has.
        /// </summary>
        public int Money { get; protected set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// This player's opponent in the game.
        /// </summary>
        public Coreminer.Player Opponent { get; protected set; }

        /// <summary>
        /// The reason why the player lost the game.
        /// </summary>
        public string ReasonLost { get; protected set; }

        /// <summary>
        /// The reason why the player won the game.
        /// </summary>
        public string ReasonWon { get; protected set; }

        /// <summary>
        /// The amount of time (in ns) remaining for this AI to send commands.
        /// </summary>
        public double TimeRemaining { get; protected set; }

        /// <summary>
        /// The amount of value (victory points) this Player has gained.
        /// </summary>
        public int Value { get; protected set; }

        /// <summary>
        /// If the player won the game or not.
        /// </summary>
        public bool Won { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Player. Used during game initialization, do not call directly.
        /// </summary>
        protected Player() : base()
        {
            this.Bombs = new List<Coreminer.Bomb>();
            this.HopperTiles = new List<Coreminer.Tile>();
            this.Miners = new List<Coreminer.Miner>();
        }

        /// <summary>
        /// Spawns a Miner on this Player's base Tile.
        /// </summary>
        /// <returns>True if successfully spawned, false otherwise.</returns>
        public bool SpawnMiner()
        {
            return this.RunOnServer<bool>("spawnMiner", new Dictionary<string, object> {
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
