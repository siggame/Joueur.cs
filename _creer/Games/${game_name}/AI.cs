// This is where you build your AI for the ${game_name} game.
<%include file="functions.noCreer" />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
${merge("// ", "usings", "// you can add additional using(s) here", optional=True)}

namespace Joueur.cs.Games.${game_name}
{
    /// <summary>
    /// This is where you build your AI for ${game_name}.
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

${merge("        // ", "properties", '        // you can add additional properties here for your AI to use')}
        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>Your AI's name</returns>
        public override string GetName()
        {
${merge("            // ", "get-name", '            return "' + game_name + ' C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!')}
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
${merge("            // ", "start", '            base.Start();')}
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update, this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
${merge("            // ", "game-updated", '            base.GameUpdated();')}
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
${merge("            // ", "ended", '            base.Ended(won, reason);')}
        }

% for function_name in ai['function_names']:
<% function_parms = ai["functions"][function_name];
arg_strings = []
%>
        /// <summary>
        /// ${function_parms['description']}
        /// </summary>
% if 'arguments' in function_parms:
% for arg_parms in function_parms['arguments']:
<% arg_strings.append(shared['c#']['type'](arg_parms['type']) + " " + arg_parms['name']) # syntax highlighter freaking out, needs ;
%>        /// <param name="${arg_parms['name']}">${arg_parms['description']}</param>
% endfor
% endif
% if function_parms['returns']:
        /// <returns>${function_parms['returns']['description']}</returns>
% endif
        public ${shared['c#']['type'](function_parms['returns']['type']) if function_parms['returns'] else "void"} ${upcase_first(function_name)}(${", ".join(arg_strings)})
        {
${merge("            // ", function_name,
"""            // Put your game logic here for {0}
            return {1};
""".format(function_name, shared['c#']['default'](function_parms['returns']['type'], function_parms['returns']['default']) if function_parms['returns'] else "")
)}
        }
% endfor

% if 'TiledGame' in game['serverParentClasses']: #// then we need to add some client side utility functions
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

% endif
${merge("        // ", "methods", '        // you can add additional methods here for your AI to call', optional=True)}
        #endregion
    }
}