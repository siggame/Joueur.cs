// A person on the map that can move around and interact within the saloon.

// DO NOT MODIFY THIS FILE
// Never try to directly create an instance of this class, or modify its member variables.
// Instead, you should only be reading its variables and calling its functions.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// you can add addtional using(s) here


namespace Joueur.cs.Games.Saloon
{
    /// <summary>
    /// A person on the map that can move around and interact within the saloon.
    /// </summary>
    class Cowboy : Saloon.GameObject
    {
        #region Properties
        /// <summary>
        /// If the Cowboy can be moved this turn via its owner.
        /// </summary>
        public bool CanMove { get; protected set; }

        /// <summary>
        /// The direction this Cowboy is moving while drunk. Will be 'North', 'East', 'South', or 'West' when drunk; or '' (empty string) when not drunk.
        /// </summary>
        public string DrunkDirection { get; protected set; }

        /// <summary>
        /// How much focus this Cowboy has. Different Jobs do different things with their Cowboy's focus.
        /// </summary>
        public int Focus { get; protected set; }

        /// <summary>
        /// How much health this Cowboy currently has.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// If this Cowboy is dead and has been removed from the game.
        /// </summary>
        public bool IsDead { get; protected set; }

        /// <summary>
        /// If this Cowboy is drunk, and will automatically walk.
        /// </summary>
        public bool IsDrunk { get; protected set; }

        /// <summary>
        /// The job that this Cowboy does, and dictates how they fight and interact within the Saloon.
        /// </summary>
        public string Job { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Cowboy.
        /// </summary>
        public Saloon.Player Owner { get; protected set; }

        /// <summary>
        /// The Tile that this Cowboy is located on.
        /// </summary>
        public Saloon.Tile Tile { get; protected set; }

        /// <summary>
        /// How many times this unit has been drunk before taking their siesta and reseting this to 0.
        /// </summary>
        public int Tolerance { get; protected set; }

        /// <summary>
        /// How many turns this unit has remaining before it is no longer busy and can `act()` or `play()` again.
        /// </summary>
        public int TurnsBusy { get; protected set; }


        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.

        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Cowboy. Used during game initialization, do not call directly.
        /// </summary>
        protected Cowboy() : base()
        {
        }

        /// <summary>
        /// Does their job's action on a Tile.
        /// </summary>
        /// <param name="tile">The Tile you want this Cowboy to act on.</param>
        /// <param name="drunkDirection">The direction the bottle will cause drunk cowboys to be in, can be 'North', 'East', 'South', or 'West'.</param>
        /// <returns>True if the act worked, false otherwise.</returns>
        public bool Act(Saloon.Tile tile, string drunkDirection="")
        {
            return this.RunOnServer<bool>("act", new Dictionary<string, object> {
                {"tile", tile},
                {"drunkDirection", drunkDirection}
            });
        }

        /// <summary>
        /// Moves this Cowboy from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile you want to move this Cowboy to.</param>
        /// <returns>True if the move worked, false otherwise.</returns>
        public bool Move(Saloon.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Sits down and plays a piano.
        /// </summary>
        /// <param name="piano">The Furnishing that is a piano you want to play.</param>
        /// <returns>True if the play worked, false otherwise.</returns>
        public bool Play(Saloon.Furnishing piano)
        {
            return this.RunOnServer<bool>("play", new Dictionary<string, object> {
                {"piano", piano}
            });
        }


        // you can add addtional method(s) here.

        #endregion
    }
}
