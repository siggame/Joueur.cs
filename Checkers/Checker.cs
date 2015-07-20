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
    }
}
