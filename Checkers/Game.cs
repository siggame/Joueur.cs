using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    class Game : Joueur.cs.BaseGame
    {
        public List<Checkers.Checker> Checkers;// { get; set; }
        public bool CheckerMovedJumped { get; set; }
        public List<Checkers.Player> Players { get; set; }
        public Checkers.Player CurrentPlayer { get; set; }
        public int CurrentTurn { get; set; }
        public int MaxTurns { get; set; }
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public Checker CheckerMoved { get; set; }

        public Game() : base()
        {
            this.name = "Checkers";
        }

        public override void ApplyDeltaState(JObject delta)
        {
            base.ApplyDeltaState(delta);

            foreach (var item in delta)
            {
                switch (item.Key)
                {
                    case "checkerMovedJumped":
                        this.CheckerMovedJumped = this.GetValueFromJToken<bool>(item.Value);
                        break;
                    case "checkers":
                        this.Checkers = this.DeltaUpdateList<Checkers.Checker>(this.Checkers, item.Value);
                        break;
                    case "players":
                        this.Players = this.DeltaUpdateList<Checkers.Player>(this.Players, item.Value);
                        break;
                    case "currentTurn":
                        this.CurrentTurn = this.GetValueFromJToken<int>(item.Value);
                        break;
                    case "maxTurns":
                        this.MaxTurns = this.GetValueFromJToken<int>(item.Value);
                        break;
                    case "boardWidth":
                        this.BoardWidth = this.GetValueFromJToken<int>(item.Value);
                        break;
                    case "boardHeight":
                        this.BoardHeight = this.GetValueFromJToken<int>(item.Value);
                        break;
                    case "checkerMoved":
                        this.CheckerMoved = this.GetValueFromJToken<Checkers.Checker>(item.Value);
                        break;
                }
            }
        }
    }
}
