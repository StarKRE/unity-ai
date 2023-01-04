using System;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public sealed class BTNode_CheckCondition : BTNode
    {
        public IBTCondition Condition
        {
            set { this.condition = value; }
        }

        [Space]
        [SerializeReference]
        private IBTCondition condition;

        public BTNode_CheckCondition()
        {
        }

        public BTNode_CheckCondition(IBTCondition condition)
        {
            this.condition = condition;
        }

        protected override void Run()
        {
            this.Return(this.condition.IsTrue());
        }
    }
}