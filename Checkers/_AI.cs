using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    abstract class _AI : Joueur.cs.BaseAI
    {
        public Joueur.cs.Checkers.Game Game {get; private set; }
        public Joueur.cs.Checkers.Player Player {get; private set; }

        public override void ConnectToGameAs(BaseGame baseGame, string playerID)
        {
            base.ConnectToGameAs(baseGame, playerID);

            this.Game = (Joueur.cs.Checkers.Game)baseGame;
            this.Player = (Joueur.cs.Checkers.Player)this.Game.GetGameObject(playerID);
        }

        public override bool HasPlayer()
        {
            return (this.Player != null);
        }

        // all of these functions basically cast everything to the "real" function
        public Object CastOrder_runTurn()
        {
            // if there are args then convert them here
            var methodInfo = this.GetType().GetMethod("RunTurn");
            var returned = methodInfo.Invoke(this, new object[]
                {
                    // nothing here because it takes no args, template will have empty
                }
            );

            // if is game object then serialize

            return this.Game.SerializeSafe(returned);
        }
    }
}
