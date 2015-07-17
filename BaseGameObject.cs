using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs
{
    abstract class BaseGameObject
    {
        protected BaseGame Game;
        private Client Client;
        public string ID { get; protected set; }

        public void SetGameAndClient(BaseGame game, Client client)
        {
            this.Game = game;
            this.Client = client;
        }

        protected T RunOnServer<T>(string functionName, object[] args = null)
        {
            return this.Client.RunOnServer<T>(this, functionName, args);
        }

        public virtual void ApplyDeltaState(JObject delta)
        {
            // intended to be "written" by Creer
        }
    }
}
