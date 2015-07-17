using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Joueur.cs
{
    class Client
    {
        const char EOT_CHAR = (char) 4;
        BaseGame Game;
        BaseAI AI;
        TcpClient TCPClient;

        private Stack<ServerMessages.ReceivedEvent<Object>> EventsStack;
        private string ReceivedBuffer;

        public Client(BaseGame game, BaseAI ai, string server = "127.0.0.1", int port = 3000, bool printIO = false)
        {
            this.Game = game;
            this.AI = ai;
            this.EventsStack = new Stack<ServerMessages.ReceivedEvent<Object>>();
            this.ReceivedBuffer = String.Empty;

            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination
                this.TCPClient = new TcpClient(server, port);

                /*
                ServerMessages.SendPlay sendPlay = new ServerMessages.SendPlay();

                sendPlay.gameName = "Checkers";

                string message = JsonConvert.SerializeObject(sendPlay);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = this.tcpClient.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                this.tcpClient.Close();
                 */
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public void Send(string eventName, Object data)
        {
            ServerMessages.SendMessage message = new ServerMessages.SendMessage(eventName, data);

            string serialized = JsonConvert.SerializeObject(message) + EOT_CHAR;

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(serialized);

            try
            {
                NetworkStream stream = this.TCPClient.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(bytes, 0, bytes.Length);
                //stream.Close();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NullReferenceException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public void Disconnect()
        {
            NetworkStream stream = this.TCPClient.GetStream();
            stream.Close();
            this.TCPClient.Close();
            System.Environment.Exit(0);
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
                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

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
            this.Game.ReceivedDelta(data);

            if(this.AI.HasPlayer())
            {
                this.AI.GameUpdated();
            }
        }

        private void AutoHandleInvalid(ServerMessages.ReceivedData data)
        {
            Console.WriteLine("send invalid command data");
        }

        private void AutoHandleOver(ServerMessages.ReceivedData data)
        {
            this.AI.Ended(true, ""); // TODO: get if it actually won and the reason from the player
            this.Disconnect();
        }



        public T RunOnServer<T>(BaseGameObject caller, string functionName, object[] args = null)
        {
            this.Send("run", new ServerMessages.RunMessage() 
                {
                    caller = this.Game.SerializeGameObject(caller),
                    functionName = functionName,
                    args = args
                }
            );

            var runData = (JToken)this.WaitForEvent("ran");

            return this.Game.GetValueFromJToken<T>(runData);
        }
    }
}
