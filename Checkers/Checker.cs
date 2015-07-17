using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    class Checker : Checkers.GameObject
    {
        public Checkers.Player Owner { get; set; }
        public int Y { get; set; }
        public bool Kinged { get; set; }
        public int X { get; set; }

        public bool isMine()
        {
            return this.RunOnServer<bool>("isMine", new object[]
            {
            });
        }

        public Checker Move(int x, int y)
        {
            return this.RunOnServer<Checker>("move", new object[]
            {
                x,
                y
            });
        }

        public override void ApplyDeltaState(JObject delta)
        {
            base.ApplyDeltaState(delta);

            foreach (var item in delta)
            {
                switch (item.Key)
                {
                    case "x":
                        this.X = this.Game.GetValueFromJToken<int>(item.Value);
                        break;
                    case "y":
                        this.X = this.Game.GetValueFromJToken<int>(item.Value);
                        break;
                    case "kinged":
                        this.Kinged = this.Game.GetValueFromJToken<bool>(item.Value);
                        break;
                    case "owner":
                        this.Owner = this.Game.GetValueFromJToken<Checkers.Player>(item.Value);
                        break;
                }
            }
        }
    }
}
