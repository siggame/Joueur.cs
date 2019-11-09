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

namespace Joueur.cs.Games.Necrowar
{
    /// <summary>
    /// A player in this game. Every AI controls one player.
    /// </summary>
    public class Player : Necrowar.GameObject
    {
        #region Properties
        /// <summary>
        /// What type of client this is, e.g. 'Python', 'JavaScript', or some other language. For potential data mining purposes.
        /// </summary>
        public string ClientType { get; protected set; }

        /// <summary>
        /// The amount of gold this Player has.
        /// </summary>
        public int Gold { get; protected set; }

        /// <summary>
        /// The amount of health remaining for this player's main unit.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The tile that the home base is located on.
        /// </summary>
        public IList<Necrowar.Tile> HomeBase { get; protected set; }

        /// <summary>
        /// If the player lost the game or not.
        /// </summary>
        public bool Lost { get; protected set; }

        /// <summary>
        /// The amount of mana this player has.
        /// </summary>
        public int Mana { get; protected set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// This player's opponent in the game.
        /// </summary>
        public Necrowar.Player Opponent { get; protected set; }

        /// <summary>
        /// The reason why the player lost the game.
        /// </summary>
        public string ReasonLost { get; protected set; }

        /// <summary>
        /// The reason why the player won the game.
        /// </summary>
        public string ReasonWon { get; protected set; }

        /// <summary>
        /// All tiles that this player can build on and move workers on.
        /// </summary>
        public IList<Necrowar.Tile> Side { get; protected set; }

        /// <summary>
        /// The amount of time (in ns) remaining for this AI to send commands.
        /// </summary>
        public double TimeRemaining { get; protected set; }

        /// <summary>
        /// Every Tower owned by this player.
        /// </summary>
        public IList<Necrowar.Tower> Towers { get; protected set; }

        /// <summary>
        /// Every Unit owned by this Player.
        /// </summary>
        public IList<Necrowar.Unit> Units { get; protected set; }

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
            this.HomeBase = new List<Necrowar.Tile>();
            this.Side = new List<Necrowar.Tile>();
            this.Towers = new List<Necrowar.Tower>();
            this.Units = new List<Necrowar.Unit>();
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
