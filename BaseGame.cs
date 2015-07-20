using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs
{
    abstract class BaseGame
    {
        public Dictionary<string, BaseGameObject> GameObjects { get; set; } // mapping of the game object ID (which is a string) to the actual game object. IDs are never re-used so this helps us grab and check what game objects have been created
        public string Name { get; protected set; }

        public BaseGame()
        {
            this.Name = "NO_NAME";
            this.GameObjects = new Dictionary<string, BaseGameObject>();
        }
    }
}
