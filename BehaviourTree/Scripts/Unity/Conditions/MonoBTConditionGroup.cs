using System;
using UnityEngine;

namespace AI.BTree
{
    public sealed class MonoBTConditionGroup : MonoBTCondition
    {
        [SerializeField]
        private Mode mode;

        [SerializeField]
        private MonoBTCondition[] conditions;
        
        public override bool IsTrue()
        {
            return this.mode switch
            {
                Mode.AND => this.All(),
                Mode.OR => this.Any(),
                _ => throw new Exception($"Mode is undefined {this.mode}")
            };
        }

        private bool All()
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue())
                {
                    return false;
                }
            }

            return true;
        }

        private bool Any()
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (condition.IsTrue())
                {
                    return true;
                }
            }

            return false;
        }

        [Serializable]
        private enum Mode
        {
            AND,
            OR
        }
    }
}