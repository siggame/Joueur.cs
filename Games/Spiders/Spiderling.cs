// A Spider spawned by the BroodMother.

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

namespace Joueur.cs.Games.Spiders
{
    /// <summary>
    /// A Spider spawned by the BroodMother.
    /// </summary>
    public class Spiderling : Spiders.Spider
    {
        #region Properties
        /// <summary>
        /// When empty string this Spiderling is not busy, and can act. Otherwise a string representing what it is busy with, e.g. 'Moving', 'Attacking'.
        /// </summary>
        public string Busy { get; protected set; }

        /// <summary>
        /// The Web this Spiderling is using to move. Null if it is not moving.
        /// </summary>
        public Spiders.Web MovingOnWeb { get; protected set; }

        /// <summary>
        /// The Nest this Spiderling is moving to. Null if it is not moving.
        /// </summary>
        public Spiders.Nest MovingToNest { get; protected set; }

        /// <summary>
        /// The number of Spiderlings busy with the same work this Spiderling is doing, speeding up the task.
        /// </summary>
        public int NumberOfCoworkers { get; protected set; }

        /// <summary>
        /// How much work needs to be done for this Spiderling to finish being busy. See docs for the Work forumla.
        /// </summary>
        public double WorkRemaining { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Spiderling. Used during game initialization, do not call directly.
        /// </summary>
        protected Spiderling() : base()
        {
        }

        /// <summary>
        /// Attacks another Spiderling
        /// </summary>
        /// <param name="spiderling">The Spiderling to attack.</param>
        /// <returns>True if the attack was successful, false otherwise.</returns>
        public bool Attack(Spiders.Spiderling spiderling)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"spiderling", spiderling}
            });
        }

        /// <summary>
        /// Starts moving the Spiderling across a Web to another Nest.
        /// </summary>
        /// <param name="web">The Web you want to move across to the other Nest.</param>
        /// <returns>True if the move was successful, false otherwise.</returns>
        public bool Move(Spiders.Web web)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"web", web}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
