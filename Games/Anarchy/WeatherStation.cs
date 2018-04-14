// Can be bribed to change the next Forecast in some way.

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
    /// Can be bribed to change the next Forecast in some way.
    /// </summary>
    public class WeatherStation : Anarchy.Building
    {
        #region Properties

        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of WeatherStation. Used during game initialization, do not call directly.
        /// </summary>
        protected WeatherStation() : base()
        {
        }

        /// <summary>
        /// Bribe the weathermen to intensity the next Forecast by 1 or -1
        /// </summary>
        /// <param name="negative">By default the intensity will be increased by 1, setting this to true decreases the intensity by 1.</param>
        /// <returns>True if the intensity was changed, false otherwise.</returns>
        public bool Intensify(bool negative=false)
        {
            return this.RunOnServer<bool>("intensify", new Dictionary<string, object> {
                {"negative", negative}
            });
        }

        /// <summary>
        /// Bribe the weathermen to change the direction of the next Forecast by rotating it clockwise or counterclockwise.
        /// </summary>
        /// <param name="counterclockwise">By default the direction will be rotated clockwise. If you set this to true we will rotate the forecast counterclockwise instead.</param>
        /// <returns>True if the rotation worked, false otherwise.</returns>
        public bool Rotate(bool counterclockwise=false)
        {
            return this.RunOnServer<bool>("rotate", new Dictionary<string, object> {
                {"counterclockwise", counterclockwise}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
