﻿using System;
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
        private bool connected = false;

        public void ConnectTo(BaseGame game, BaseAI ai, string server = "127.0.0.1", int port = 3000, bool printIO = false)
        {
            this.Game = game;
            this.AI = ai;
            this.Server = server;
            this.Port = port;
            this.PrintIO = printIO;
            this.GameManager = new GameManager(game, ai);

            try
            {
                this.TCPClient = new TcpClient(server, port);
            }
            catch(Exception exception)
            {
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.COULD_NOT_CONNECT, exception, "Could not connect to " + server + ":" + port);
            }

            this.connected = true;
        }

        public void Send(string eventName, Object data)
        {
            ServerMessages.SendMessage message = new ServerMessages.SendMessage(eventName, data);

            string serialized = null;
            try
            {
                serialized = JsonConvert.SerializeObject(message) + EOT_CHAR;
            }
            catch(Exception exception)
            {
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.MALFORMED_JSON, exception, "Could not serialize object: " + data.ToString());
            }

            if(this.PrintIO)
            {
                Console.WriteLine("TO SERVER <-- " + serialized);
            }

            try
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(serialized);

                NetworkStream stream = this.TCPClient.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(bytes, 0, bytes.Length);
            }
            catch(Exception exception)
            {
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.CANNOT_READ_SOCKET, exception, "Could not send data through socket.");
            }
            
        }

        public void Disconnect()
        {
            if (this.connected)
            {
                try
                {
                    NetworkStream stream = this.TCPClient.GetStream();
                    stream.Close();
                    this.TCPClient.Close();
                }
                catch
                {
                    // ignore, disconnect should only happen at the end when we don't care, or already during error handling when other errors liek this could bubble up.
                }
            }
        }



        public void Play()
        {
            this.WaitForEvent(null); // wait's indefinitly. Should eventually be terminated by the 'over' event from the server.
        }

        public Object WaitForEvent(string eventName)
        {
            while (true)
            {
                this.WaitForEvents();

                while (this.EventsStack.Count > 0)
                {
                    ServerMessages.ReceivedEvent<Object> receivedEvent = this.EventsStack.Pop();
                    if (eventName != null && receivedEvent.@event == eventName)
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
                catch (Exception exception)
                {
                    ErrorHandler.HandleError(ErrorHandler.ErrorCode.CANNOT_READ_SOCKET, exception, "Cannot read socket while waiting for events.");
                }

                if (bytes == -2)
                {
                    continue; // as no bytes were read
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
                    JObject deserialized = null;
                    string jsonStr = split[i];
                    try
                    {
                        deserialized = JObject.Parse(jsonStr);
                    }
                    catch(Exception exception)
                    {
                        ErrorHandler.HandleError(ErrorHandler.ErrorCode.MALFORMED_JSON, exception, "Could not parse json '" + jsonStr + "'");
                    }

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
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.UNKNOWN_EVENT_FROM_SERVER, "Could not auto handle '" + eventName + "'");
            }
            else
            {
                theMethod.Invoke(this, new Object[] {data});
            }
        }

        private void AutoHandleDelta(JObject data)
        {
            try
            {
                this.GameManager.DeltaUpdate(data);
            }
            catch(Exception exception)
            {
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.DELTA_MERGE_FAILURE, exception, "Could not delta update");
            }

            if (this.AIsPlayer == null)
            {
                try
                {
                    this.AIsPlayer = (BaseGameObject)this.AI.GetType().GetField("Player").GetValue(this.AI);
                }
                catch(Exception exception)
                {
                    ErrorHandler.HandleError(ErrorHandler.ErrorCode.REFLECTION_FAILED, exception, "Could not get ai's player via reflection.");
                }
            }

            if (this.AIsPlayer != null)
            {
                try
                {
                    this.AI.GameUpdated();
                }
                catch(Exception exception)
                {
                    ErrorHandler.HandleError(ErrorHandler.ErrorCode.AI_ERRORED, exception, "AI threw unhandled exception during GameUpdated()");
                }
            }
        }

        private void AutoHandleInvalid(ServerMessages.ReceivedData data)
        {
            ErrorHandler.HandleError(ErrorHandler.ErrorCode.INVALID_EVENT, "Got invalid event.");
        }

        private void AutoHandleUnauthenticated(ServerMessages.ReceivedData data)
        {
            ErrorHandler.HandleError(ErrorHandler.ErrorCode.UNAUTHENTICATED, "Could not log into server.");
        }

        private void AutoHandleOver(ServerMessages.ReceivedData data)
        {
            var won = true;
            var reason = "unknown reason";

            if (this.AIsPlayer != null) // try to figure out if we won or lost
            {
                try
                {
                    won = (bool)this.AIsPlayer.GetType().GetProperty("Won").GetValue(this.AIsPlayer, null);
                    var reasonProperty = (won ? "ReasonWon" : "ReasonLost");
                    reason = (string)this.AIsPlayer.GetType().GetProperty(reasonProperty).GetValue(this.AIsPlayer, null);
                }
                catch(Exception exception)
                {
                    ErrorHandler.HandleError(ErrorHandler.ErrorCode.REFLECTION_FAILED, exception, "Could not get win reason via reflection");
                }
            }

            try
            {
                this.AI.Ended(won, reason);
            }
            catch(Exception exception)
            {
                ErrorHandler.HandleError(ErrorHandler.ErrorCode.AI_ERRORED, exception, "AI errored duing Ended(won, reason)");
            }

            this.Disconnect();
            System.Environment.Exit(0);
        }

        private void AutoHandleOrder(ServerMessages.OrderData data)
        {
            Object returned = this.AI.DoOrder(data.name, data.args);

            this.Send("finished", new ServerMessages.SendFinished() {
                orderIndex = data.index,
                returned = returned
            });
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