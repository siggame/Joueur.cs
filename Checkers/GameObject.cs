using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joueur.cs.Checkers
{
    class GameObject : BaseGameObject
    {
        public List<string> Logs { get; protected set; }

        public void Log(string message)
        {
            this.RunOnServer<Object>("log", new object[]
            {
                message
            });
        }

        public override void ApplyDeltaState(JObject delta)
        {
            base.ApplyDeltaState(delta);

            foreach (var item in delta)
            {
                switch (item.Key)
                {
                    case "id":
                        this.ID = this.Game.GetValueFromJToken<string>(item.Value);
                        break;
                    case "logs":
                        this.Logs = this.Game.DeltaUpdateList<string>(this.Logs, item.Value);
                        break;
                }
            }
        }
    }
}
