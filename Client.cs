using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Joueur.cs
{
    sealed class Client // Client is a singleton
    {
        #region Singleton pattern setup

        private static readonly Client _Instance = new Client();

        private Client()
        {
            this.EventsStack = new Stack<ServerMessages.ReceivedEvent<object>>();
            this.ReceivedBuffer = String.Empty;
        }

        public static Client Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public const int ERROR_CODE_INVALID = -17;
        public const int ERROR_CODE_SOCKET_READ = -18;

        public string Server { get; private set; }
        public int Port { get; private set; }
        public bool PrintIO { get; private set; }
        private const char EOT_CHAR = (char) 4;
        private BaseGame Game;
        private BaseAI AI;
        private BaseGameObject AIsPlayer;
        public GameManager GameManager;
        private TcpClient TCPClient;
        private Stack<ServerMessages.ReceivedEvent<Object>> EventsStack;
        private string ReceivedBuffer;

        public void ConnectTo(BaseGame game, BaseAI ai, string server = "127.0.0.1", int port = 3000, bool printIO = false)
        {
            this.Game = game;
            this.AI = ai;
            this.Server = server;
            this.Port = port;
            this.PrintIO = printIO;
            this.GameManager = new GameManager(game, ai);
            this.TCPClient = new TcpClient(server, port);
        }

        public void Send(string eventName, Object data)
        {
            ServerMessages.SendMessage message = new ServerMessages.SendMessage(eventName, data);

            string serialized = JsonConvert.SerializeObject(message) + EOT_CHAR;

            if(this.PrintIO)
            {
                Console.WriteLine("TO SERVER <-- " + serialized);
            }

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(serialized);

            NetworkStream stream = this.TCPClient.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(bytes, 0, bytes.Length);
        }

        public void Disconnect(int errorCode = 0, string errorMessage = "")
        {
            if (errorMessage != "")
            {
                System.Console.Error.WriteLine(errorMessage);
            }
            NetworkStream stream = this.TCPClient.GetStream();
            stream.Close();
            this.TCPClient.Close();
            System.Environment.Exit(errorCode);
        }



        public Object WaitForEvent(string eventName)
        {
            while (true)
            {
                this.WaitForEvents();

                while (this.EventsStack.Count > 0)
                {
                    ServerMessages.ReceivedEvent<Object> receivedEvent = this.EventsStack.Pop();
                    if (receivedEvent.@event == eventName)
                    {
                        return receivedEvent.data;
                    }
                    else
                    {
                        this.AutoHandle(receivedEvent.@event, receivedEvent.data);
                    }
                }
            }
        }

        private void WaitForEvents()
        {
            if (this.EventsStack.Count > 0)
            {
                return; // as we already have events to handle, no need to wait for more
            }

            while (true)
            {
                NetworkStream stream = this.TCPClient.GetStream();
                Byte[] data = new Byte[1024];
                String responseData = String.Empty;

                // Read the TcpServer response bytes.
                int bytes = -2;
                try
                {
                    bytes = stream.Read(data, 0, data.Length);
                }
                catch (IOException e)
                {
                    this.Disconnect(Client.ERROR_CODE_SOCKET_READ, "Error with reading socket: " + e.Message);
                }

                if (bytes == -2)
                {
                    continue;
                } 

                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                if (this.PrintIO)
                {
                    Console.WriteLine("FROM SERVER --> " + responseData);
                }

                string total = this.ReceivedBuffer + responseData;
                string[] split = total.Split(EOT_CHAR);

                this.ReceivedBuffer = split.Last(); // this is either an empty string because of the EOT_CHAR split, or an incomplete json string so store it in the buffer

                for (int i = split.Length - 2; i >= 0; i--) // iterate through in reverse, skipping the over the very last item because we stored it in the receivedBuffer
                {
                    JObject deserialized = JObject.Parse(split[i]);
                    var receivedEvent = new ServerMessages.ReceivedEvent<Object>();
                    receivedEvent.@event = deserialized.GetValue("event").ToString();

                    switch (receivedEvent.@event)
                    {
                        case "lobbied":
                            receivedEvent.data = deserialized["data"].ToObject<ServerMessages.LobbiedData>();
                            break;
                        case "start":
                            receivedEvent.data = deserialized["data"].ToObject<ServerMessages.StartData>();
                            break;
                        case "order":
                            receivedEvent.data = deserialized["data"].ToObject<ServerMessages.OrderData>();
                            break;
                        default:
                            if (deserialized["data"] != null)
                            {
                                receivedEvent.data = deserialized["data"].ToObject<JObject>();
                            }
                            break;
                    }

                    this.EventsStack.Push(receivedEvent);
                }

                if (this.EventsStack.Count > 0)
                {
                    return;
                }
            }
        }



        private void AutoHandle(string eventName, Object data)
        {
            string capitalizedEventName = eventName.First().ToString().ToUpper() + eventName.Substring(1);
            MethodInfo theMethod = this.GetType().GetMethod("AutoHandle" + capitalizedEventName, BindingFlags.NonPublic | BindingFlags.Instance);
            
            if(theMethod == null || eventName == String.Empty)
            {
                Console.WriteLine("Error: cannot auto handle event \"" + eventName + "\"");
            }
            else
            {
                theMethod.Invoke(this, new Object[] {data});
            }
        }

        private void AutoHandleDelta(JObject data)
        {
            this.GameManager.DeltaUpdate(data);

            if (this.AIsPlayer == null)
            {
                this.AIsPlayer = (BaseGameObject)this.AI.GetType().GetField("Player").GetValue(this.AI);
            }

            if (this.AIsPlayer != null)
            {
                this.AI.GameUpdated();
            }
        }

        private void AutoHandleInvalid(ServerMessages.ReceivedData data)
        {
            throw new Exception("send invalid command data");
        }

        private void AutoHandleOver(ServerMessages.ReceivedData data)
        {
            var won = true;
            var reason = "unknown reason";

            if (this.AIsPlayer != null) // try to figure out if we won or lost
            {
                won = (bool)this.AIsPlayer.GetType().GetProperty("Won").GetValue(this.AIsPlayer, null);
                var reasonProperty = (won ? "ReasonWon" : "ReasonLost");
                reason = (string)this.AIsPlayer.GetType().GetProperty(reasonProperty).GetValue(this.AIsPlayer, null);
            }

            this.AI.Ended(won, reason); // TODO: get if it actually won and the reason from the player
            this.Disconnect();
        }



        public T RunOnServer<T>(BaseGameObject caller, string functionName, IDictionary<string, object> args = null)
        {
            this.Send("run", new ServerMessages.RunMessage() 
                {
                    caller = this.GameManager.SerializeGameObject(caller),
                    functionName = functionName,
                    args = args
                }
            );

            var runData = (JToken)this.WaitForEvent("ran");

            return this.GameManager.GetValueFromJToken<T>(runData);
        }
    }
}
