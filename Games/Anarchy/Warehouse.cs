// A typical abandoned warehouse... that anarchists hang out in and can be bribed to burn down Buildings.

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
    /// A typical abandoned warehouse... that anarchists hang out in and can be bribed to burn down Buildings.
    /// </summary>
    public class Warehouse : Anarchy.Building
    {
        #region Properties
        /// <summary>
        /// How exposed the anarchists in this warehouse are to PoliceDepartments. Raises when bribed to ignite buildings, and drops each turn if not bribed.
        /// </summary>
        public int Exposure { get; protected set; }

        /// <summary>
        /// The amount of fire added to buildings when bribed to ignite a building. Headquarters add more fire than normal Warehouses.
        /// </summary>
        public int FireAdded { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Warehouse. Used during game initialization, do not call directly.
        /// </summary>
        protected Warehouse() : base()
        {
        }

        /// <summary>
        /// Bribes the Warehouse to light a Building on fire. This adds this building's fireAdded to their fire, and then this building's exposure is increased based on the Manhatten distance between the two buildings.
        /// </summary>
        /// <param name="building">The Building you want to light on fire.</param>
        /// <returns>The exposure added to this Building's exposure. -1 is returned if there was an error.</returns>
        public int Ignite(Anarchy.Building building)
        {
            return this.RunOnServer<int>("ignite", new Dictionary<string, object> {
                {"building", building}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
