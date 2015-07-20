using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    class GameObject : BaseGameObject
    {
        public List<string> Logs { get; protected set; }

        public GameObject() : base()
        {
            this.Logs = new List<string>();
        }

        public void Log(string message)
        {
            this.RunOnServer<Object>("log", new object[]
            {
                message
            });
        }
    }
}
