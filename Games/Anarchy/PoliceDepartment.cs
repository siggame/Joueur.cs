// Used to keep cities under control and raid Warehouses.

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
    /// Used to keep cities under control and raid Warehouses.
    /// </summary>
    class PoliceDepartment : Anarchy.Building
    {
        #region Properties

        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of PoliceDepartment. Used during game initialization, do not call directly.
        /// </summary>
        protected PoliceDepartment() : base()
        {
        }

        /// <summary>
        /// Bribe the police to raid a Warehouse, dealing damage equal based on the Warehouse's current exposure, and then resetting it to 0.
        /// </summary>
        /// <param name="warehouse">The warehouse you want to raid.</param>
        /// <returns>The amount of damage dealt to the warehouse, or -1 if there was an error.</returns>
        public int Raid(Anarchy.Warehouse warehouse)
        {
            return this.RunOnServer<int>("raid", new Dictionary<string, object> {
                {"warehouse", warehouse}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
