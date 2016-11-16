// This is where you build your AI for the Saloon game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>string of you AI's name.</returns>
        public override string GetName()
        {
            return "Saloon C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game object and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI, or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
            base.GameUpdated();
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
            base.Ended(won, reason);
        }


        /// <summary>
        /// This is called every time it is this AI.player's turn.
        /// </summary>
        /// <returns>Represents if you want to end your turn. True means end your turn, False means to keep your turn going and re-call this function.</returns>
        public bool RunTurn()
        {
            // This is "ShellAI", some basic code we've provided that does
            // everything in the game for demo purposed, but poorly so you
            // can get to optimizing or overwriting it ASAP
            //
            // ShellAI does a few things:
            // 1. Tries to spawn a new Cowboy
            // 2. Tries to move to a Piano
            // 3. Tries to play a Piano
            // 4. Tries to act

            Console.WriteLine("Start of my turn: " + Game.CurrentTurn);

            // Find the active cowboy to try to do things with
            Cowboy activeCowboy = null;
            foreach (Cowboy cowboy in this.Player.Cowboys)
            {
                if(!cowboy.IsDead)
                {
                    activeCowboy = cowboy;
                    break;
                }
            }

            // A random generator we use to do random silly things
            Random random = new Random();

            // 1. Try to spawn a cowboy.

            // Randomly select a job.
            string newJob = this.Game.Jobs.ElementAt(random.Next(0, this.Game.Jobs.Count));

            // Count cowboys with selected job
            int jobCount = 0;
            foreach (Cowboy cowboy in this.Player.Cowboys)
            {
                if(!cowboy.IsDead && cowboy.Job == newJob)
                {
                    jobCount++;
                }
            }

            // Call in the new cowboy with that job if there aren't too many
            //   cowboys with that job already.
            if (this.Player.YoungGun.CanCallIn && jobCount < this.Game.MaxCowboysPerJob)
            {
                Console.WriteLine("1. Calling in: " + newJob);
                this.Player.YoungGun.CallIn(newJob);
            }

            // Now lets use him
            if (activeCowboy != null)
            {
                // 2. Try to move to a piano.

                // Find a piano.
                Furnishing piano = null;
                foreach (Furnishing furnishing in this.Game.Furnishings)
                {
                    if (furnishing.IsPiano && !furnishing.IsDestroyed)
                    {
                        piano = furnishing;
                        break;
                    }
                }

                // There will always be pianos or the game will end. No need to check for existence.
                // Attempt to move toward the piano by finding a path.
                if (activeCowboy.CanMove && !activeCowboy.IsDead)
                {
                    Console.WriteLine("Trying to use Cowboy #" + activeCowboy.Id);

                    // Find a path of tiles to the piano from our active cowboy's tile
                    List<Tile> path = this.FindPath(activeCowboy.Tile, piano.Tile);

                    // if there is a path, move along it
                    //      Count of 0 means no path could be found to the tile
                    //      Count of 1 means the piano is adjacent, and we can't move onto the same tile as the piano
                    if (path.Count > 1)
                    {
                        Console.WriteLine("2. Moving to Tile #" + path.First().Id);
                        activeCowboy.Move(path.First());
                    }
                }

                // 3. Try to play a nearby piano.
                if (!activeCowboy.IsDead && activeCowboy.TurnsBusy == 0)
                {
                    List<Tile> neighbors = activeCowboy.Tile.GetNeighbors();
                    foreach (Tile tile in neighbors)
                    {
                        if (tile.Furnishing != null && tile.Furnishing.IsPiano)
                        {
                            Console.WriteLine("3. Playing piano (Furnishing) #" + tile.Furnishing.Id);
                            activeCowboy.Play(tile.Furnishing);
                            break;
                        }
                    }
                }

                // 4. Try to act with active cowboy
                if (!activeCowboy.IsDead && activeCowboy.TurnsBusy == 0)
                {
                    // Get a random neighboring tile.
                    var neighbors = activeCowboy.Tile.GetNeighbors();
                    Tile neighbor = neighbors.ElementAt(random.Next(0, neighbors.Count));

                    // Based on job, act accordingly.
                    if (activeCowboy.Job == "Bartender")
                    {
                        // Bartenders dispense brews freely, but they still manage to get their due.
                        string direction = Tile.Directions[random.Next(0, Tile.Directions.Length)];
                        Console.WriteLine("4. Bartender acting on Tile #" + neighbor.Id + " with drunkDirection: " + direction);
                        activeCowboy.Act(neighbor, direction);
                    }
                    else if (activeCowboy.Job == "Brawler")
                    {
                        // Brawlers' brains are so pickled, they hardly know friend from foe.
                        // Probably don't ask them act on your behalf.
                        Console.WriteLine("4. Brawlers cannot act");
                    }
                    else if (activeCowboy.Job == "Sharpshooter")
                    {
                        // Sharpshooters aren't as quick as they used to be, and all that ruckus around them
                        // requires them to focus when taking aim.
                        if (activeCowboy.Focus > 0)
                        {
                            Console.WriteLine("4. Sharpshooter acting on Tile #" + neighbor.Id);
                            activeCowboy.Act(neighbor);
                        }
                        else
                        {
                            Console.WriteLine("4. Sharpshooter doesn't have enough focus. (focus == " + activeCowboy.Focus + ")");
                        }
                    }
                }
            }

            Console.WriteLine("Ending my turn.");

            return true;
        }

        /// <summary>
        /// A very basic path finding algorithm (Breadth First Search) that when given a starting Tile, will return a valid path to the goal Tile.
        /// </summary>
        /// <remarks>
        /// This is NOT an optimal pathfinding algorithm. It is intended as a stepping stone if you want to improve it.
        /// </remarks>
        /// <param name="start">the starting Tile</param>
        /// <param name="goal">the goal Tile</param>
        /// <returns>A List of Tiles representing the path, the the first element being a valid adjacent Tile to the start, and the last element being the goal. Or an empty list if no path found.</returns>
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
            while (fringe.Count > 0)
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
        #endregion
    }
}
