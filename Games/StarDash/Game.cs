// Collect of the most of the rarest mineral orbiting aroung the sun and outcompete your competetor.

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
/// Collect of the most of the rarest mineral orbiting aroung the sun and outcompete your competetor.
/// </summary>
namespace Joueur.cs.Games.StarDash
{
    /// <summary>
    /// Collect of the most of the rarest mineral orbiting aroung the sun and outcompete your competetor.
    /// </summary>
    public class Game : BaseGame
    {
        #region Properties
        /// <summary>
        /// All the celestial bodies in the game.
        /// </summary>
        public IList<StarDash.Body> Bodies { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public StarDash.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The distance traveled each turn by dashing.
        /// </summary>
        public int DashDistance { get; protected set; }

        /// <summary>
        /// A list of all jobs. first item is corvette, second is missleboat, third is martyr, fourth is transport, and fifth is miner.
        /// </summary>
        public IList<StarDash.Job> Jobs { get; protected set; }

        /// <summary>
        /// The highest amount of material, barring rarity, that can be in a asteroid.
        /// </summary>
        public int MaxAsteroid { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The smallest amount of material, barring rarity, that can be in a asteroid.
        /// </summary>
        public int MinAsteroid { get; protected set; }

        /// <summary>
        /// The rarity modifier of the most common ore. This controls how much spawns.
        /// </summary>
        public double OreRarity1 { get; protected set; }

        /// <summary>
        /// The rarity modifier of the second rarest ore. This controls how much spawns.
        /// </summary>
        public double OreRarity2 { get; protected set; }

        /// <summary>
        /// The rarity modifier of the rarest ore. This controls how much spawns.
        /// </summary>
        public double OreRarity3 { get; protected set; }

        /// <summary>
        /// The amount of energy the planets restore each round.
        /// </summary>
        public int PlanetRechargeRate { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<StarDash.Player> Players { get; protected set; }

        /// <summary>
        /// The regeneration rate of asteroids.
        /// </summary>
        public double RegenerateRate { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The size of the map in the X direction.
        /// </summary>
        public int SizeX { get; protected set; }

        /// <summary>
        /// The size of the map in the Y direction.
        /// </summary>
        public int SizeY { get; protected set; }

        /// <summary>
        /// The amount of time (in nano-seconds) added after each player performs a turn.
        /// </summary>
        public int TimeAddedPerTurn { get; protected set; }

        /// <summary>
        /// Every Unit in the game.
        /// </summary>
        public IList<StarDash.Unit> Units { get; protected set; }


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
            this.Name = "StarDash";

            this.Bodies = new List<StarDash.Body>();
            this.Jobs = new List<StarDash.Job>();
            this.Players = new List<StarDash.Player>();
            this.Units = new List<StarDash.Unit>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
