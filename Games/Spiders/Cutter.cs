// A Spiderling that can cut existing Webs.

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
    /// A Spiderling that can cut existing Webs.
    /// </summary>
    public class Cutter : Spiders.Spiderling
    {
        #region Properties
        /// <summary>
        /// The Web that this Cutter is trying to cut. Null if not cutting.
        /// </summary>
        public Spiders.Web CuttingWeb { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Cutter. Used during game initialization, do not call directly.
        /// </summary>
        protected Cutter() : base()
        {
        }

        /// <summary>
        /// Cuts a web, destroying it, and any Spiderlings on it.
        /// </summary>
        /// <param name="web">The web you want to Cut. Must be connected to the Nest this Cutter is currently on.</param>
        /// <returns>True if the cut was successfully started, false otherwise.</returns>
        public bool Cut(Spiders.Web web)
        {
            return this.RunOnServer<bool>("cut", new Dictionary<string, object> {
                {"web", web}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
