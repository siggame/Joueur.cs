// A machine in the game. Used to refine ore.

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

namespace Joueur.cs.Games.Newtonian
{
    /// <summary>
    /// A machine in the game. Used to refine ore.
    /// </summary>
    public class Machine : Newtonian.GameObject
    {
        #region Properties
        /// <summary>
        /// What type of ore the machine takes it. Also determines the type of material it outputs. (redium or blueium).
        /// </summary>
        public string OreType { get; protected set; }

        /// <summary>
        /// The amount of ore that needs to be inputted into the machine for it to be worked.
        /// </summary>
        public int RefineInput { get; protected set; }

        /// <summary>
        /// The amount of refined ore that is returned after the machine has been fully worked.
        /// </summary>
        public int RefineOutput { get; protected set; }

        /// <summary>
        /// The number of times this machine needs to be worked to refine ore.
        /// </summary>
        public int RefineTime { get; protected set; }

        /// <summary>
        /// The Tile this Machine is on.
        /// </summary>
        public Newtonian.Tile Tile { get; protected set; }

        /// <summary>
        /// Tracks how many times this machine has been worked. (0 to refineTime).
        /// </summary>
        public int Worked { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Machine. Used during game initialization, do not call directly.
        /// </summary>
        protected Machine() : base()
        {
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
