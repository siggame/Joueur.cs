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
        protected BaseAI()
        {
        }

        public virtual string GetName()
        {
            return "C# Player";
        }

        public virtual void Start()
        {
            // the inheriting AI can add code to this inherited function
        }

        public virtual void Ended(bool won, string reason)
        {
            // the inheriting AI can add code to this inherited function
        }

        public virtual void Invalid(string message)
        {
            // the inheriting AI can add code to this inherited function
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid: " + message);
            Console.ResetColor();
        }

        public virtual void GameUpdated()
        {
            // the inheriting AI can add code to this inherited function
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

                try
                {
                    var returned = method.Invoke(this, unserializedArgs);

                    return returned;
                }
                catch(Exception exception)
                {
                    ErrorHandler.HandleError(ErrorHandler.ErrorCode.AI_ERRORED, exception, "AI errored while executing order '" + order + "'.");
                }
            }
            else
            {
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.REFLECTION_FAILED, "Could not find a method for the AI to execute order '" + order + "'.");
            }

            return null; // should not reach here
        }
    }
}
