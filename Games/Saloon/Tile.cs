// A Tile in the game that makes up the 2D map grid.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add addtional using(s) here
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Saloon
{
    /// <summary>
    /// A Tile in the game that makes up the 2D map grid.
    /// </summary>
    class Tile : Saloon.GameObject
    {
        #region Properties
        /// <summary>
        /// The beer Bottle currently flying over this Tile.
        /// </summary>
        public Saloon.Bottle Bottle { get; protected set; }

        /// <summary>
        /// The Cowboy that is on this Tile, or null if empty.
        /// </summary>
        public Saloon.Cowboy Cowboy { get; protected set; }

        /// <summary>
        /// The furnishing that is on this Tile, or null if empty.
        /// </summary>
        public Saloon.Furnishing Furnishing { get; protected set; }

        /// <summary>
        /// If this Tile is pathable, but has a hazard that damages Cowboys that path through it.
        /// </summary>
        public bool HasHazard { get; protected set; }

        /// <summary>
        /// If this Tile is a wall of the Saloon, and can never be pathed through.
        /// </summary>
        public bool IsWall { get; protected set; }

        /// <summary>
        /// The Tile to the 'East' of this one (x+1, y). Null if out of bounds of the map.
        /// </summary>
        public Saloon.Tile TileEast { get; protected set; }

        /// <summary>
        /// The Tile to the 'North' of this one (x, y-1). Null if out of bounds of the map.
        /// </summary>
        public Saloon.Tile TileNorth { get; protected set; }

        /// <summary>
        /// The Tile to the 'South' of this one (x, y+1). Null if out of bounds of the map.
        /// </summary>
        public Saloon.Tile TileSouth { get; protected set; }

        /// <summary>
        /// The Tile to the 'West' of this one (x-1, y). Null if out of bounds of the map.
        /// </summary>
        public Saloon.Tile TileWest { get; protected set; }

        /// <summary>
        /// The x (horizontal) position of this Tile.
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// The y (vertical) position of this Tile.
        /// </summary>
        public int Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Tile. Used during game initialization, do not call directly.
        /// </summary>
        protected Tile() : base()
        {
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
