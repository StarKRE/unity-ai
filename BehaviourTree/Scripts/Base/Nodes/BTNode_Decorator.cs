using System;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public sealed class BTNode_Decorator : BTNode, IBTNodeCallback
    {
        [SerializeReference]
        private IBTNode node = default;

        [SerializeField]
        private bool success = true;

        public BTNode_Decorator()
        {
        }

        public BTNode_Decorator(IBTNode node, bool success)
        {
            this.node = node;
            this.success = success;
        }

        protected override void Run()
        {
            this.node.Run(callback: this);
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            this.Return(this.success);
        }

        protected override void OnAbort()
        {
            if (this.node.IsRunning)
            {
                this.node.Abort();
            }
        }
    }
}