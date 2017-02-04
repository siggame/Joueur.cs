// A location (node) connected to other Nests via Webs (edges) in the game that Spiders can converge on, regardless of owner.

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

namespace Joueur.cs.Games.Spiders
{
    /// <summary>
    /// A location (node) connected to other Nests via Webs (edges) in the game that Spiders can converge on, regardless of owner.
    /// </summary>
    class Nest : Spiders.GameObject
    {
        #region Properties
        /// <summary>
        /// All the Spiders currently located on this Nest.
        /// </summary>
        public IList<Spiders.Spider> Spiders { get; protected set; }

        /// <summary>
        /// Webs that connect to this Nest.
        /// </summary>
        public IList<Spiders.Web> Webs { get; protected set; }

        /// <summary>
        /// The X coordinate of the Nest. Used for distance calculations.
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// The Y coordinate of the Nest. Used for distance calculations.
        /// </summary>
        public int Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Nest. Used during game initialization, do not call directly.
        /// </summary>
        protected Nest() : base()
        {
            this.Spiders = new List<Spiders.Spider>();
            this.Webs = new List<Spiders.Web>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
