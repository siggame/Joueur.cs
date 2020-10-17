// Collect of the most of the rarest mineral orbiting around the sun and out-compete your competitor.

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
/// Collect of the most of the rarest mineral orbiting around the sun and out-compete your competitor.
/// </summary>
namespace Joueur.cs.Games.Stardash
{
    /// <summary>
    /// Collect of the most of the rarest mineral orbiting around the sun and out-compete your competitor.
    /// </summary>
    public class Game : BaseGame
    {
        /// <summary>
        /// The game version hash, used to compare if we are playing the same version on the server.
        /// </summary>
        new protected static string GameVersion = "0fa378e83ac567ebdf3e9805d3f130023f936e2740acda173d238b37f2b5d541";

        #region Properties
        /// <summary>
        /// All the celestial bodies in the game. The first two are planets and the third is the sun. The fourth is the VP asteroid. Everything else is normal asteroids.
        /// </summary>
        public IList<Stardash.Body> Bodies { get; protected set; }

        /// <summary>
        /// The player whose turn it is currently. That player can send commands. Other players cannot.
        /// </summary>
        public Stardash.Player CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current turn number, starting at 0 for the first player's turn.
        /// </summary>
        public int CurrentTurn { get; protected set; }

        /// <summary>
        /// The cost of dashing.
        /// </summary>
        public int DashCost { get; protected set; }

        /// <summary>
        /// The distance traveled each turn by dashing.
        /// </summary>
        public int DashDistance { get; protected set; }

        /// <summary>
        /// The value of every unit of genarium.
        /// </summary>
        public double GenariumValue { get; protected set; }

        /// <summary>
        /// A list of all jobs. The first element is corvette, second is missileboat, third is martyr, fourth is transport, and fifth is miner.
        /// </summary>
        public IList<Stardash.Job> Jobs { get; protected set; }

        /// <summary>
        /// The value of every unit of legendarium.
        /// </summary>
        public double LegendariumValue { get; protected set; }

        /// <summary>
        /// The highest amount of material, that can be in a asteroid.
        /// </summary>
        public int MaxAsteroid { get; protected set; }

        /// <summary>
        /// The maximum number of turns before the game will automatically end.
        /// </summary>
        public int MaxTurns { get; protected set; }

        /// <summary>
        /// The smallest amount of material, that can be in a asteroid.
        /// </summary>
        public int MinAsteroid { get; protected set; }

        /// <summary>
        /// The rate at which miners grab minerals from asteroids.
        /// </summary>
        public int MiningSpeed { get; protected set; }

        /// <summary>
        /// The amount of mythicite that spawns at the start of the game.
        /// </summary>
        public double MythiciteAmount { get; protected set; }

        /// <summary>
        /// The number of orbit updates you cannot mine the mithicite asteroid.
        /// </summary>
        public int OrbitsProtected { get; protected set; }

        /// <summary>
        /// The rarity modifier of the most common ore. This controls how much spawns.
        /// </summary>
        public double OreRarityGenarium { get; protected set; }

        /// <summary>
        /// The rarity modifier of the rarest ore. This controls how much spawns.
        /// </summary>
        public double OreRarityLegendarium { get; protected set; }

        /// <summary>
        /// The rarity modifier of the second rarest ore. This controls how much spawns.
        /// </summary>
        public double OreRarityRarium { get; protected set; }

        /// <summary>
        /// The amount of energy a planet can hold at once.
        /// </summary>
        public int PlanetEnergyCap { get; protected set; }

        /// <summary>
        /// The amount of energy the planets restore each round.
        /// </summary>
        public int PlanetRechargeRate { get; protected set; }

        /// <summary>
        /// List of all the players in the game.
        /// </summary>
        public IList<Stardash.Player> Players { get; protected set; }

        /// <summary>
        /// The standard size of ships.
        /// </summary>
        public int ProjectileRadius { get; protected set; }

        /// <summary>
        /// The amount of distance missiles travel through space.
        /// </summary>
        public int ProjectileSpeed { get; protected set; }

        /// <summary>
        /// Every projectile in the game.
        /// </summary>
        public IList<Stardash.Projectile> Projectiles { get; protected set; }

        /// <summary>
        /// The value of every unit of rarium.
        /// </summary>
        public double RariumValue { get; protected set; }

        /// <summary>
        /// The regeneration rate of asteroids.
        /// </summary>
        public double RegenerateRate { get; protected set; }

        /// <summary>
        /// A unique identifier for the game instance that is being played.
        /// </summary>
        public string Session { get; protected set; }

        /// <summary>
        /// The standard size of ships.
        /// </summary>
        public int ShipRadius { get; protected set; }

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
        /// The number of turns it takes for a asteroid to orbit the sun. (Asteroids move after each players turn).
        /// </summary>
        public int TurnsToOrbit { get; protected set; }

        /// <summary>
        /// Every Unit in the game.
        /// </summary>
        public IList<Stardash.Unit> Units { get; protected set; }


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
            this.Name = "Stardash";

            this.Bodies = new List<Stardash.Body>();
            this.Jobs = new List<Stardash.Job>();
            this.Players = new List<Stardash.Player>();
            this.Projectiles = new List<Stardash.Projectile>();
            this.Units = new List<Stardash.Unit>();
        }


        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
