// This is where you build your AI for the Chess game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Games.Chess
{
    /// <summary>
    /// This is where you build your AI for Chess.
    /// </summary>
    public class AI : BaseAI
    {
        #region Properties
        #pragma warning disable 0169 // the never assigned warnings between here are incorrect. We set it for you via reflection. So these will remove it from the Error List.
        #pragma warning disable 0649
        /// <summary>
        /// This is the Game object itself. It contains all the information about the current game.
        /// </summary>
        public readonly Game Game;
        /// <summary>
        /// This is your AI's player. It contains all the information about your player's state.
        /// </summary>
        public readonly Player Player;
        #pragma warning restore 0169
        #pragma warning restore 0649

        // you can add additional properties here for your AI to use
        #endregion


        #region Methods
        /// <summary>
        /// This returns your AI's name to the game server. Just replace the string.
        /// </summary>
        /// <returns>Your AI's name</returns>
        public override string GetName()
        {
            return "Chess C# Player"; // REPLACE THIS WITH YOUR TEAM NAME!
        }

        /// <summary>
        /// This is automatically called when the game first starts, once the Game and all GameObjects have been initialized, but before any players do anything.
        /// </summary>
        /// <remarks>
        /// This is a good place to initialize any variables you add to your AI or start tracking game objects.
        /// </remarks>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// This is automatically called every time the game (or anything in it) updates.
        /// </summary>
        /// <remarks>
        /// If a function you call triggers an update, this will be called before that function returns.
        /// </remarks>
        public override void GameUpdated()
        {
            base.GameUpdated();
        }

        /// <summary>
        /// This is automatically called when the game ends.
        /// </summary>
        /// <remarks>
        /// You can do any cleanup of you AI here, or do custom logging. After this function returns, the application will close.
        /// </remarks>
        /// <param name="won">True if your player won, false otherwise</param>
        /// <param name="reason">A string explaining why you won or lost</param>
        public override void Ended(bool won, string reason)
        {
            base.Ended(won, reason);
        }


        /// <summary>
        /// This is called every time it is this AI.player's turn to make a move.
        /// </summary>
        /// <returns>A string in Standard Algebriac Notation (SAN) for the move you want to make. If the move is invalid or not properly formatted you will lose the game.</returns>
        public string MakeMove()
        {
            Console.WriteLine(this.PrettyFEN(this.Game.Fen, this.Player.Color));

            // This will only work if we are black move the pawn at b2 to b3.
            // Otherwise we will lose.
            // Your job is to code SOMETHING to parse the FEN string in some way to determine a valid move, in SAN format.
            return "b3";
        }

        /// <summary>
        /// Pretty formats an FEN string to a human readable string.
        /// </summary>
        /// <remarks>
        /// For more information on FEN (Forsyth-Edwards Notation) strings see:
        /// https://wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
        /// </remarks>
        private string PrettyFEN(string fen, string us)
        {
            // split the FEN string up to help parse it
            var split = fen.Split(' ');
            var first = split[0]; // the first part is always the board locations

            var sideToMove = split[1][0]; // always the second part for side to move
            var usOrThem = sideToMove == us[0] ? "us"  : "them";

            var fullmove = split[5]; // always the sixth part for the full move

            var lines = first.Split('/');
            var strings = new StringBuilder();

            strings.Append($"Move: {fullmove}\nSide to move: {sideToMove} ({usOrThem})\n   +-----------------+");

            int i = -1;
            foreach (var line in lines)
            {
                i++;
                strings.Append($"\n {8 - i} |");
                foreach (var character in line)
                {
                    int asInt = 0;
                    if(Int32.TryParse($"{character}", out asInt))
                    {
                        strings.Append(string.Concat(Enumerable.Repeat(" .", asInt)));
                    }
                    else
                    {
                        strings.Append($" {character}");
                    }
                }
                strings.Append(" |");
            }
            strings.Append("\n   +-----------------+\n     a b c d e f g h\n");

            return strings.ToString();
        }

        #endregion
    }
}
