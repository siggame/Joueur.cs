using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    class Player : Checkers.GameObject
    {
        public string Name { get; private set; }
        public List<Checkers.Checker> Checkers { get; private set; }
        public string ReasonWon { get; private set; }
        public bool Lost { get; private set; }
        public bool Won { get; private set; }
        public int YDirection { get; private set; }
        public string ClientType { get; private set; }
        public float TimeRemaining { get; private set; }
        public string ReasonLost { get; private set; }

        public Player() : base()
        {
            this.Checkers = new List<Checkers.Checker>();
        }
    }
}
