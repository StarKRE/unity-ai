using System;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public sealed class BTCondition_Invert : IBTCondition
    {
        public IBTCondition Condition
        {
            set { this.condition = value; }
        }

        [SerializeReference]
        private IBTCondition condition;

        public BTCondition_Invert(IBTCondition condition)
        {
            this.condition = condition;
        }

        public BTCondition_Invert()
        {
        }

        public bool IsTrue()
        {
            return !this.condition.IsTrue();
        }
    }
}