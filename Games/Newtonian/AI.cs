// This is where you build your AI for the Newtonian game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add additional using(s) here
using System.Runtime.CompilerServices;
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Newtonian
{
    /// <summary>
    /// This is where you build your AI for Newtonian.
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
            return "Newtonian C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
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

	        Console.Clear();
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
	        this.DisplayMap();
	        Console.ForegroundColor = ConsoleColor.White;
	        Console.BackgroundColor = ConsoleColor.Black;
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
			return true;
            // <<-- /Creer-Merge: runTurn -->>
        }

        /// <summary>
        /// A very basic path finding algorithm (Breadth First Search) that when given a starting Tile, will return a valid path to the goal Tile.
        /// </summary>
        /// <remarks>
        /// This is NOT an optimal pathfinding algorithm. It is intended as a stepping stone if you want to improve it.
        /// </remarks>
        /// <param name="start">the starting Tile</param>
        /// <param name="goal">the goal Tile</param>
        /// <returns>A list of Tiles representing the path where the first element is a valid adjacent Tile to the start, and the last element is the goal. Or an empty list if no path found.</returns>
        List<Tile> FindPath(Tile start, Tile goal)
        {
            // no need to make a path to here...
            if (start == goal)
            {
                return new List<Tile>();
            }

            // the tiles that will have their neighbors searched for 'goal'
            Queue<Tile> fringe = new Queue<Tile>();

            // How we got to each tile that went into the fringe.
            Dictionary<Tile, Tile> cameFrom = new Dictionary<Tile, Tile>();

            // Enqueue start as the first tile to have its neighbors searched.
            fringe.Enqueue(start);

            // keep exploring neighbors of neighbors... until there are no more.
            while (fringe.Any())
            {
                // the tile we are currently exploring.
                Tile inspect = fringe.Dequeue();

                // cycle through the tile's neighbors.
                foreach (Tile neighbor in inspect.GetNeighbors())
                {
                    if (neighbor == goal)
                    {
                        // Follow the path backward starting at the goal and return it.
                        List<Tile> path = new List<Tile>();
                        path.Add(goal);

                        // Starting at the tile we are currently at, insert them retracing our steps till we get to the starting tile
                        for (Tile step = inspect; step != start; step = cameFrom[step])
                        {
                            path.Insert(0, step);
                        }

                        return path;
                    }

                    // if the tile exists, has not been explored or added to the fringe yet, and it is pathable
                    if (neighbor != null && !cameFrom.ContainsKey(neighbor) && neighbor.IsPathable())
                    {
                        // add it to the tiles to be explored and add where it came from.
                        fringe.Enqueue(neighbor);
                        cameFrom.Add(neighbor, inspect);
                    }

                } // foreach(neighbor)

            } // while(fringe not empty)

            // if you're here, that means that there was not a path to get to where you want to go.
            //   in that case, we'll just return an empty path.
            return new List<Tile>();
        }

        // <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
        // you can add additional methods here for your AI to call
		private void DisplayMap() {
			Console.SetCursorPosition(0, 0);
			Console.BackgroundColor = ConsoleColor.White;
			Console.Write(new string(' ', this.Game.MapWidth + 2));
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine();
			for (int y = 0; y < this.Game.MapHeight; y++) {
				Console.BackgroundColor = ConsoleColor.White;
				Console.Write(' ');
				for (int x = 0; x < this.Game.MapWidth; x++) {
					Tile t = this.Game.Tiles[y * this.Game.MapWidth + x];

					// Background color
					if (t.Machine != null) {
						Console.BackgroundColor = ((t.Machine.OreType == "redium") ? ConsoleColor.DarkRed : ConsoleColor.DarkBlue);
					} else if (t.IsWall == true) {
						if (t.Decoration == 1) {
							Console.BackgroundColor = ConsoleColor.Black;
						} else {
							Console.BackgroundColor = ConsoleColor.DarkGray;
						}
					} else {
						if (t.Decoration == 1) {
							Console.BackgroundColor = ConsoleColor.DarkYellow;
						} else {
							Console.BackgroundColor = ConsoleColor.Gray;
						}
					}

					// Character to display
					char foreground = '·';
					Console.ForegroundColor = ConsoleColor.White;

					// Tile specific stuff
					if (t.Unit != null) {
						Console.ForegroundColor = t.Unit.Owner == this.Player ? ConsoleColor.Green : ConsoleColor.Red;
						foreground = 'U'; //t.Unit.ShipHealth > 0 ? 'S' : 'C';
                    }
                    else if(t.Owner != null) {
                        if(t.Type == "spawn") {
                            foreground = 'S';
                            Console.ForegroundColor = t.Owner == this.Player ? ConsoleColor.Green : ConsoleColor.Red;
                        } else if(t.Type == "generator") {
                            foreground = 'G';
                            Console.ForegroundColor = t.Owner == this.Player ? ConsoleColor.Green : ConsoleColor.Red;
                        }
						/*if (false && this.Game.Units.Any(u => u.Path.Contains(t))) {
							Console.ForegroundColor = ConsoleColor.Yellow;
							foreground = '*';
						} else if (t.Decoration) {
							Console.ForegroundColor = ConsoleColor.White;
							foreground = '.';*/
					} else if(t.Type == "conveyor") {
                        if(t.Direction == "north") {
                            foreground = '↑';
                        } else if(t.Direction == "east") {
                            foreground = '→';
                        } else if(t.Direction == "west") {
                            foreground = '←';
                        } else if(t.Direction == "blank") {
                            foreground = '_';
                        } else {
                            foreground = '↓';
                        }
                    }

					Console.Write(foreground);
				}

				Console.BackgroundColor = ConsoleColor.White;
				Console.Write(' ');
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write(y);
				Console.WriteLine();
			}

			Console.BackgroundColor = ConsoleColor.White;
			Console.Write(new string(' ', this.Game.MapWidth + 2));
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine();

			// Clear everything past here
			int left = Console.CursorLeft;
			int top = Console.CursorTop;
			Console.Write(new string(' ', Math.Max(Console.WindowHeight, Console.WindowWidth * (Console.WindowHeight - top) - 1)));
			Console.SetCursorPosition(left, top);
		}
		// <<-- /Creer-Merge: methods -->>
		#endregion
	}
}
