// A checker on the game board.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add addtional using(s) here
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Checkers
{
    /// <summary>
    /// A checker on the game board.
    /// </summary>
    class Checker : Checkers.GameObject
    {
        #region Properties
        /// <summary>
        /// If the checker has been kinged and can move backwards.
        /// </summary>
        public bool Kinged { get; protected set; }

        /// <summary>
        /// The player that controls this Checker.
        /// </summary>
        public Checkers.Player Owner { get; protected set; }

        /// <summary>
        /// The x coordinate of the checker.
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// The y coordinate of the checker.
        /// </summary>
        public int Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Checker. Used during game initialization, do not call directly.
        /// </summary>
        protected Checker() : base()
        {
        }

        /// <summary>
        /// Returns if the checker is owned by your player or not.
        /// </summary>
        /// <returns>True if it is yours, false if it is not yours.</returns>
        public bool IsMine()
        {
            return this.RunOnServer<bool>("isMine", new Dictionary<string, object> {
            });
        }

        /// <summary>
        /// Moves the checker from its current location to the given (x, y).
        /// </summary>
        /// <param name="x">The x coordinate to move to.</param>
        /// <param name="y">The y coordinate to move to.</param>
        /// <returns>Returns the same checker that moved if the move was successful. null otherwise.</returns>
        public Checkers.Checker Move(int x, int y)
        {
            return this.RunOnServer<Checkers.Checker>("move", new Dictionary<string, object> {
                {"x", x},
                {"y", y}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
