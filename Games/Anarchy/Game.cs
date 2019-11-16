// Two player grid based game where each player tries to burn down the other player's buildings. Let it burn.

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

/// <summary>
/// Two player grid based game where each player tries to burn down the other player's buildings. Let it burn.
/// </summary>
namespace Joueur.cs.Games.Anarchy
{
    /// <summary>
    /// Two player grid based game where each player tries to burn down the other player's buildings. Let it burn.
    /// </summary>
    public class Game : BaseGame
    {
        /// <summary>
        /// The game version hash, used to compare if we are playing the same version on the server.
        /// </summary>
        new protected static string GameVersion = "2bc66f9a5d7babd553079e149c7466feb6f553935b608ff722872e195fbadab8";

        #region Properties
        /// <summary>
        /// How many bribes players get at the beginning of their turn, not counting their burned down Buildings.
        /// </summary>
        public int BaseBribesPerTurn { get; protected set; }

        /// <summary>
        /// All the buildings in the game.
        /// </summary>
        public IList<Anarchy.Building> Buildings { get; protected set; }

        /// <summary>
        /// The current Forecast, which will be applied at the end of the turn.
        /// </summary>
        public Anarchy.Forecast CurrentForecast { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Anarchy.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// All the forecasts in the game, indexed by turn number.
        /// </summary>
        public IList<Anarchy.Forecast> Forecasts { get; protected set; }

        /// <summary>
        /// The width of the entire map along the vertical (y) axis.
        /// </summary>
        public int MapHeight { get; protected set; }

        /// <summary>
        /// The width of the entire map along the horizontal (x) axis.
        /// </summary>
        public int MapWidth { get; protected set; }

        /// <summary>
        /// The maximum amount of fire value for any Building.
        /// </summary>
        public int MaxFire { get; protected set; }

        /// <summary>
        /// The maximum amount of intensity value for any Forecast.
        /// </summary>
        public int MaxForecastIntensity { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The next Forecast, which will be applied at the end of your opponent's turn. This is also the Forecast WeatherStations can control this turn.
        /// </summary>
        public Anarchy.Forecast NextForecast { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Anarchy.Player> Players { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The amount of time (in nano-seconds) added after each player performs a turn.
        /// </summary>
        public int TimeAddedPerTurn { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Game. Used during game initialization, do not call directly.
        /// </summary>
        protected Game() : base()
        {
            this.Name = "Anarchy";

            this.Buildings = new List<Anarchy.Building>();
            this.Forecasts = new List<Anarchy.Forecast>();
            this.Players = new List<Anarchy.Player>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
