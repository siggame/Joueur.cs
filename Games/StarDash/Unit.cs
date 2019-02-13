// A unit in the game. May be a corvette, missleboat, martyr, transport, miner.

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

namespace Joueur.cs.Games.StarDash
{
    /// <summary>
    /// A unit in the game. May be a corvette, missleboat, martyr, transport, miner.
    /// </summary>
    public class Unit : StarDash.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether or not this Unit has performed its action this turn.
        /// </summary>
        public bool Acted { get; protected set; }

        /// <summary>
        /// The remaining health of a unit.
        /// </summary>
        public int Energy { get; protected set; }

        /// <summary>
        /// The amount of Generium ore carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int Genarium { get; protected set; }

        /// <summary>
        /// Tracks wheither or not the ship is dashing.
        /// </summary>
        public bool IsDashing { get; protected set; }

        /// <summary>
        /// The Job this Unit has.
        /// </summary>
        public StarDash.Job Job { get; protected set; }

        /// <summary>
        /// The amount of Legendarium ore carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int Legendarium { get; protected set; }

        /// <summary>
        /// The distance this unit can still move.
        /// </summary>
        public double Moves { get; protected set; }

        /// <summary>
        /// The amount of Mythicite carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int Mythicite { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit.
        /// </summary>
        public StarDash.Player Owner { get; protected set; }

        /// <summary>
        /// The radius of the circle this unit occupies.
        /// </summary>
        public double Radius { get; protected set; }

        /// <summary>
        /// The amount of Rarium carried by this unit. (0 to job carry capacity - other carried items).
        /// </summary>
        public int Rarium { get; protected set; }

        /// <summary>
        /// The x value this unit is on.
        /// </summary>
        public double X { get; protected set; }

        /// <summary>
        /// The y value this unit is on.
        /// </summary>
        public double Y { get; protected set; }


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
        }

        /// <summary>
        /// Attacks the specified unit.
        /// </summary>
        /// <param name="enemy">The Unit being attacked.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(StarDash.Unit enemy)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"enemy", enemy}
            });
        }

        /// <summary>
        /// allows a miner to mine a asteroid
        /// </summary>
        /// <param name="body">The object to be mined.</param>
        /// <returns>True if successfully acted, false otherwise.</returns>
        public bool Mine(StarDash.Body body)
        {
            return this.RunOnServer<bool>("mine", new Dictionary<string, object> {
                {"body", body}
            });
        }

        /// <summary>
        /// Moves this Unit from its current location to the new location specified.
        /// </summary>
        /// <param name="x">The x value of the destination's coordinates.</param>
        /// <param name="y">The y value of the destination's coordinates.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(double x, double y)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"x", x},
                {"y", y}
            });
        }

        /// <summary>
        /// tells you if your ship can be at that location.
        /// </summary>
        /// <param name="x">The x position of the location you wish to check.</param>
        /// <param name="y">The y position of the location you wish to check.</param>
        /// <returns>True if pathable by this unit, false otherwise.</returns>
        public bool Open(double x, double y)
        {
            return this.RunOnServer<bool>("open", new Dictionary<string, object> {
                {"x", x},
                {"y", y}
            });
        }

        /// <summary>
        /// tell you if there is a open path to that location.
        /// </summary>
        /// <param name="x">The x position of the destination you wish to check to.</param>
        /// <param name="y">The y position of the destination you wish to check to.</param>
        /// <returns>True if pathable by this unit, false otherwise.</returns>
        public bool Pathable(double x, double y)
        {
            return this.RunOnServer<bool>("pathable", new Dictionary<string, object> {
                {"x", x},
                {"y", y}
            });
        }

        /// <summary>
        /// Grab materials from a friendly unit. Doesn't use a action.
        /// </summary>
        /// <param name="unit">The unit you are grabbing the resources from.</param>
        /// <param name="amount">The amount of materials to you with to grab. Amounts &lt;= 0 will pick up all the materials that the unit can.</param>
        /// <param name="material">The material the unit will pick up. 'resource1', 'resource2', or 'resource3'.</param>
        /// <returns>True if successfully taken, false otherwise.</returns>
        public bool Transfer(StarDash.Unit unit, int amount, string material)
        {
            return this.RunOnServer<bool>("transfer", new Dictionary<string, object> {
                {"unit", unit},
                {"amount", amount},
                {"material", material}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
