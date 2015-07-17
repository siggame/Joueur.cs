using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Joueur.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World using C#!");

            string gameName = "Checkers";

            var a = new Dictionary<string, string>();

            Type gameType = Type.GetType("Joueur.cs." + gameName + ".Game");
            BaseGame game = (BaseGame)Activator.CreateInstance(gameType);

            Type aiType = Type.GetType("Joueur.cs." + gameName + ".AI");
            BaseAI ai = (BaseAI)Activator.CreateInstance(aiType);

            Client client = new Client(game, ai);

            // TODO: get game name, requested session, and player name from args
            client.Send("play", new ServerMessages.SendPlay
                {
                    gameName = gameName
                }
            );

            var lobbiedData = (ServerMessages.LobbiedData)client.WaitForEvent("lobbied");

            Console.WriteLine("In Lobby for game '" + lobbiedData.gameName + "' in session '" + lobbiedData.gameSession + "'.");

            game.SetClient(client);
            game.SetConstants(lobbiedData.constants);

            var startData = (ServerMessages.StartData)client.WaitForEvent("start");
            
            Console.WriteLine("Game starting");

            ai.ConnectToGameAs(game, startData.playerID);
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
