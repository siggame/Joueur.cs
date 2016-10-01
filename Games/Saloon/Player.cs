// A player in this game. Every AI controls one player.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add addtional using(s) here
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Saloon
{
    /// <summary>
    /// A player in this game. Every AI controls one player.
    /// </summary>
    class Player : Saloon.GameObject
    {
        #region Properties
        /// <summary>
        /// What type of client this is, e.g. 'Python', 'JavaScript', or some other language. For potential data mining purposes.
        /// </summary>
        public string ClientType { get; protected set; }

        /// <summary>
        /// Every Cowboy owned by this Player.
        /// </summary>
        public IList<Saloon.Cowboy> Cowboys { get; protected set; }

        /// <summary>
        /// How many enemy Cowboys this player's team has killed.
        /// </summary>
        public int Kills { get; protected set; }

        /// <summary>
        /// If the player lost the game or not.
        /// </summary>
        public bool Lost { get; protected set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// This player's opponent in the game.
        /// </summary>
        public Saloon.Player Opponent { get; protected set; }

        /// <summary>
        /// The reason why the player lost the game.
        /// </summary>
        public string ReasonLost { get; protected set; }

        /// <summary>
        /// The reason why the player won the game.
        /// </summary>
        public string ReasonWon { get; protected set; }

        /// <summary>
        /// How rowdy their team is. When it gets too high their team takes a collective siesta.
        /// </summary>
        public int Rowdyness { get; protected set; }

        /// <summary>
        /// How many times their team has played a piano.
        /// </summary>
        public int Score { get; protected set; }

        /// <summary>
        /// The amount of time (in ns) remaining for this AI to send commands.
        /// </summary>
        public double TimeRemaining { get; protected set; }

        /// <summary>
        /// If the player won the game or not.
        /// </summary>
        public bool Won { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Player. Used during game initialization, do not call directly.
        /// </summary>
        protected Player() : base()
        {
            this.Cowboys = new List<Saloon.Cowboy>();
        }

        /// <summary>
        /// Sends in the Young Gun to the nearest Tile into the Saloon, and promotes them to a new job.
        /// </summary>
        /// <param name="job">The job you want the Young Gun being brought in to be called in to do, changing their job to it.</param>
        /// <returns>The Cowboy that was previously a 'Young Gun', and has now been promoted to a different job if successful, null otherwise.</returns>
        public Saloon.Cowboy SendIn(string job)
        {
            return this.RunOnServer<Saloon.Cowboy>("sendIn", new Dictionary<string, object> {
                {"job", job}
            });
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add addtional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
