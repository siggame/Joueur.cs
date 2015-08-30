// ${header}
// ${obj['description']}
<%include file="functions.noCreer" />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
${merge("// ", "usings", "// you can add addtional using(s) here")}
<%parent_classes = obj['parentClasses']

if not parent_classes:
    if obj_key == "Game":
        parent_classes = [ "BaseGame" ]
    else:
        parent_classes = [ "BaseGameObject" ]
else:
    for i in range(len(parent_classes)):
        parent_classes[i] = game_name + "." + parent_classes[i]

inherit_str = ", ".join(parent_classes) # note: this could have multi-inheritance, which C# does not support. Will need to make some sore of Interface system in the future, or combine all multi-inheritied features into one for C#

%>
namespace Joueur.cs.Games.${game_name}
{
    /// <summary>
    /// ${obj['description']}
    /// </summary>
    class ${obj_key} : ${inherit_str}
    {
        #region Properties
% for attr_name in obj['attribute_names']:
<% attr_parms = obj['attributes'][attr_name]
if (obj_key == "Game" and (attr_name == "gameObjects" or attr_name == "name")) or attr_name == "id":
    continue
%>        /// <summary>
        /// ${attr_parms['description']}
        /// </summary>
        public ${shared['c#']['type'](attr_parms['type'])} ${upcase_first(attr_name)} { get; protected set; }

% endfor

${merge("        // ", "properties", "        // you can add addtional properties(s) here. None of them will be tracked or updated by the server.")}
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of {$obj_key}. Used during game initialization, do not call directly.
        /// </summary>
        protected ${obj_key}() : base()
        {
% if obj_key == "Game":
            this.Name = "${game_name}";

% endif
% for attr_name in obj['attribute_names']:
% if obj['attributes'][attr_name]['type']['name'] == "list" or obj['attributes'][attr_name]['type']['name'] == "dictionary":
% if obj_key != "Game" or attr_name != "gameObjects": # special case where the value needs to be BaseGameObject, not GameObject as the prototype claims
            this.${upcase_first(attr_name)} = ${shared['c#']['default'](obj['attributes'][attr_name]['type'], obj['attributes'][attr_name]['default'])};
% endif
% endif
% endfor
        }

% for function_name in obj['function_names']:
<% function_parms = obj['functions'][function_name]
arg_strings = []
return_type = None
%>        /// <summary>
        /// ${function_parms['description']}
        /// </summary>
% if 'arguments' in function_parms:
% for arg_parms in function_parms['arguments']:
        /// <param name="${arg_parms['name']}">${arg_parms['description']}</param>
% endfor
% endif
% if function_parms['returns']:
<% return_type = shared['c#']['type'](function_parms['returns']['type'])
%>        /// <returns>${function_parms['returns']['description']}</returns>
% endif
        public ${return_type or 'void'} ${upcase_first(function_name)}(${shared['c#']['args'](function_parms['arguments'])})
        {
            ${"return " if function_parms['returns'] else ""}this.RunOnServer<${return_type or 'object'}>("${function_name}", new Dictionary<string, object> {
% for i, arg_parms in enumerate(function_parms['arguments']):
                {"${arg_parms['name']}", ${arg_parms['name']}}${"," if (i+1) < len(function_parms['arguments']) else ""}
% endfor
            });
        }
% endfor

${merge("        // ", "methods", "        // you can add addtional method(s) here.")}
        #endregion
    }
}
