// A beaver in the game.

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

namespace Joueur.cs.Games.Stumped
{
    /// <summary>
    /// A beaver in the game.
    /// </summary>
    class Beaver : Stumped.GameObject
    {
        #region Properties
        /// <summary>
        /// The number of actions remaining for the beaver this turn.
        /// </summary>
        public int Actions { get; protected set; }

        /// <summary>
        /// The number of branches this beaver is holding.
        /// </summary>
        public int Branches { get; protected set; }

        /// <summary>
        /// Number of turns this beaver is distracted for (0 means not distracted).
        /// </summary>
        public int Distracted { get; protected set; }

        /// <summary>
        /// The number of fish this beaver is holding.
        /// </summary>
        public int Fish { get; protected set; }

        /// <summary>
        /// How much health this beaver has left.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// The Job this beaver was recruited to do.
        /// </summary>
        public Stumped.Job Job { get; protected set; }

        /// <summary>
        /// How many moves this beaver has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this beaver.
        /// </summary>
        public Stumped.Player Owner { get; protected set; }

        /// <summary>
        /// The tile this beaver is on.
        /// </summary>
        public Stumped.Tile Tile { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
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
        /// <param name="tile">The tile of the beaver you want to attack.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Stumped.Tile tile)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Builds a lodge on the Beavers current tile.
        /// </summary>
        /// <returns>True if successfully built a lodge, false otherwise.</returns>
        public bool BuildLodge()
        {
            return this.RunOnServer<bool>("buildLodge", new Dictionary<string, object> {
            });
        }

        /// <summary>
        /// Drops some of the given resource on the beaver's tile. Fish dropped in water disappear instantly, and fish dropped on land die one per tile per turn.
        /// </summary>
        /// <param name="resource">The type of resource to drop ('branch' or 'fish').</param>
        /// <param name="amount">The amount of the resource to drop, numbers <= 0 will drop all of that type.</param>
        /// <returns>True if successfully dropped the resource, false otherwise.</returns>
        public bool Drop(string resource, int amount=0)
        {
            return this.RunOnServer<bool>("drop", new Dictionary<string, object> {
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Harvests the branches or fish from a Spawner on an adjacent tile.
        /// </summary>
        /// <param name="tile">The tile you want to harvest.</param>
        /// <returns>True if successfully harvested, false otherwise.</returns>
        public bool Harvest(Stumped.Tile tile)
        {
            return this.RunOnServer<bool>("harvest", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Moves this beaver from its current tile to an adjacent tile.
        /// </summary>
        /// <param name="tile">The tile this beaver should move to. Costs 2 moves normally, 3 if moving upstream, and 1 if moving downstream.</param>
        /// <returns>True if the move worked, false otherwise.</returns>
        public bool Move(Stumped.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Picks up some branches or fish on the beaver's tile.
        /// </summary>
        /// <param name="resource">The type of resource to pickup ('branch' or 'fish').</param>
        /// <param name="amount">The amount of the resource to drop, numbers <= 0 will pickup all of that type.</param>
        /// <returns>True if successfully picked up a resource, false otherwise.</returns>
        public bool Pickup(string resource, int amount=0)
        {
            return this.RunOnServer<bool>("pickup", new Dictionary<string, object> {
                {"resource", resource},
                {"amount", amount}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
