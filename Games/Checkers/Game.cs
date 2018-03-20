// The simple version of American Checkers. An 8x8 board with 12 checkers on each side that must move diagonally to the opposing side until kinged.

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
/// The simple version of American Checkers. An 8x8 board with 12 checkers on each side that must move diagonally to the opposing side until kinged.
/// </summary>
namespace Joueur.cs.Games.Checkers
{
    /// <summary>
    /// The simple version of American Checkers. An 8x8 board with 12 checkers on each side that must move diagonally to the opposing side until kinged.
    /// </summary>
    public class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// The height of the board for the Y component of a checker.
        /// </summary>
        public int BoardHeight { get; protected set; }

        /// <summary>
        /// The width of the board for X component of a checker.
        /// </summary>
        public int BoardWidth { get; protected set; }

        /// <summary>
        /// The checker that last moved and must be moved because only one checker can move during each players turn.
        /// </summary>
        public Checkers.Checker CheckerMoved { get; protected set; }

        /// <summary>
        /// If the last checker that moved jumped, meaning it can move again.
        /// </summary>
        public bool CheckerMovedJumped { get; protected set; }

        /// <summary>
        /// All the checkers currently in the game.
        /// </summary>
        public IList<Checkers.Checker> Checkers { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Checkers.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Checkers.Player> Players { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }


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
            this.Name = "Checkers";

            this.Checkers = new List<Checkers.Checker>();
            this.Players = new List<Checkers.Player>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
