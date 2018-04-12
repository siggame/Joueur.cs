// A unit group in the game. This may consist of a ship and any number of crew.

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

namespace Joueur.cs.Games.Pirates
{
    /// <summary>
    /// A unit group in the game. This may consist of a ship and any number of crew.
    /// </summary>
    public class Unit : Pirates.GameObject
    {
        #region Properties
        /// <summary>
        /// Whether this Unit has performed its action this turn.
        /// </summary>
        public bool Acted { get; protected set; }

        /// <summary>
        /// How many crew are on this Tile. This number will always be &lt;= crewHealth.
        /// </summary>
        public int Crew { get; protected set; }

        /// <summary>
        /// How much total health the crew on this Tile have.
        /// </summary>
        public int CrewHealth { get; protected set; }

        /// <summary>
        /// How much gold this Unit is carrying.
        /// </summary>
        public int Gold { get; protected set; }

        /// <summary>
        /// How many more times this Unit may move this turn.
        /// </summary>
        public int Moves { get; protected set; }

        /// <summary>
        /// The Player that owns and can control this Unit, or null if the Unit is neutral.
        /// </summary>
        public Pirates.Player Owner { get; protected set; }

        /// <summary>
        /// (Merchants only) The path this Unit will follow. The first element is the Tile this Unit will move to next.
        /// </summary>
        public IList<Pirates.Tile> Path { get; protected set; }

        /// <summary>
        /// If a ship is on this Tile, how much health it has remaining. 0 for no ship.
        /// </summary>
        public int ShipHealth { get; protected set; }

        /// <summary>
        /// (Merchants only) The Port this Unit is moving to.
        /// </summary>
        public Pirates.Port TargetPort { get; protected set; }

        /// <summary>
        /// The Tile this Unit is on.
        /// </summary>
        public Pirates.Tile Tile { get; protected set; }


        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties(s) here. None of them will be tracked or updated by the server.
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of Unit. Used during game initialization, do not call directly.
        /// </summary>
        protected Unit() : base()
        {
            this.Path = new List<Pirates.Tile>();
        }

        /// <summary>
        /// Attacks either crew, a ship, or a port on a Tile in range.
        /// </summary>
        /// <param name="tile">The Tile to attack.</param>
        /// <param name="target">Whether to attack 'crew', 'ship', or 'port'. Crew deal damage to crew, and ships deal damage to ships. Both can attack ports as well. Units cannot attack other units in ports. Consumes any remaining moves.</param>
        /// <returns>True if successfully attacked, false otherwise.</returns>
        public bool Attack(Pirates.Tile tile, string target)
        {
            return this.RunOnServer<bool>("attack", new Dictionary<string, object> {
                {"tile", tile},
                {"target", target}
            });
        }

        /// <summary>
        /// Builds a Port on the given Tile.
        /// </summary>
        /// <param name="tile">The Tile to build the Port on.</param>
        /// <returns>True if successfully built a Port, false otherwise.</returns>
        public bool Build(Pirates.Tile tile)
        {
            return this.RunOnServer<bool>("build", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Buries gold on this Unit's Tile.
        /// </summary>
        /// <param name="amount">How much gold this Unit should bury. Amounts &lt;= 0 will bury as much as possible.</param>
        /// <returns>True if successfully buried, false otherwise.</returns>
        public bool Bury(int amount)
        {
            return this.RunOnServer<bool>("bury", new Dictionary<string, object> {
                {"amount", amount}
            });
        }

        /// <summary>
        /// Puts gold into an adjacent Port. If that Port is the Player's main port, the gold is added to that Player. If that Port is owned by merchants, it adds to that Port's investment.
        /// </summary>
        /// <param name="amount">The amount of gold to deposit. Amounts &lt;= 0 will deposit all the gold on this Unit.</param>
        /// <returns>True if successfully deposited, false otherwise.</returns>
        public bool Deposit(int amount=0)
        {
            return this.RunOnServer<bool>("deposit", new Dictionary<string, object> {
                {"amount", amount}
            });
        }

        /// <summary>
        /// Digs up gold on this Unit's Tile.
        /// </summary>
        /// <param name="amount">How much gold this Unit should take. Amounts &lt;= 0 will dig up as much as possible.</param>
        /// <returns>True if successfully dug up, false otherwise.</returns>
        public bool Dig(int amount=0)
        {
            return this.RunOnServer<bool>("dig", new Dictionary<string, object> {
                {"amount", amount}
            });
        }

        /// <summary>
        /// Moves this Unit from its current Tile to an adjacent Tile.
        /// </summary>
        /// <param name="tile">The Tile this Unit should move to.</param>
        /// <returns>True if it moved, false otherwise.</returns>
        public bool Move(Pirates.Tile tile)
        {
            return this.RunOnServer<bool>("move", new Dictionary<string, object> {
                {"tile", tile}
            });
        }

        /// <summary>
        /// Regenerates this Unit's health. Must be used in range of a port.
        /// </summary>
        /// <returns>True if successfully rested, false otherwise.</returns>
        public bool Rest()
        {
            return this.RunOnServer<bool>("rest", new Dictionary<string, object> {
            });
        }

        /// <summary>
        /// Moves a number of crew from this Unit to the given Tile. This will consume a move from those crew.
        /// </summary>
        /// <param name="tile">The Tile to move the crew to.</param>
        /// <param name="amount">The number of crew to move onto that Tile. Amount &lt;= 0 will move all the crew to that Tile.</param>
        /// <param name="gold">The amount of gold the crew should take with them. Gold &lt; 0 will move all the gold to that Tile.</param>
        /// <returns>True if successfully split, false otherwise.</returns>
        public bool Split(Pirates.Tile tile, int amount=1, int gold=0)
        {
            return this.RunOnServer<bool>("split", new Dictionary<string, object> {
                {"tile", tile},
                {"amount", amount},
                {"gold", gold}
            });
        }

        /// <summary>
        /// Takes gold from the Player. You can only withdraw from your main port.
        /// </summary>
        /// <param name="amount">The amount of gold to withdraw. Amounts &lt;= 0 will withdraw everything.</param>
        /// <returns>True if successfully withdrawn, false otherwise.</returns>
        public bool Withdraw(int amount=0)
        {
            return this.RunOnServer<bool>("withdraw", new Dictionary<string, object> {
                {"amount", amount}
            });
        }



        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional method(s) here.
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
