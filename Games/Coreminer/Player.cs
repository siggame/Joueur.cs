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
        /// The bombs stored in the Player's supply.
        /// </summary>
        public int Bombs { get; protected set; }

        /// <summary>
        /// The building material stored in the Player's supply.
        /// </summary>
        public int BuildingMaterials { get; protected set; }

        /// <summary>
        /// What type of client this is, e.g. 'Python', 'JavaScript', or some other language. For potential data mining purposes.
        /// </summary>
        public string ClientType { get; protected set; }

        /// <summary>
        /// The dirt stored in the Player's supply.
        /// </summary>
        public int Dirt { get; protected set; }

        /// <summary>
        /// The Tiles this Player's hoppers are on.
        /// </summary>
        public IList<Coreminer.Tile> HopperTiles { get; protected set; }

        /// <summary>
        /// If the player lost the game or not.
        /// </summary>
        public bool Lost { get; protected set; }

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
        /// The Tiles on this Player's side of the map.
        /// </summary>
        public IList<Coreminer.Tile> Side { get; protected set; }

        /// <summary>
        /// The Tiles this Player may spawn Units on.
        /// </summary>
        public IList<Coreminer.Tile> SpawnTiles { get; protected set; }

        /// <summary>
        /// The amount of time (in ns) remaining for this AI to send commands.
        /// </summary>
        public double TimeRemaining { get; protected set; }

        /// <summary>
        /// Every Unit owned by this Player.
        /// </summary>
        public IList<Coreminer.Unit> Units { get; protected set; }

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
            this.HopperTiles = new List<Coreminer.Tile>();
            this.Side = new List<Coreminer.Tile>();
            this.SpawnTiles = new List<Coreminer.Tile>();
            this.Units = new List<Coreminer.Unit>();
        }

        /// <summary>
        /// Purchases a resource and adds it to the Player's supply.
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
        /// Transfers a resource from the Player's supply to a Unit.
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



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
