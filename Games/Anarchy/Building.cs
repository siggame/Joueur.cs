// A basic building. It does nothing besides burn down. Other Buildings inherit from this class.

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
    /// A basic building. It does nothing besides burn down. Other Buildings inherit from this class.
    /// </summary>
    class Building : Anarchy.GameObject
    {
        #region Properties
        /// <summary>
        /// When true this building has already been bribed this turn and cannot be bribed again this turn.
        /// </summary>
        public bool Bribed { get; protected set; }

        /// <summary>
        /// The Building directly to the east of this building, or null if not present.
        /// </summary>
        public Anarchy.Building BuildingEast { get; protected set; }

        /// <summary>
        /// The Building directly to the north of this building, or null if not present.
        /// </summary>
        public Anarchy.Building BuildingNorth { get; protected set; }

        /// <summary>
        /// The Building directly to the south of this building, or null if not present.
        /// </summary>
        public Anarchy.Building BuildingSouth { get; protected set; }

        /// <summary>
        /// The Building directly to the west of this building, or null if not present.
        /// </summary>
        public Anarchy.Building BuildingWest { get; protected set; }

        /// <summary>
        /// How much fire is currently burning the building, and thus how much damage it will take at the end of its owner's turn. 0 means no fire.
        /// </summary>
        public int Fire { get; protected set; }

        /// <summary>
        /// How much health this building currently has. When this reaches 0 the Building has been burned down.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// True if this is the Headquarters of the owning player, false otherwise. Burning this down wins the game for the other Player.
        /// </summary>
        public bool IsHeadquarters { get; protected set; }

        /// <summary>
        /// The player that owns this building. If it burns down (health reaches 0) that player gets an additional bribe(s).
        /// </summary>
        public Anarchy.Player Owner { get; protected set; }

        /// <summary>
        /// The location of the Building along the x-axis.
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// The location of the Building along the y-axis.
        /// </summary>
        public int Y { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Building. Used during game initialization, do not call directly.
        /// </summary>
        protected Building() : base()
        {
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
