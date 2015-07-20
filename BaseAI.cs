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
            var method = this.GetType().GetMethod("CastOrder_" + order, System.Reflection.BindingFlags.NonPublic);

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
