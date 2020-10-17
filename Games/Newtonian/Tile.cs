// A Tile in the game that makes up the 2D map grid.

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

namespace Joueur.cs.Games.Newtonian
{
    /// <summary>
    /// A Tile in the game that makes up the 2D map grid.
    /// </summary>
    public class Tile : Newtonian.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of blueium on this tile.
        /// </summary>
        public int Blueium { get; protected set; }

        /// <summary>
        /// The amount of blueium ore on this tile.
        /// </summary>
        public int BlueiumOre { get; protected set; }

        /// <summary>
        /// (Visualizer only) Different tile types, cracked, slightly dirty, etc. This has no effect on gameplay, but feel free to use it if you want.
        /// </summary>
        public int Decoration { get; protected set; }

        /// <summary>
        /// The direction of a conveyor belt ('blank', 'north', 'east', 'south', or 'west'). Blank means conveyor doesn't move.
        /// </summary>
        public string Direction { get; protected set; }

        /// <summary>
        /// Whether or not the tile is a wall.
        /// </summary>
        public bool IsWall { get; protected set; }

        /// <summary>
        /// The Machine on this Tile if present, otherwise null.
        /// </summary>
        public Newtonian.Machine Machine { get; protected set; }

        /// <summary>
        /// The owner of this Tile, or null if owned by no-one. Only for generators and spawn areas.
        /// </summary>
        public Newtonian.Player Owner { get; protected set; }

        /// <summary>
        /// The amount of redium on this tile.
        /// </summary>
        public int Redium { get; protected set; }

        /// <summary>
        /// The amount of redium ore on this tile.
        /// </summary>
        public int RediumOre { get; protected set; }

        /// <summary>
        /// The Tile to the 'East' of this one (x+1, y). Null if out of bounds of the map.
        /// </summary>
        public Newtonian.Tile TileEast { get; protected set; }

        /// <summary>
        /// The Tile to the 'North' of this one (x, y-1). Null if out of bounds of the map.
        /// </summary>
        public Newtonian.Tile TileNorth { get; protected set; }

        /// <summary>
        /// The Tile to the 'South' of this one (x, y+1). Null if out of bounds of the map.
        /// </summary>
        public Newtonian.Tile TileSouth { get; protected set; }

        /// <summary>
        /// The Tile to the 'West' of this one (x-1, y). Null if out of bounds of the map.
        /// </summary>
        public Newtonian.Tile TileWest { get; protected set; }

        /// <summary>
        /// The type of Tile this is ('normal', 'generator', 'conveyor', or 'spawn').
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// The Unit on this Tile if present, otherwise null.
        /// </summary>
        public Newtonian.Unit Unit { get; protected set; }

        /// <summary>
        /// The x (horizontal) position of this Tile.
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// The y (vertical) position of this Tile.
        /// </summary>
        public int Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Tile. Used during game initialization, do not call directly.
        /// </summary>
        protected Tile() : base()
        {
        }


        /// <summary>
        /// Gets the neighbors of this Tile
        /// </summary>
        /// <returns>The neighboring (adjacent) Tiles to this tile</returns>
        public List<Tile> GetNeighbors()
        {
            var list = new List<Tile>();

            if (this.TileNorth != null)
            {
                list.Add(this.TileNorth);
            }

            if (this.TileEast != null)
            {
                list.Add(this.TileEast);
            }

            if (this.TileSouth != null)
            {
                list.Add(this.TileSouth);
            }

            if (this.TileWest != null)
            {
                list.Add(this.TileWest);
            }

            return list;
        }

        /// <summary>
        /// Checks if a Tile is pathable to units
        /// </summary>
        /// <returns>True if pathable, false otherwise</returns>
        public bool IsPathable()
        {
            // <<-- Creer-Merge: is_pathable_builtin -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            return false; // DEVELOPER ADD LOGIC HERE
            // <<-- /Creer-Merge: is_pathable_builtin -->>
        }

        /// <summary>
        /// Checks if this Tile has a specific neighboring Tile
        /// </summary>
        /// <param name="tile">Tile to check against</param>
        /// <returns>true if the tile is a neighbor of this Tile, false otherwise</returns>
        public bool HasNeighbor(Tile tile)
        {
            if (tile == null)
            {
                return false;
            }

            return this.TileNorth == tile || this.TileEast == tile || this.TileSouth == tile || this.TileWest == tile;
        }

        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
