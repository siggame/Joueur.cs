using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Games.Checkers
{
    class Game : Joueur.cs.BaseGame
    {
        public List<Checkers.Checker> Checkers { get; private set; }
        public bool CheckerMovedJumped { get; private set; }
        public List<Checkers.Player> Players { get; private set; }
        public Checkers.Player CurrentPlayer { get; private set; }
        public int CurrentTurn { get; private set; }
        public int MaxTurns { get; private set; }
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }
        public Checkers.Checker CheckerMoved { get; private set; }

        public Game() : base()
        {
            this.Name = "Checkers";

            this.Checkers = new List<Checkers.Checker>();
            this.Players = new List<Checkers.Player>();
        }
    }
}
