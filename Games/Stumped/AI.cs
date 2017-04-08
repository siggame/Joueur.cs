// This is where you build your AI for the Stumped game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Joueur.cs.Games.Stumped
{
    /// <summary>
    /// This is where you build your AI for the Stumped game.
    /// </summary>
    class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself, it contains all the information about the current game
        /// </summary>
        public readonly Stumped.Game Game;
        /// <summary>
        /// This is your AI's player. This AI class is not a player, but it should command this Player.
        /// </summary>
        public readonly Stumped.Player Player;
        #pragma warning restore 0169
        #pragma warning restore 0649

        // you can add additional properties here for your AI to use
        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>string of you AI's name.</returns>
        public override string GetName()
        {
            return "Stumped C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
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
            // This is your Stumped ShellAI
            // ShellAI is intended to be a simple AI that does everything possible in the game, but plays the game very poorly
            // This example code does the following:
            // 1. Grabs a single beaver
            // 2. tries to move the beaver
            // 3. tries to do one of the 5 actions on it
            // 4. Grabs a lodge and tries to recruit a new beaver

            // NOTE: If you're executing from Visual Studio (or a similar IDE), you should modify the project's Properties file
            //       and set your session name in the Debug tab

            // First let's do a simple print statement telling us what turn we are on
            Console.WriteLine($"My Turn {this.Game.CurrentTurn}");

            // 1. get the first beaver to try to do things with
            Beaver beaver = this.Player.Beavers.FirstOrDefault();

            // if we have a beaver, and it's not distracted, and it is alive (health greater than 0)
            if (beaver != null && beaver.TurnsDistracted == 0 && beaver.Health > 0)
            {
                // then let's try to do stuff with it

                // 2. Try to move the beaver
                if (beaver.Moves >= 3)
                {
                    // then it has enough moves to move in any direction, so let's move it

                    // find a spawner to move to
                    Tile target = null;
                    foreach (Tile tile in this.Game.Tiles)
                    {
                        if (tile.Spawner != null && tile.Spawner.Health > 1)
                        {
                            // then we found a healthy spawner, let's target that tile to move to
                            target = tile;
                            break;
                        }
                    }

                    // If we found a target tile, path to it
                    if (target != null)
                    {
                        // use the pathfinding algorithm below to make a path to the spawner's target tile
                        List<Tile> path = this.FindPath(beaver.Tile, target);

                        // if there is a path, move to it
                        //      Count 0 means no path could be found to the tile
                        //      Count 1 means the target is adjacent, and we can't move onto the same tile as the spawner
                        //      Count 2+ means we have to move towards it
                        if (path.Count > 1)
                        {
                            Console.WriteLine($"Moving Beaver #{beaver.Id} towards Tile #{target.Id}");
                            beaver.Move(path[0]);
                        }
                    }
                }

                // 3. Try to do an action on the beaver
                if (beaver.Actions > 0)
                {
                    // then let's try to do an action!

                    // Do a random action!
                    string action = RandomElement(new string[] {"buildLodge", "attack", "pickup", "drop", "harvest"});

                    // how much this beaver is carrying, used for calculations
                    int load = beaver.Branches + beaver.Food;

                    switch (action)
                    {
                        case "buildLodge":
                            // if the beaver has enough branches to build a lodge
                            //   and the tile does not already have a lodge, then do so
                            if (beaver.Branches + beaver.Tile.Branches >= this.Player.BranchesToBuildLodge && beaver.Tile.LodgeOwner == null)
                            {
                                Console.WriteLine($"Beaver #{beaver.Id} building lodge");
                                beaver.BuildLodge();
                            }
                            break;
                        case "attack":
                            // look at all our neighbor tiles and if they have a beaver attack it!
                            foreach (Tile neighbor in Shuffled(beaver.Tile.GetNeighbors()))
                            {
                                if (neighbor.Beaver != null)
                                {
                                    Console.WriteLine($"Beaver #{beaver.Id} attacking Beaver #{neighbor.Beaver.Id}");
                                    beaver.Attack(neighbor.Beaver);
                                    break;
                                }
                            }
                            break;
                        case "pickup":
                            // make an array of our neighboring tiles + our tile as all can be picked up from
                            IList<Tile> pickupTiles = Shuffled(beaver.Tile.GetNeighbors().Concat(new Tile[] {beaver.Tile}).ToList());

                            // if the beaver can carry more resources, try to pick something up
                            if (load < beaver.Job.CarryLimit)
                            {
                                foreach (Tile tile in pickupTiles)
                                {
                                    // try to pickup branches
                                    if (tile.Branches > 0)
                                    {
                                        Console.WriteLine($"Beaver #{beaver.Id} picking up 1 branch");
                                        beaver.Pickup(tile, "branches", 1);
                                        break;
                                    }
                                    // try to pickup food
                                    else if (tile.Food > 0)
                                    {
                                        Console.WriteLine($"Beaver #{beaver.Id} picking up 1 food");
                                        beaver.Pickup(tile, "food", 1);
                                        break;
                                    }
                                }
                            }
                            break;
                        case "drop":
                            // choose a random tile from our neighbors + out tile to drop stuff on
                            IList<Tile> dropTiles = Shuffled(beaver.Tile.GetNeighbors().Concat(new Tile[] {beaver.Tile}).ToList());

                            // find a valid tile to drop resources onto
                            Tile tileToDropOn = null;
                            foreach (Tile tile in dropTiles)
                            {
                                if (tile.Spawner == null)
                                {
                                    tileToDropOn = tile;
                                    break;
                                }
                            }

                            // if there is a tile that resources can be dropped on
                            if (tileToDropOn != null)
                            {
                                // if we have branches to drop
                                if (beaver.Branches > 0)
                                {
                                    Console.WriteLine($"Beaver #{beaver.Id} dropping 1 branch");
                                    beaver.Drop(tileToDropOn, "branches", 1);
                                }
                                // or if we have food to drop
                                else if (beaver.Food > 0)
                                {
                                    Console.WriteLine($"Beaver #{beaver.Id} dropping 1 food");
                                    beaver.Drop(tileToDropOn, "food", 1);
                                }
                            }
                            break;
                        case "harvest":
                            // if we can carry more, try to harvest something
                            if (load < beaver.Job.CarryLimit)
                            {
                                // try to find a neighboring tile with a spawner on it to harvest from
                                foreach (Tile neighbor in Shuffled(beaver.Tile.GetNeighbors()))
                                {
                                    // if it has a spawner on that tile, harvest from it
                                    if (neighbor.Spawner != null)
                                    {
                                        Console.WriteLine($"Beaver #{beaver.Id} harvesting Spawner #{neighbor.Spawner.Id}");
                                        beaver.Harvest(neighbor.Spawner);
                                        break;
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            // now try to spawn a beaver if we have lodges

            // 4. Get a lodge to try to spawn something at
            Tile lodge = RandomElement(this.Player.Lodges);

            // if we found a lodge and it has no beaver blocking it
            if (lodge != null && lodge.Beaver == null)
            {
                // then this lodge can have a new beaver appear here

                // We need to know how many beavers we have to see if they are free to spawn
                int aliveBeavers = this.Player.Beavers.Count(b => b.Health > 0);

                // and we need a Job to spawn
                Job job = RandomElement(this.Game.Jobs);

                // if we have less beavers than the freeBeavers count, it is free to spawn
                //    otherwise if that lodge has enough food on it to cover the job's cost
                if (aliveBeavers < this.Game.FreeBeaversCount || lodge.Food >= job.Cost)
                {
                    // then spawn a new beaver of that job!
                    Console.WriteLine($"recruiting Job #{job.Id} to Tile #{lodge.Id}");
                    job.Recruit(lodge);
                }
            }

            Console.WriteLine("Done with our turn");
            return true; // to signify that we are truly done with this turn
        }

        // A random number generator, used for ShellAI. Feel free to remove if you gut C
        public Random rand = new Random();

        /// <summary>
        /// Simply returns a random element of an array
        /// </summary>
        public T RandomElement<T>(IList<T> items) where T : class
        {
            return items.Any() ? items[rand.Next(items.Count())] : null;
        }

        /// <summary>
        /// Simply returns a shuffled copy of an array
        /// </summary>
        public IList<T> Shuffled<T>(IList<T> a)
        {
            a = a.ToList();
            for (int i = a.Count(); i > 0; i--)
            {
                int j = rand.Next(i);
                T x = a[i - 1];
                a[i - 1] = a[j];
                a[j] = x;
            }
            return a;
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
