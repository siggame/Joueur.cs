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

namespace Joueur.cs.Games.Necrowar
{
    /// <summary>
    /// A Tile in the game that makes up the 2D map grid.
    /// </summary>
    public class Tile : Necrowar.GameObject
    {
        #region Properties
        /// <summary>
        /// The amount of corpses on this tile.
        /// </summary>
        public int Corpses { get; protected set; }

        /// <summary>
        /// Whether or not the tile is a castle tile.
        /// </summary>
        public bool IsCastle { get; protected set; }

        /// <summary>
        /// Whether or not the tile is considered to be a gold mine or not.
        /// </summary>
        public bool IsGoldMine { get; protected set; }

        /// <summary>
        /// Whether or not the tile is considered grass or not (Workers can walk on grass).
        /// </summary>
        public bool IsGrass { get; protected set; }

        /// <summary>
        /// Whether or not the tile is considered to be the island gold mine or not.
        /// </summary>
        public bool IsIslandGoldMine { get; protected set; }

        /// <summary>
        /// Whether or not the tile is considered a path or not (Units can walk on paths).
        /// </summary>
        public bool IsPath { get; protected set; }

        /// <summary>
        /// Whether or not the tile is considered a river or not.
        /// </summary>
        public bool IsRiver { get; protected set; }

        /// <summary>
        /// Whether or not the tile is considered a tower or not.
        /// </summary>
        public bool IsTower { get; protected set; }

        /// <summary>
        /// Whether or not the tile is the unit spawn.
        /// </summary>
        public bool IsUnitSpawn { get; protected set; }

        /// <summary>
        /// Whether or not the tile can be moved on by workers.
        /// </summary>
        public bool IsWall { get; protected set; }

        /// <summary>
        /// Whether or not the tile is the worker spawn.
        /// </summary>
        public bool IsWorkerSpawn { get; protected set; }

        /// <summary>
        /// The amount of Ghouls on this tile.
        /// </summary>
        public int NumGhouls { get; protected set; }

        /// <summary>
        /// The amount of Hounds on this tile.
        /// </summary>
        public int NumHounds { get; protected set; }

        /// <summary>
        /// The amount of Zombies on this tile.
        /// </summary>
        public int NumZombies { get; protected set; }

        /// <summary>
        /// Which player owns this tile, only applies to grass tiles for workers, NULL otherwise.
        /// </summary>
        public Necrowar.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile to the 'East' of this one (x+1, y). Null if out of bounds of the map.
        /// </summary>
        public Necrowar.Tile TileEast { get; protected set; }

        /// <summary>
        /// The Tile to the 'North' of this one (x, y-1). Null if out of bounds of the map.
        /// </summary>
        public Necrowar.Tile TileNorth { get; protected set; }

        /// <summary>
        /// The Tile to the 'South' of this one (x, y+1). Null if out of bounds of the map.
        /// </summary>
        public Necrowar.Tile TileSouth { get; protected set; }

        /// <summary>
        /// The Tile to the 'West' of this one (x-1, y). Null if out of bounds of the map.
        /// </summary>
        public Necrowar.Tile TileWest { get; protected set; }

        /// <summary>
        /// The Tower on this Tile if present, otherwise null.
        /// </summary>
        public Necrowar.Tower Tower { get; protected set; }

        /// <summary>
        /// The Unit on this Tile if present, otherwise null.
        /// </summary>
        public Necrowar.Unit Unit { get; protected set; }

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
        /// Resurrect the corpses on this tile into Zombies.
        /// </summary>
        /// <param name="num">Number of zombies to resurrect.</param>
        /// <returns>True if successful res, false otherwise.</returns>
        public bool Res(int num)
        {
            return this.RunOnServer<bool>("res", new Dictionary<string, object> {
                {"num", num}
            });
        }

        /// <summary>
        /// Spawns a fighting unit on the correct tile.
        /// </summary>
        /// <param name="title">The title of the desired unit type.</param>
        /// <returns>True if successfully spawned, false otherwise.</returns>
        public bool SpawnUnit(string title)
        {
            return this.RunOnServer<bool>("spawnUnit", new Dictionary<string, object> {
                {"title", title}
            });
        }

        /// <summary>
        /// Spawns a worker on the correct tile.
        /// </summary>
        /// <returns>True if successfully spawned, false otherwise.</returns>
        public bool SpawnWorker()
        {
            return this.RunOnServer<bool>("spawnWorker", new Dictionary<string, object> {
            });
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
            // DEVELOPER ADD LOGIC HERE
            if (this.IsPath && this.Unit == null && !this.IsTower)
                return true;
            return false;
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
        public bool IsPathableWorker()
        {
            return !(this.IsRiver || this.IsUnitSpawn || this.IsWall || this.Unit != null);
        }
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
