// A port on a Tile.

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

namespace Joueur.cs.Games.Pirates
{
    /// <summary>
    /// A port on a Tile.
    /// </summary>
    public class Port : Pirates.GameObject
    {
        #region Properties
        /// <summary>
        /// For players, how much more gold this Port can spend this turn. For merchants, how much gold this Port has accumulated (it will spawn a ship when the Port can afford one).
        /// </summary>
        public int Gold { get; protected set; }

        /// <summary>
        /// (Merchants only) How much gold was invested into this Port. Investment determines the strength and value of the next ship.
        /// </summary>
        public int Investment { get; protected set; }

        /// <summary>
        /// The owner of this Port, or null if owned by merchants.
        /// </summary>
        public Pirates.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile this Port is on.
        /// </summary>
        public Pirates.Tile Tile { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Port. Used during game initialization, do not call directly.
        /// </summary>
        protected Port() : base()
        {
        }

        /// <summary>
        /// Spawn a Unit on this port.
        /// </summary>
        /// <param name="type">What type of Unit to create ('crew' or 'ship').</param>
        /// <returns>True if Unit was created successfully, false otherwise.</returns>
        public bool Spawn(string type)
        {
            return this.RunOnServer<bool>("spawn", new Dictionary<string, object> {
                {"type", type}
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
