using System;
using System.Collections.Generic;

namespace Joueur.cs.Games.Newtonian.Helpers {
    public class UnitLogic<TAI, TUnit> where TAI : BaseAI where TUnit : GameObject {
        public TAI AI { get; }
        public List<Func<TUnit, bool>> Tasks { get; }

        public UnitLogic(TAI ai) {
            this.AI = ai;
            this.Tasks = new List<Func<TUnit, bool>>();
        }

        public UnitLogic<TAI, TUnit> AddTask(Func<TUnit, bool> task) {
            this.Tasks.Add(task);
            return this;
        }

        public UnitLogic<TAI, TUnit> AddTasks(params Func<TUnit, bool>[] tasks) => this.AddTasks((IEnumerable<Func<TUnit, bool>>) tasks);
        public UnitLogic<TAI, TUnit> AddTasks(IEnumerable<Func<TUnit, bool>> tasks) {
            this.Tasks.AddRange(tasks);
            return this;
        }
    }
}
