// Convert as many humans to as you can to survive in this post-apocalyptic wasteland.

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
    /// Convert as many humans to as you can to survive in this post-apocalyptic wasteland.
    /// </summary>
    public class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// The multiplier for the amount of energy regenerated when resting in a shelter with the cat overlord.
        /// </summary>
        public double CatEnergyMult { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Catastrophe.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The amount of turns it takes for a Tile that was just harvested to grow food again.
        /// </summary>
        public int HarvestCooldown { get; protected set; }

        /// <summary>
        /// All the Jobs that Units can have in the game.
        /// </summary>
        public IList<Catastrophe.Job> Jobs { get; protected set; }

        /// <summary>
        /// The amount that the harvest rate is lowered each season.
        /// </summary>
        public int LowerHarvestAmount { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the y (vertical) axis.
        /// </summary>
        public int MapHeight { get; protected set; }

        /// <summary>
        /// The number of Tiles in the map along the x (horizontal) axis.
        /// </summary>
        public int MapWidth { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The multiplier for the cost of actions when performing them in range of a monument. Does not effect pickup cost.
        /// </summary>
        public double MonumentCostMult { get; protected set; }

        /// <summary>
        /// The number of materials in a monument.
        /// </summary>
        public int MonumentMaterials { get; protected set; }

        /// <summary>
        /// The number of materials in a neutral Structure.
        /// </summary>
        public int NeutralMaterials { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Catastrophe.Player> Players { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The number of materials in a shelter.
        /// </summary>
        public int ShelterMaterials { get; protected set; }

        /// <summary>
        /// The multiplier for the amount of energy regenerated when resting while starving.
        /// </summary>
        public double StarvingEnergyMult { get; protected set; }

        /// <summary>
        /// Every Structure in the game.
        /// </summary>
        public IList<Catastrophe.Structure> Structures { get; protected set; }

        /// <summary>
        /// All the tiles in the map, stored in Row-major order. Use `x + y * mapWidth` to access the correct index.
        /// </summary>
        public IList<Catastrophe.Tile> Tiles { get; protected set; }

        /// <summary>
        /// After a food tile is harvested, the number of turns before it can be harvested again.
        /// </summary>
        public int TurnsBetweenHarvests { get; protected set; }

        /// <summary>
        /// The number of turns between fresh humans being spawned on the road.
        /// </summary>
        public int TurnsToCreateHuman { get; protected set; }

        /// <summary>
        /// The number of turns before the harvest rate is lowered (length of each season basically).
        /// </summary>
        public int TurnsToLowerHarvest { get; protected set; }

        /// <summary>
        /// Every Unit in the game.
        /// </summary>
        public IList<Catastrophe.Unit> Units { get; protected set; }

        /// <summary>
        /// The number of materials in a wall.
        /// </summary>
        public int WallMaterials { get; protected set; }


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
            this.Name = "Catastrophe";

            this.Jobs = new List<Catastrophe.Job>();
            this.Players = new List<Catastrophe.Player>();
            this.Structures = new List<Catastrophe.Structure>();
            this.Tiles = new List<Catastrophe.Tile>();
            this.Units = new List<Catastrophe.Unit>();
        }


        /// <summary>
        /// Gets the Tile at a specified (x, y) position
        /// </summary>
        /// <param name="x">integer between 0 and the MapWidth</param>
        /// <param name="y">integer between 0 and the MapHeight</param>
        /// <returns>the Tile at (x, y) or null if out of bounds</returns>
        public Tile GetTileAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.MapWidth || y >= this.MapHeight)
            {
                // out of bounds
                return null;
            }

            return this.Tiles[x + y * this.MapWidth];
        }

        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
