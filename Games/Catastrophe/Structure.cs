// A structure on a Tile.

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

namespace Joueur.cs.Games.Catastrophe
{
    /// <summary>
    /// A structure on a Tile.
    /// </summary>
    public class Structure : Catastrophe.GameObject
    {
        #region Properties
        /// <summary>
        /// The range of this Structure's effect. For example, a radius of 1 means this Structure affects a 3x3 square centered on this Structure.
        /// </summary>
        public int EffectRadius { get; protected set; }

        /// <summary>
        /// The number of materials in this Structure. Once this number reaches 0, this Structure is destroyed.
        /// </summary>
        public int Materials { get; protected set; }

        /// <summary>
        /// The owner of this Structure if any, otherwise null.
        /// </summary>
        public Catastrophe.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile this Structure is on.
        /// </summary>
        public Catastrophe.Tile Tile { get; protected set; }

        /// <summary>
        /// The type of Structure this is ('shelter', 'monument', 'wall', 'road').
        /// </summary>
        public string Type { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Structure. Used during game initialization, do not call directly.
        /// </summary>
        protected Structure() : base()
        {
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
