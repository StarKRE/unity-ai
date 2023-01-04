using System;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public sealed class BTNode_Sequence : BTNode, IBTNodeCallback
    {
        public IBTNode[] Children
        {
            set { this.children = value; }
        }

        [SerializeReference]
        private IBTNode[] children;

        private IBTNode currentNode;

        private int pointer;

        public BTNode_Sequence(params IBTNode[] children)
        {
            this.children = children;
        }

        public BTNode_Sequence()
        {
        }

        protected override void Run()
        {
            if (this.children.Length <= 0)
            {
                this.Return(true);
                return;
            }

            this.pointer = 0;
            this.currentNode = this.children[this.pointer];
            this.currentNode.Run(callback: this);
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            if (!success)
            {
                this.Return(false);
                return;
            }

            if (this.pointer + 1 >= this.children.Length)
            {
                this.Return(true);
                return;
            }

            this.pointer++;
            this.currentNode = this.children[this.pointer];
            this.currentNode.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.currentNode is {IsRunning: true})
            {
                this.currentNode.Abort();
            }
        }
    }
}