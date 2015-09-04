// ${header}
// This is where you build your AI for the ${game_name} game.
<%include file="functions.noCreer" />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
${merge("// ", "usings", "// you can add addtional using(s) here")}

namespace Joueur.cs.Games.${game_name}
{
    class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself, it contains all the information about the current game
        /// </summary>
        public readonly Checkers.Game Game;
        /// <summary>
        /// This is your AI's player. This AI class is not a player, but it should command this Player.
        /// </summary>
        public readonly Checkers.Player Player;
        #pragma warning restore 0169
        #pragma warning restore 0649

${merge("        // ", "properties", '        // you can add additional properties here for your AI to use')}
        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>string of you AI's name.</returns>
        public override string GetName()
        {
${merge("            // ", "get-name", '            return "' + game_name + ' C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!')}
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game object and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI, or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
${merge("            // ", "start", '            base.Start();')}
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
${merge("            // ", "game-updated", '            base.GameUpdated();')}
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
% if function_parms['returns'] != None:
        /// <returns>${function_parms['returns']['description']}</returns>
% endif
        public ${shared['c#']['type'](function_parms['returns']['type'])} ${upcase_first(function_name)}(${", ".join(arg_strings)})
        {
${merge("            // ", function_name,
"""            // Put your game logic here for {0}
            return {1};
""".format(function_name, shared['c#']['default'](function_parms['returns']['type'], function_parms['returns']['default'])))
}
        }
% endfor


${merge("        // ", "methods", '        // you can add additional methods here for your AI to call')}
        #endregion
    }
}
