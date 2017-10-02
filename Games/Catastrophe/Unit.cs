// A unit in the game.

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
    /// A unit in the game.
    /// </summary>
    class Unit : Catastrophe.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether this unit has performed its action this turn.
        /// </summary>
        public bool Acted { get; protected set; }

        /// <summary>
        /// The amount of energy this unit has (from 0.0 to 1.0).
        /// </summary>
        public double Energy { get; protected set; }

        /// <summary>
        /// The amount of food this Unit is holding.
        /// </summary>
        public int Food { get; protected set; }

        /// <summary>
        /// The Job this Unit was recruited to do.
        /// </summary>
        public Catastrophe.Job Job { get; protected set; }

        /// <summary>
        /// The amount of materials this Unit is holding.
        /// </summary>
        public int Materials { get; protected set; }

        /// <summary>
        /// The tile this Unit is moving to. This only applies to neutral fresh humans spawned on the road.
        /// </summary>
        public Catastrophe.Tile MovementTarget { get; protected set; }

        /// <summary>
        /// How many moves this Unit has left this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit, or null if the unit is neutral.
        /// </summary>
        public Catastrophe.Player Owner { get; protected set; }

        /// <summary>
        /// The units in the same squad as this unit. Units in the same squad attack and defend together.
        /// </summary>
        public IList<Catastrophe.Unit> Squad { get; protected set; }

        /// <summary>
        /// Whether this unit is starving. Starving units regenerate energy at half the rate they normally would while resting.
        /// </summary>
        public bool Starving { get; protected set; }

        /// <summary>
        /// The Tile this Unit is on.
        /// </summary>
        public Catastrophe.Tile Tile { get; protected set; }

        /// <summary>
        /// The number of turns before this Unit dies. This only applies to neutral fresh humans created from combat.
        /// </summary>
        public int TurnsToDie { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Unit. Used during game initialization, do not call directly.
        /// </summary>
        protected Unit() : base()
        {
            this.Squad = new List<Catastrophe.Unit>();
        }

        /// <summary>
        /// Attacks an adjacent tile. Costs an action for each unit in this squad. Units in this squad without an action don't participate in combat. Units in the squad cannot move after performing this action.
        /// </summary>
        /// <param name="tile">The Tile to attack.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Catastrophe.Tile tile)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Changes this Unit's Job. Must be at max energy (1.0) to change Jobs.
        /// </summary>
        /// <param name="job">The Job to change to.</param>
        /// <returns>True if successfully changed Jobs, false otherwise.</returns>
        public bool ChangeJob(Catastrophe.Job job)
        {
            return this.RunOnServer<bool>("changeJob", new Dictionary<string, object> {
                {"job", job}
            });
        }

        /// <summary>
        /// Constructs a structure on an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile to construct the structure on. It must have enough materials on it for a structure to be constructed.</param>
        /// <param name="type">The type of structure to construct on that tile.</param>
        /// <returns>True if successfully constructed a structure, false otherwise.</returns>
        public bool Construct(Catastrophe.Tile tile, string type)
        {
            return this.RunOnServer<bool>("construct", new Dictionary<string, object> {
                {"tile", tile},
                {"type", type}
            });
        }

        /// <summary>
        /// Converts an adjacent Unit to your side.
        /// </summary>
        /// <param name="tile">The Tile with the Unit to convert.</param>
        /// <returns>True if successfully converted, false otherwise.</returns>
        public bool Convert(Catastrophe.Tile tile)
        {
            return this.RunOnServer<bool>("convert", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Removes materials from an adjacent Tile's Structure. Soldiers do not gain materials from doing this, but can deconstruct friendly Structures as well.
        /// </summary>
        /// <param name="tile">The Tile to deconstruct. It must have a Structure on it.</param>
        /// <returns>True if successfully deconstructed, false otherwise.</returns>
        public bool Deconstruct(Catastrophe.Tile tile)
        {
            return this.RunOnServer<bool>("deconstruct", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Drops some of the given resource on or adjacent to the unit's Tile. Does not count as an action.
        /// </summary>
        /// <param name="tile">The Tile to drop materials/food on.</param>
        /// <param name="resource">The type of resource to drop ('material' or 'food').</param>
        /// <param name="amount">The amount of the resource to drop, numbers &lt;= 0 will drop all of the resource.</param>
        /// <returns>True if successfully dropped the resource, false otherwise.</returns>
        public bool Drop(Catastrophe.Tile tile, string resource, int amount=0)
        {
            return this.RunOnServer<bool>("drop", new Dictionary<string, object> {
                {"tile", tile},
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Harvests the food on an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile you want to harvest.</param>
        /// <returns>True if successfully harvested, false otherwise.</returns>
        public bool Harvest(Catastrophe.Tile tile)
        {
            return this.RunOnServer<bool>("harvest", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Moves this Unit from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Unit should move to.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(Catastrophe.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Picks up some materials or food on or adjacent to the unit's tile. Does not count as an action.
        /// </summary>
        /// <param name="tile">The Tile to pickup materials/food from.</param>
        /// <param name="resource">The type of resource to pickup ('material' or 'food').</param>
        /// <param name="amount">The amount of the resource to pickup, numbers &lt;= 0 will pickup all of the resource possible.</param>
        /// <returns>True if successfully picked up a resource, false otherwise.</returns>
        public bool Pickup(Catastrophe.Tile tile, string resource, int amount=0)
        {
            return this.RunOnServer<bool>("pickup", new Dictionary<string, object> {
                {"tile", tile},
                {"resource", resource},
                {"amount", amount}
            });
        }

        /// <summary>
        /// Regenerates energy. Must be in range of a friendly shelter to rest. Unit cannot move after performing this action.
        /// </summary>
        /// <returns>True if successfully rested, false otherwise.</returns>
        public bool Rest()
        {
            return this.RunOnServer<bool>("rest", new Dictionary<string, object> {
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
