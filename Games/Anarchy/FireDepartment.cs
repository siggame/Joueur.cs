// Can put out fires completely.

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

namespace Joueur.cs.Games.Anarchy
{
    /// <summary>
    /// Can put out fires completely.
    /// </summary>
    public class FireDepartment : Anarchy.Building
    {
        #region Properties
        /// <summary>
        /// The amount of fire removed from a building when bribed to extinguish a building.
        /// </summary>
        public int FireExtinguished { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of FireDepartment. Used during game initialization, do not call directly.
        /// </summary>
        protected FireDepartment() : base()
        {
        }

        /// <summary>
        /// Bribes this FireDepartment to extinguish the some of the fire in a building.
        /// </summary>
        /// <param name="building">The Building you want to extinguish.</param>
        /// <returns>True if the bribe worked, false otherwise.</returns>
        public bool Extinguish(Anarchy.Building building)
        {
            return this.RunOnServer<bool>("extinguish", new Dictionary<string, object> {
                {"building", building}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
