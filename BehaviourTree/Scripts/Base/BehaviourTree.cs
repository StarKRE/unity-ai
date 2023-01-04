using System;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public sealed class BehaviourTree : IBehaviourTree, IBTNodeCallback
    {
        public event Action OnComplete;

        public event Action OnFailed;

        public event Action OnAbort;

        public bool IsRunning
        {
            get { return this.root.IsRunning; }
        }

        public IBTNode Root
        {
            set { this.root = value; }
        }

        [SerializeReference]
        private IBTNode root = default;

        public BehaviourTree(IBTNode root)
        {
            this.root = root;
        }

        public BehaviourTree()
        {
        }

        public void Run()
        {
            if (!this.root.IsRunning)
            {
                this.root.Run(callback: this);
            }
        }

        public void Abort()
        {
            if (this.IsRunning)
            {
                this.root.Abort();
                this.OnAbort?.Invoke();
            }
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            if (success)
            {
                this.OnComplete?.Invoke();
            }
            else
            {
                this.OnFailed?.Invoke();
            }
        }
    }
}