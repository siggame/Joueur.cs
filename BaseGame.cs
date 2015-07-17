using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs
{
    abstract class BaseGame
    {
        private Client Client;
        private Dictionary<string, string> Constants;
        private Dictionary<string, BaseGameObject> GameObjects; // mapping of the game object ID (which is a string) to the actual game object. IDs are never re-used so this helps us grab and check what game objects have been created
        protected string name;

        public BaseGame()
        {
            this.Constants = new Dictionary<string, string>();
            this.GameObjects = new Dictionary<string, BaseGameObject>();
        }

        public void SetClient(Client client)
        {
            this.Client = client;
        }

        public void SetConstants(Dictionary<string, string> constants)
        {
            foreach (KeyValuePair<string, string> pair in constants)
            {
                this.Constants.Add(pair.Key, pair.Value);
            }
        }

        public BaseGameObject GetGameObject(string id)
        {
            return this.GameObjects[id];
        }

        public virtual void ReceivedDelta(JObject delta)
        {
            if (delta["gameObjects"] != null && delta["gameObjects"].HasValues)
            {
                var deltaGameObjects = delta["gameObjects"].ToObject<JObject>();

                this.InitGameObjects(deltaGameObjects);
            }

            this.ApplyDeltaState(delta);
        }

        public virtual void ApplyDeltaState(JObject delta)
        {
            // should be inherited by the super class
        }

        private void InitGameObjects(JObject deltaGameObjects)
        {
            foreach (var delta in deltaGameObjects)
            {
                if (!this.GameObjects.ContainsKey(delta.Key)) // then this is the first time we've gotten reference to this game object, so construct it
                {
                    this.GameObjects.Add(delta.Key, this.CreateGameObject(delta.Value["gameObjectName"].ToString()));
                }
                else if (this.IsDeltaRemoved(delta.Value))
                {
                    this.GameObjects.Remove(delta.Key);
                }
            }

            foreach(var item in deltaGameObjects) // delta update each game object
            {
                this.GameObjects[item.Key].ApplyDeltaState(item.Value.ToObject<JObject>());
            }
        }

        private BaseGameObject CreateGameObject(string className)
        {
            Type gameObjectType = Type.GetType("Joueur.cs." + this.name + "." + className);
            BaseGameObject baseGameObject = (BaseGameObject)Activator.CreateInstance(gameObjectType);
            baseGameObject.SetGameAndClient(this, this.Client);
            return baseGameObject;
        }

        protected bool IsDeltaRemoved(JObject obj)
        {
            return (obj != null && obj.Type == JTokenType.String && obj.ToString() == this.Constants["DELTA_REMOVED"]);
        }

        protected bool IsDeltaRemoved(JToken jtoken)
        {
            return (jtoken != null && jtoken.Type == JTokenType.String && jtoken.ToString() == this.Constants["DELTA_REMOVED"]);
        }

        private bool IsGameObjectReference(JToken jtoken)
        {
            return (jtoken != null && jtoken.Type == JTokenType.Object && jtoken["id"] != null);
        }

        public T GetValueFromJToken<T>(JToken jtoken)
        {
            if (this.IsDeltaRemoved(jtoken))
            {
                return default(T); // default for Objects is null, which is removed
            }
            else if (this.IsGameObjectReference(jtoken))
            {
                var gameObject = this.GameObjects[jtoken["id"].ToString()];
                var justObject = (Object)gameObject;
                return (T)justObject; // stupid casting :P
            }

            return jtoken.ToObject<T>();
        }

        public List<T> DeltaUpdateList<T>(List<T> list, JToken jtoken)
        {
            int desiredLength = jtoken[this.Constants["DELTA_ARRAY_LENGTH"]].ToObject<int>();

            if (list == null)
            {
                list = new List<T>(desiredLength);
            }

            while(list.Count > desiredLength)
            {
                list.RemoveAt(list.Count - 1);
            }

            while(list.Count < desiredLength)
            {
                list.Add(default(T));
            }

            var itemObject = jtoken.ToObject<JObject>();
            foreach (var subItem1 in itemObject) // TODO: support multi-dimensional lists
            {
                if (subItem1.Key != this.Constants["DELTA_ARRAY_LENGTH"])
                {
                    list[Convert.ToInt32(subItem1.Key)] = this.GetValueFromJToken<T>(subItem1.Value);
                }
            }

            return list;
        }

        public Dictionary<T, S> DeltaUpdateDictionary<T, S>(Dictionary<T, S> dictionary, JToken jtoken)
        {
            var jobject = jtoken.ToObject<JObject>();
            if (dictionary == null)
            {
                dictionary = new Dictionary<T,S>();
            }

            foreach (var item in jobject)
            {
                T castKey = ((JToken)item.Key).ToObject<T>();

                if (!dictionary.ContainsKey(castKey)) // then this is the first time we've gotten reference it
                {
                    dictionary.Add(castKey, default(S));
                }

                // now the key should be present in the dictionary, so remove it if it's the special delta removed character, otherwise get the normal value
                if (this.IsDeltaRemoved(item.Value))
                {
                    dictionary.Remove(castKey);
                }
                else
                {
                    dictionary[castKey] = this.GetValueFromJToken<S>(item.Value);
                }
            }

            return dictionary;
        }

        public Dictionary<string, string> SerializeGameObject(BaseGameObject baseGameObject)
        {
            return new Dictionary<string, string>() { { "id", baseGameObject.ID } };
        }

        public Object SerializeSafe(Object obj)
        {
            if (obj.GetType().IsSubclassOf(typeof(BaseGameObject)))
            {
                return this.SerializeGameObject((BaseGameObject)obj);
            }

            return obj;
        }
    }
}
