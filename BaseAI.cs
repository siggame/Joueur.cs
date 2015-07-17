using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs
{
    abstract class BaseAI
    {
        public BaseAI()
        {
        }

        public virtual void ConnectToGameAs(BaseGame baseGame, string playerID)
        {
            // inheriting class will write this logic via Creer
        }

        public virtual bool HasPlayer()
        {
            return false; // inheriting class will write this logic via Creer
        }

        public virtual void Start()
        {

        }

        public virtual void Ended(bool won, string reason)
        {

        }

        public virtual void GameUpdated()
        {

        }

        public Object DoOrder(string order, List<JToken> args)
        {
            var method = this.GetType().GetMethod("CastOrder_" + order);

            if (method != null)
            {
                var returned = method.Invoke(this, args.ToArray<JToken>());
                return returned;
            }
            else
            {
                Console.WriteLine("Error: could not find order method for '" + order + "'");
            }

            return default(JToken);
        }
    }
}
