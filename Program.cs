using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Reflection;

namespace Joueur.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World using C#!");

            string gameName = "Checkers";
            string server = "127.0.0.1";
            int port = 3000;
            bool printIO = false;

            Type gameType = Type.GetType("Joueur.cs.Games." + gameName + ".Game");
            BaseGame game = (BaseGame)Activator.CreateInstance(gameType);

            Type aiType = Type.GetType("Joueur.cs.Games." + gameName + ".AI");
            BaseAI ai = (BaseAI)Activator.CreateInstance(aiType);

            Client client = Client.Instance;

            client.ConnectTo(game, ai, server, port, printIO);

            // TODO: get game name, requested session, and player name from args
            client.Send("play", new ServerMessages.SendPlay
                {
                    playerName = ai.GetName(),
                    gameName = gameName
                }
            );

            var lobbiedData = (ServerMessages.LobbiedData)client.WaitForEvent("lobbied");

            Console.WriteLine("In Lobby for game '" + lobbiedData.gameName + "' in session '" + lobbiedData.gameSession + "'.");


            // hackish way to set the client in the game. we don't want to expose public methods that competitors may see via intellisense and try to use
            client.SetConstants(lobbiedData.constants);

            var startData = (ServerMessages.StartData)client.WaitForEvent("start");
            
            Console.WriteLine("Game starting");

            // set the AI's game and player via reflection
            ai.GetType().GetField("Game").SetValue(ai, game);
            ai.GetType().GetField("Player").SetValue(ai, game.GameObjects[startData.playerID]);

            ai.Start();
            ai.GameUpdated();

            while (true)
            {
                var orderData = (ServerMessages.OrderData)client.WaitForEvent("order");

                Object returned = ai.DoOrder(orderData.order, orderData.args);

                client.Send("finished", new ServerMessages.SendFinished()
                    {
                        finished = orderData.order,
                        returned = returned
                    }
                );
            }
        }
    }
}
