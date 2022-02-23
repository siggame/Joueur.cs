// A 7x9 board game with pieces.

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
/// A 7x9 board game with pieces.
/// </summary>
namespace Joueur.cs.Games.Jungle
{
    /// <summary>
    /// A 7x9 board game with pieces.
    /// </summary>
    public class Game : BaseGame
    {
        /// <summary>
        /// The game version hash, used to compare if we are playing the same version on the server.
        /// </summary>
        new protected static string GameVersion = "28f5663518c163e31771d87c52277b0c3f74033d97f89c1a234de5e6a15f6390";

        #region Properties
        /// <summary>
        /// Forsyth-Edwards Notation (fen), a notation that describes the game board state.
        /// </summary>
        public string Fen { get; protected set; }

        /// <summary>
        /// The list of [known] moves that have occurred in the game, in a format. The first element is the first move, with the last element being the most recent.
        /// </summary>
        public IList<string> History { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Jungle.Player> Players { get; protected set; }

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
            this.Name = "Jungle";

            this.History = new List<string>();
            this.Players = new List<Jungle.Player>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
