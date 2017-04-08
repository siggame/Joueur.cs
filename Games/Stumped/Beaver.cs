// A beaver in the game.

// DO NOT MODIFY THIS FILE
// Never try to directly create an instance of this class, or modify its member variables.
// Instead, you should only be reading its variables and calling its functions.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Joueur.cs.Games.Stumped
{
    /// <summary>
    /// A beaver in the game.
    /// </summary>
    class Beaver : Stumped.GameObject
    {
        #region Properties
        /// <summary>
        /// The number of actions remaining for the Beaver this turn.
        /// </summary>
        public int Actions { get; protected set; }

        /// <summary>
        /// The amount of branches this Beaver is holding.
        /// </summary>
        public int Branches { get; protected set; }

        /// <summary>
        /// The amount of food this Beaver is holding.
        /// </summary>
        public int Food { get; protected set; }

        /// <summary>
        /// How much health this Beaver has left.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The Job this Beaver was recruited to do.
        /// </summary>
        public Stumped.Job Job { get; protected set; }

        /// <summary>
        /// How many moves this Beaver has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Beaver.
        /// </summary>
        public Stumped.Player Owner { get; protected set; }

        /// <summary>
        /// True if the Beaver has finished being recruited and can do things, False otherwise.
        /// </summary>
        public bool Recruited { get; protected set; }

        /// <summary>
        /// The Tile this Beaver is on.
        /// </summary>
        public Stumped.Tile Tile { get; protected set; }

        /// <summary>
        /// Number of turns this Beaver is distracted for (0 means not distracted).
        /// </summary>
        public int TurnsDistracted { get; protected set; }



        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Beaver. Used during game initialization, do not call directly.
        /// </summary>
        protected Beaver() : base()
        {
        }

        /// <summary>
        /// Attacks another adjacent beaver.
        /// </summary>
        /// <param name="beaver">The Beaver to attack. Must be on an adjacent Tile.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Stumped.Beaver beaver)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"beaver", beaver}
            });
        }

        /// <summary>
        /// Builds a lodge on the Beavers current Tile.
        /// </summary>
        /// <returns>True if successfully built a lodge, false otherwise.</returns>
        public bool BuildLodge()
        {
            return this.RunOnServer<bool>("buildLodge", new Dictionary<string, object> {
            });
        }

        /// <summary>
        /// Drops some of the given resource on the beaver's Tile.
        /// </summary>
        /// <param name="tile">The Tile to drop branches/food on. Must be the same Tile that the Beaver is on, or an adjacent one.</param>
        /// <param name="resource">The type of resource to drop ('branch' or 'food').</param>
        /// <param name="amount">The amount of the resource to drop, numbers &lt;= 0 will drop all the resource type.</param>
        /// <returns>True if successfully dropped the resource, false otherwise.</returns>
        public bool Drop(Stumped.Tile tile, string resource, int amount=0)
        {
            return this.RunOnServer<bool>("drop", new Dictionary<string, object> {
                {"tile", tile},
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Harvests the branches or food from a Spawner on an adjacent Tile.
        /// </summary>
        /// <param name="spawner">The Spawner you want to harvest. Must be on an adjacent Tile.</param>
        /// <returns>True if successfully harvested, false otherwise.</returns>
        public bool Harvest(Stumped.Spawner spawner)
        {
            return this.RunOnServer<bool>("harvest", new Dictionary<string, object> {
                {"spawner", spawner}
            });
        }

        /// <summary>
        /// Moves this Beaver from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Beaver should move to.</param>
        /// <returns>True if the move worked, false otherwise.</returns>
        public bool Move(Stumped.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Picks up some branches or food on the beaver's tile.
        /// </summary>
        /// <param name="tile">The Tile to pickup branches/food from. Must be the same Tile that the Beaver is on, or an adjacent one.</param>
        /// <param name="resource">The type of resource to pickup ('branch' or 'food').</param>
        /// <param name="amount">The amount of the resource to drop, numbers &lt;= 0 will pickup all of the resource type.</param>
        /// <returns>True if successfully picked up a resource, false otherwise.</returns>
        public bool Pickup(Stumped.Tile tile, string resource, int amount=0)
        {
            return this.RunOnServer<bool>("pickup", new Dictionary<string, object> {
                {"tile", tile},
                {"resource", resource},
                {"amount", amount}
            });
        }




        #endregion
    }
}
