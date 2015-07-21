using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Joueur.cs
{
    abstract class BaseAI
    {
        public BaseAI()
        {
        }

        public virtual string GetName()
        {
            throw new NotImplementedException();
        }

        public virtual void Start()
        {

        }

        public virtual bool HasPlayer()
        {
            return false; // _AI should impliment this
        }

        public virtual void Ended(bool won, string reason)
        {

        }

        public virtual void GameUpdated()
        {

        }

        public Object DoOrder(string order, List<JToken> args)
        {
            var gameManager = Client.Instance.GameManager;
            var method = this.GetType().GetMethod(gameManager.CSharpCase(order));

            if (method != null)
            {
                var unserializedArgs = new object[args.Count];
                int i = 0;
                foreach (var arg in args)
                {
                    unserializedArgs[i++] = gameManager.Unserialize(arg);
                }

                var returned = method.Invoke(this, unserializedArgs);

                return returned;
            }
            else
            {
                throw new Exception("Error: could not find order method for '" + order + "'");
            }
        }
    }
}
