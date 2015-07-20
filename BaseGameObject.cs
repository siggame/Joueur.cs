using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs
{
    abstract class BaseGameObject
    {
        public string Id { get; protected set; }

        protected T RunOnServer<T>(string functionName, object[] args = null)
        {
            return Client.Instance.RunOnServer<T>(this, functionName, args);
        }
    }
}
