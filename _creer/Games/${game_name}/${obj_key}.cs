// ${obj['description']}

// DO NOT MODIFY THIS FILE
// Never try to directly create an instance of this class, or modify its member variables.
// Instead, you should only be reading its variables and calling its functions.
<%include file="functions.noCreer" />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
${merge("// ", "usings", "// you can add additional using(s) here", optional=True)}
<%parent_classes = list(obj['parentClasses'])

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
${"""/// <summary>
/// {}
/// </summary>
""".format(shared['c#']['escape'](obj['description'])) if obj_key == 'Game' else ''
}namespace Joueur.cs.Games.${game_name}
{
    /// <summary>
    /// ${shared['c#']['escape'](obj['description'])}
    /// </summary>
    public class ${obj_key} : ${inherit_str}
    {
        #region Properties
% for attr_name in obj['attribute_names']:
<% attr_parms = obj['attributes'][attr_name]
if (obj_key == "Game" and (attr_name == "gameObjects" or attr_name == "name")) or attr_name == "id" or attr_name == "gameObjectName":
    continue
%>        /// <summary>
        /// ${shared['c#']['escape'](attr_parms['description'])}
        /// </summary>
        public ${shared['c#']['type'](attr_parms['type'])} ${upcase_first(attr_name)} { get; protected set; }

% endfor

${merge("        // ", "properties", "        // you can add additional properties(s) here. None of them will be tracked or updated by the server.", optional=True)}
        #endregion


        #region Methods
        /// <summary>
        /// Creates a new instance of ${obj_key}. Used during game initialization, do not call directly.
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
<% function_params = obj['functions'][function_name]
arg_strings = []
return_type = None
%>        /// <summary>
        /// ${shared['c#']['escape'](function_params['description'])}
        /// </summary>
% if 'arguments' in function_params:
% for arg_parms in function_params['arguments']:
        /// <param name="${arg_parms['name']}">${shared['c#']['escape'](arg_parms['description'])}</param>
% endfor
% endif
% if function_params['returns']:
<% return_type = shared['c#']['type'](function_params['returns']['type'])
%>        /// <returns>${shared['c#']['escape'](function_params['returns']['description'])}</returns>
% endif
        public ${return_type or 'void'} ${upcase_first(function_name)}(${shared['c#']['args'](function_params['arguments'])})
        {
            ${"return " if function_params['returns'] else ""}this.RunOnServer<${return_type or 'object'}>("${function_name}", new Dictionary<string, object> {
% for i, arg_parms in enumerate(function_params['arguments']):
                {"${arg_parms['name']}", ${arg_parms['name']}}${"," if (i+1) < len(function_params['arguments']) else ""}
% endfor
            });
        }

% endfor

% if 'Tile' in game_objs:
% if 'TiledGame' in game['serverParentClasses']: #// then we need to add some client side utility functions
% if obj_key == 'Game':
        /// <summary>
        /// Gets the Tile at a specified (x, y) position
        /// </summary>
        /// <param name="x">integer between 0 and the MapWidth</param>
        /// <param name="y">integer between 0 and the MapHeight</param>
        /// <returns>the Tile at (x, y) or null if out of bounds</returns>
        public Tile GetTileAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.MapWidth || y >= this.MapHeight)
            {
                // out of bounds
                return null;
            }

            return this.Tiles[x + y * this.MapWidth];
        }
% elif obj_key == 'Tile':
        /// <summary>
        /// Gets the neighbors of this Tile
        /// </summary>
        /// <returns>The neighboring (adjacent) Tiles to this tile</returns>
        public List<Tile> GetNeighbors()
        {
            var list = new List<Tile>();

            if (this.TileNorth != null)
            {
                list.Add(this.TileNorth);
            }

            if (this.TileEast != null)
            {
                list.Add(this.TileEast);
            }

            if (this.TileSouth != null)
            {
                list.Add(this.TileSouth);
            }

            if (this.TileWest != null)
            {
                list.Add(this.TileWest);
            }

            return list;
        }

        /// <summary>
        /// Checks if a Tile is pathable to units
        /// </summary>
        /// <returns>True if pathable, false otherwise</returns>
        public bool IsPathable()
        {
${merge("            // ", "is_pathable_builtin", "            return false; // DEVELOPER ADD LOGIC HERE")}
        }

        /// <summary>
        /// Checks if this Tile has a specific neighboring Tile
        /// </summary>
        /// <param name="tile">Tile to check against</param>
        /// <returns>true if the tile is a neighbor of this Tile, false otherwise</returns>
        public bool HasNeighbor(Tile tile)
        {
            if (tile == null)
            {
                return false;
            }

            return (this.TileNorth == tile || this.TileEast == tile || this.TileSouth == tile || this.TileEast == tile);
        }
% endif
% endif

% endif
${merge("        // ", "methods", "        // you can add additional method(s) here.", optional=True)}
        #endregion
    }
}
