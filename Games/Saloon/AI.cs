// This is where you build your AI for the Saloon game.

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
    /// This is where you build your AI for the Saloon game.
    /// </summary>
    class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself, it contains all the information about the current game
        /// </summary>
        public readonly Saloon.Game Game;
        /// <summary>
        /// This is your AI's player. This AI class is not a player, but it should command this Player.
        /// </summary>
        public readonly Saloon.Player Player;
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
        /// <returns>string of you AI's name.</returns>
        public override string GetName()
        {
            // <<-- Creer-Merge: get-name -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
            return "Saloon C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
            // <<-- /Creer-Merge: get-name -->>
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game object and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI, or start tracking game objects.
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
        /// If a function you call triggers an update this will be called before that function returns.
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
        /// You can do any cleanup of you AI here, or do custom logging. After this function returns the application will close.
        /// </remarks>
        /// <param name="won">true if your player won, false otherwise</param>
        /// <param name="reason">a string explaining why you won or lost</param>
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

			// This is "ShellAI", some basic code we've provided that does
			// everything in the game for demo purposed, but poorly so you
			// can get to optimzing or overwritting it ASAP
			//
			// ShellAI does a few things:
			// 1. Tries to spawn a new Cowboy
			// 2. Tries to move to a Piano
			// 3. Tries to play a Piano
			// 4. Tries to act

			Console.Write("Start of my turn: " + Game.CurrentTurn);

			Cowboy activeCowboy = null;
			foreach(Cowboy cb in Player.Cowboys)
			{
				if(!cb.IsDead)
				{
					activeCowboy = cb;
					break;
				}
			}

			// 1. Try to spawn a cowboy.

			// Randomly select a job.
			string newJob = Game.Jobs.ElementAt(random.Next(0, Game.Jobs.Count));
			
			// Count cowboys with selected job
			int jobCount = 0;
			foreach(Cowboy cb in Player.Cowboys)
			{
				if(!cb.IsDead && cb.Job == newJob)
					jobCount++;
			}

			// Call in the new cowboy with that job if there aren't too many
			//   cowboys with that job already.
			if(Player.YoungGun.CanCallIn && jobCount < Game.MaxCowboysPerJob)
			{
				Console.Write("1. Calling in: " + newJob);
				Cowboy newCowboy = Player.YoungGun.CallIn(newJob);

				// if there were no active cowboys, set our active one to the one we just called in.
				activeCowboy = (activeCowboy != null ? newCowboy : activeCowboy);
			}

			// Now lets use him
			if(activeCowboy != null)
			{
				// 2. Try to move to a piano.

				// Find a piano.
				Furnishing piano = null;
				foreach(Furnishing f in Game.Furnishings)
				{
					if(f.IsPiano && !f.IsDestroyed)
					{
						piano = f;
						break;
					}
				}

				// There will always be pianos or the game will end. No need to check for existance.
				// Attempt to move toward the piano by finding a path.
				if(activeCowboy.CanMove && !activeCowboy.IsDead)
				{
					Console.Write("Trying to use Cowboy #" + activeCowboy.Id);

					// Path can be empty if no piano to find, or the target piano is our neighbor.
					// The returned path is in reverse. [(neighbor-of-goal), . . . , (neighbor-of-start)]
					// (ie. pull the next step in the path from the back of the returned list)
					List<Tile> path = FindPath(activeCowboy.Tile, piano.Tile);

					// If the path is not empty, move along it.
					if(path.Count > 0)
					{
						Console.Write("2. Moving to Tile #" + path.First().Id);
						activeCowboy.Move(path.Last());
					}
				}

				// 3. Try to play a nearby piano.

				if(!activeCowboy.IsDead && activeCowboy.TurnsBusy == 0)
				{
					List<Tile> neighbors = GetNeighbors(activeCowboy.Tile);
					foreach(Tile t in neighbors)
					{
						if(t.Furnishing != null && t.Furnishing.IsPiano)
						{
							Console.Write("3. Playing piano (furnishing)#" + t.Furnishing);
							activeCowboy.Play(t.Furnishing);
							break;
						}
					}
				}

				// 4. Try to act with active cowboy
				//   yes, you can play and act at the same time...
				if(!activeCowboy.IsDead && activeCowboy.TurnsBusy == 0)
				{
					// Get a random neighboring tile.
					Tile neighbor = GetNeighbors(activeCowboy.Tile).ElementAt(random.Next(0, 4));

					// Based on job, act accordingly.
					if(activeCowboy.Job == "Bartender")
					{
						// Bartenders dispense brews freely, but they still manage to get their due.
						string direction = directions.ElementAt(random.Next(0, 4));
						Console.Write("4. Bartender acting on Tile #" + neighbor.Id + " with drunkDirection: " + direction);
						activeCowboy.Act(neighbor, direction);
					}
					else if(activeCowboy.Job == "Brawler")
					{
						// Brawlers' brains are so pickled, they hardly know friend from foe.
						// Probably don't ask them act on your behalf.
						Console.Write("4. Brawlers cannot act (that's a fact)");
					}
					else if(activeCowboy.Job == "Sharpshooter")
					{
						// Sharpshooters aren't as quick as they used to be, and all that ruckus around them
						// requires them to focus when taking aim.
						if(activeCowboy.Focus > 0)
						{
							Console.Write("4. Sharpshooter acting on Tile #" + neighbor.Id);
							activeCowboy.Act(neighbor);
						}
						else
						{
							Console.Write("4. Sharpshooter doesn't have enough focus. (focus == " + activeCowboy.Focus + ")");
						}
					}
					else
					{
						Console.Write("Something ~spooooooky~ happened. :doot:");
					}
				}
			}

			Console.Write("Ending my turn.");

            return true;
            // <<-- /Creer-Merge: runTurn -->>
        }


		// <<-- Creer-Merge: methods -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
		// you can add additional methods here for your AI to call
		Random random = new Random();
		List<string> directions = new List<string> { "North", "East", "South", "West" };

		// returns the neighbors of the passed tile in a List<Tile>.
		public static List<Tile> GetNeighbors(Tile t)
		{
			return new List<Tile> { t.TileNorth, t.TileEast, t.TileSouth, t.TileWest };
		}

		List<Tile> FindPath(Tile start, Tile goal)
		{
			// no need to make a path to here...
			if(start == goal)
				return new List<Tile>();	
			
			// the tiles that will have their neighbors searched for 'goal'
			Queue<Tile> fringe = new Queue<Tile>();

			// How we got to each tile that went into the fringe.
			Dictionary<Tile, Tile> cameFrom = new Dictionary<Tile, Tile>();

			// Enqueue start as the first tile to have its neighbors searched.
			fringe.Enqueue(start);

			// keep exploring neighbors of neighbors... until there are no more.
			while(fringe.Count > 0)
			{
				// the tile we are currently exploring.
				Tile inspect = fringe.Dequeue();

				// cycle through the tile's neighbors.
				foreach(Tile nb in GetNeighbors(inspect))
				{
					if(nb == goal)
					{
						// Follow the path backward starting at the goal and return it.
						List<Tile> path = new List<Tile>();
						path.Add(goal);
						for(Tile step = inspect; step != start; step = cameFrom[step])
							path.Add(step);
						return path;
					}

					// if the tile exists, has not been explored or added to the fringe yet, and has no furnishing, cowboy or balcony,
					if(nb != null && !cameFrom.ContainsKey(nb) && nb.Furnishing == null && nb.Cowboy == null && nb.IsBalcony == false)
					{
						// add it to the tiles to be explored and add where it came from.
						fringe.Enqueue(nb);
						cameFrom.Add(nb, inspect);
					}

				} // foreach(neighbor)

			} // while(fringe not empty)

			// if you're here, that means that there was not a path to get to where you want to go.
			//   in that case, we'll just return an empty path.
			return new List<Tile>();

		}
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
