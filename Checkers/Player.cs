using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    class Player : Checkers.GameObject
    {
        public string Name { get; set; }
        public List<Checkers.Checker> Checkers { get; set; }
        public string ReasonWon { get; set; }
        public bool Lost { get; set; }
        public bool Won { get; set; }
        public int YDirection { get; set; }
        public string ClientType { get; set; }
        public double TimeRemaining { get; set; }
        public string ReasonLost { get; set; }

        public override void ApplyDeltaState(JObject delta)
        {
            base.ApplyDeltaState(delta);

            foreach (var item in delta)
            {
                switch (item.Key)
                {
                    case "name":
                        this.Name = this.Game.GetValueFromJToken<string>(item.Value);
                        break;
                    case "checkers":
                        this.Checkers = this.Game.DeltaUpdateList<Checkers.Checker>(this.Checkers, item.Value);
                        break;
                    case "reasonWon":
                        this.ReasonWon = this.Game.GetValueFromJToken<string>(item.Value);
                        break;
                    case "reasonLost":
                        this.ReasonLost = this.Game.GetValueFromJToken<string>(item.Value);
                        break;
                    case "lost":
                        this.Lost = this.Game.GetValueFromJToken<bool>(item.Value);
                        break;
                    case "won":
                        this.Won = this.Game.GetValueFromJToken<bool>(item.Value);
                        break;
                    case "yDirection":
                        this.YDirection = this.Game.GetValueFromJToken<int>(item.Value);
                        break;
                    case "clientType":
                        this.ClientType = this.Game.GetValueFromJToken<string>(item.Value);
                        break;
                    case "timeRemaining":
                        this.TimeRemaining = this.Game.GetValueFromJToken<double>(item.Value);
                        break;
                }
            }
        }
    }
}
