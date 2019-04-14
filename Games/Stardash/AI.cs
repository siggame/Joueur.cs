// This is where you build your AI for the Stardash game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add additional using(s) here
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Stardash
{
    /// <summary>
    /// This is where you build your AI for Stardash.
    /// </summary>
    public class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself. It contains all the information about the current game.
        /// </summary>
        public readonly Game Game;
        /// <summary>
        /// This is your AI's player. It contains all the information about your player's state.
        /// </summary>
        public readonly Player Player;
        #pragma warning restore 0169
        #pragma warning restore 0649

        // <<-- Creer-Merge: properties -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional properties here for your AI to use
        // <<-- /Creer-Merge: properties -->>
        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>Your AI's name</returns>
        public override string GetName()
        {
            // <<-- Creer-Merge: get-name -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            return "Stardash C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
            // <<-- /Creer-Merge: get-name -->>
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
            // <<-- Creer-Merge: start -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            base.Start();
            // <<-- /Creer-Merge: start -->>
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update, this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
            // <<-- Creer-Merge: game-updated -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            base.GameUpdated();
            // <<-- /Creer-Merge: game-updated -->>
        }

        /// <summary>
        /// This is automatically called when the game ends.
        /// </summary>
        /// <remarks>
        /// You can do any cleanup of you AI here, or do custom logging. After this function returns, the application will close.
        /// </remarks>
        /// <param name="won">True if your player won, false otherwise</param>
        /// <param name="reason">A string explaining why you won or lost</param>
        public override void Ended(bool won, string reason)
        {
            // <<-- Creer-Merge: ended -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            base.Ended(won, reason);
            // <<-- /Creer-Merge: ended -->>
        }


        /// <summary>
        /// This is called every time it is this AI.player's turn.
        /// </summary>
        /// <returns>Represents if you want to end your turn. True means end your turn, False means to keep your turn going and re-call this function.</returns>
        public bool RunTurn()
        {
            // <<-- Creer-Merge: runTurn -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            // Put your game logic here for runTurn
            // Gets the coordinates of your home base (planet).
            var homeX = Player.HomeBase.X;
            var homeY = Player.HomeBase.Y;

            // Gets the coordinates of the sun.
            var sun = Game.Bodies[2];

            // Checks if we have any units.
            if(Player.Units.Count == 0)
            {
                // We don't have any units.
                Player.HomeBase.Spawn(homeX, homeY, "miner");
            }

            // Gets the first unit in our list of units.
            var unit = Player.Units.FirstOrDefault();
            if(unit != null)
            {
                System.Console.WriteLine($"Unit: {unit.Energy}; X: {unit.X}; Y: {unit.Y}");
                if(unit.Energy < 0.5 * unit.Job.Energy)
                {
                    // If the miner is below 50% energy, goes back to its home base to heal.
                    FindDash(unit, homeX, homeY);
                }
                else if (unit.Genarium < unit.Job.CarryLimit)
                {
                    // If there is space in our inventory, go mine an asteroid for genarium (the worst mineral btw).
                    Body target = null; 
                    var bestDist = 9999.0;

                    // Finds the closest asteroid that contains genarium to target.
                    foreach (Body body in Game.Bodies)
                    {
                        // Only looks at asteroids that contain genarium.
                        if (body.MaterialType == "genarium")
                        {
                            System.Console.WriteLine("Found genarium");
                            // Gets the distance from the unit to the body
                            var distance = Distance(unit.X, unit.Y, body.X, body.Y);

                            // Updates the target if the new asteroid is closer to our unit.
                            if (distance < bestDist)
                                target = body;
                                bestDist = distance;
                        }
                    }

                    if (target != null)
                    {
                        // Tries to move to the asteroid.
                        FindDash(unit, target.X, target.Y);

                        // Checks if the miner is within mining range of the target asteroid.
                        if (Distance(unit.X, unit.Y, target.X, target.Y) < unit.Job.Range)
                            unit.Mine(target);
                    }
                }
                else
                // Otherwise return to home base and drop off any mined genarium and restoring energy in the process.
                FindDash(unit, homeX, homeY);
            }
            return true;
            // <<-- /Creer-Merge: runTurn -->>
        }

        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional methods here for your AI to call
        double Distance(double x1, double y1, double x2, double y2)
        {
            /*
            Returns the Euclidian distance between two points.
                Args:
                    x1 (int): The x coordinate of the first point.
                    y1 (int): The y coordinate of the first point.
                    x2 (int): The x coordinate of the second point.
                    y2 (int): The y coordinate of the second point.
                Returns:
                    float: The distance between the two points.
            */ 
            return Math.Sqrt(Math.Pow((x1 - x2), 2.0) + Math.Pow((y1 - y2), 2.0));
        }

    void FindDash(Unit unit, double x, double y)
    {
        /* This is an EXTREMELY basic pathfinding function to move your ship until it can dash to your target.
            You REALLY should improve this functionality or make your own new one, since this is VERY basic and inefficient.
            Like, for real.
            Args:
                unit (unit): The unit that will be moving.
                x (int): The x coordinate of the destination.
                y (int): The y coordinate of the destination.
        */
        // Gets the sun from the list of bodies.
        var sun = Game.Bodies[2];

        while (unit.Moves >= 1)
        {

            if (unit.Safe(x, y) && unit.Energy >= Math.Ceiling((Distance(unit.X, unit.Y, x, y) / Game.DashDistance) * Game.DashCost))
            {
                // Dashes if it is safe to dash to the point and we have enough energy to dash there.
                unit.Dash(x, y);
                // Breaks out of the loop since we can't do anything else now.
                break;
            }
            else
            {
                // Otherwise tries moving towards the target.
                // The x and y modifiers for movement.
                var xMod = 0;
                var yMod = 0;

                if (unit.X < x || (y < sun.Y && unit.Y > sun.Y || y > sun.Y && unit.Y < sun.Y) && x > sun.X)
                    // Move to the right if the destination is to the right or on the other side of the sun on the right side.
                    xMod = 1;
                else if (unit.X > x || (y < sun.Y && unit.Y > sun.Y || y > sun.Y && unit.Y < sun.Y) && x < sun.X)
                    // Move to the left if the destination is to the left or on the other side of the sun on the left side.
                    xMod = -1;

                if (unit.Y < y || (x < sun.X && unit.X > sun.X || x > sun.X && unit.X < sun.X) && y > sun.Y)
                    // Move down if the destination is down or on the other side of the sun on the lower side.
                    yMod = 1;
                else if (unit.Y > y || (x < sun.X && unit.X > sun.X || x > sun.X && unit.X < sun.X) && y < sun.Y)
                    // Move up if the destination is up or on the other side of the sun on the upper side.
                    yMod = -1;

                if (xMod != 0 && yMod != 0 && !unit.Safe(unit.X + xMod, unit.Y + yMod))
                {
                    // Special case if we cannot safely move diagonally.
                    if (unit.Safe(unit.X + xMod, unit.Y))
                        // Only move horizontally if it is safe.
                        yMod = 0;
                    else if (unit.Safe(unit.X, unit.Y + yMod))
                        // Only move vertically if it is safe.
                        xMod = 0;
                }

                if (unit.Moves < Math.Sqrt(2) && xMod != 0 && yMod != 0)
                {
                    // Special case if we only have 1 move left and are trying to move 2.
                    if (unit.Safe(unit.X + xMod, unit.Y))
                        yMod = 0;
                    else if (unit.Safe(unit.X, unit.Y + yMod))
                        xMod = 0;
                    else break;
                }

                if ((xMod != 0 || yMod != 0) && (Math.Sqrt(Math.Pow(xMod, 2) + Math.Pow(yMod, 2)) >= unit.Moves))
                    // Tries to move if either of the modifiers is not zero (we are actually moving somewhere).
                    unit.Move(unit.X + xMod, unit.Y + yMod);
                else
                    // Breaks otherwise, since something probably went wrong.
                    break;
            }
        }
    }

        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
