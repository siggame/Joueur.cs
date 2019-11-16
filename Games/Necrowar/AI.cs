// This is where you build your AI for the Necrowar game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <<-- Creer-Merge: usings -->> - Code you add between this comment and the end comment will be preserved between Creer re-runs.
// you can add additional using(s) here
// <<-- /Creer-Merge: usings -->>

namespace Joueur.cs.Games.Necrowar
{
    /// <summary>
    /// This is where you build your AI for Necrowar.
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
        public IList<Necrowar.Unit> miners;
        public IList<Necrowar.Unit> builders;
        public IList<Necrowar.Unit> units;
        public IList<Necrowar.Tile> goldMines;
        public IList<Necrowar.Tile> grassByPath;
        public Necrowar.Tower enemyCastle;
        public Necrowar.Tower myCastle;
        public Necrowar.Tile spawnUnitTile;
        public Necrowar.Tile spawnWorkerTile;
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
            return "Necrowar C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
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

            // Fill our tracking variables with data
            foreach (Tile tile in this.Player.Side)
            {
                if (tile.IsUnitSpawn)
                    this.spawnUnitTile = tile;
                else if (tile.IsWorkerSpawn)
                    this.spawnWorkerTile = tile;
                else if (tile.IsGoldMine)
                    this.goldMines.Add(tile);
                else if (tile.IsGrass)
                    foreach (Tile neighbor in tile.GetNeighbors())
                        if (neighbor.IsPath)
                            this.grassByPath.Add(tile);
            }

            this.enemyCastle = this.Player.Opponent.Towers[0];
            this.myCastle = this.Player.Towers[0];

            // Now we should have our spawn tiles, mines, and tower building locations!
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
            // Remove any dead units from our personal tracking lists
            foreach (Unit unit in this.miners)
            {
                if (unit.Health <= 0)
                    this.miners.Remove(unit);
            }

            foreach (Unit unit in this.builders)
            {
                if (unit.Health <= 0)
                    this.builders.Remove(unit);
            }
            
            foreach (Unit unit in this.units)
            {
                if (unit.Health <= 0)
                    this.units.Remove(unit);
            }
            
            // Spawn all three of our chosen unit types if necessary
            if (this.miners.Count == 0)
                if (this.spawnWorkerTile.SpawnWorker())
                    this.miners.Add(this.Player.Units[this.Player.Units.Count - 1]);

            if (this.builders.Count == 0)
                if (this.spawnWorkerTile.SpawnWorker())
                    this.builders.Add(this.Player.Units[this.Player.Units.Count - 1]);

            if (this.units.Count == 0)
                if (this.spawnUnitTile.SpawnUnit("ghoul"))
                    this.units.Add(this.Player.Units[this.Player.Units.Count - 1]);

            // Activate each of our defined unit types
            IList<Tile> path;
            foreach (Unit unit in this.miners)
            {
                if (unit.Tile.IsGoldMine)
                    unit.Mine(unit.Tile);
                else
                {
                    path = this.FindPathWorker(unit.Tile, this.goldMines[0]);
                    foreach (Tile tile in path)
                    {
                        if (unit.Moves <= 0)
                            break;
                        unit.Move(tile);
                    }
                }
            }
            
            foreach (Unit unit in this.builders)
            {
                path = this.FindPathWorker(unit.Tile, this.grassByPath[0]);
                foreach (Tile tile in path)
                {
                    if (unit.Moves <= 0)
                        break;
                    unit.Move(tile);
                }
                if (path.Count == 0 && unit.Moves > 0)
                    unit.Build("arrow");
            }
        
            foreach (Unit unit in this.units)
            {
                path = this.FindPathWorker(unit.Tile, this.enemyCastle.Tile.TileNorth);
                foreach (Tile tile in path)
                {
                    if (unit.Moves <= 0)
                        break;
                    unit.Move(tile);
                }
                if (path.Count == 0 && unit.Moves > 0)
                    unit.Attack(this.enemyCastle.Tile);
            }

            // Make towers attack anything adjacent to them
            // Note that they are not using their full range
            IList<Tile> adjacent;
            foreach (Tower tower in this.Player.Towers)
            {
                adjacent = tower.Tile.GetNeighbors();
                foreach (Tile tile in adjacent)
                    if (tile.Unit != null && tile.Unit.Owner == this.Player.Opponent)
                        tower.Attack(tile);
            }

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

        List<Tile> FindPathWorker(Tile start, Tile goal)
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
                    if (neighbor != null && !cameFrom.ContainsKey(neighbor) && neighbor.IsPathableWorker())
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
        // <<-- /Creer-Merge: methods -->>
        #endregion
    }
}
