using System.Collections;
using UnityEngine;

namespace AI.BTree
{
    public abstract class BTNode_Coroutine : BTNode
    {
        public MonoBehaviour CoroutineDispatcher
        {
            set { this.coroutineDispatcher = value; }
        }

        private MonoBehaviour coroutineDispatcher;

        private Coroutine coroutine;

        protected BTNode_Coroutine()
        {
        }

        protected BTNode_Coroutine(MonoBehaviour coroutineDispatcher)
        {
            this.coroutineDispatcher = coroutineDispatcher;
        }

        protected sealed override void Run()
        {
            this.coroutine = this.coroutineDispatcher.StartCoroutine(this.RunRoutine());
        }

        protected abstract IEnumerator RunRoutine();

        protected override void OnEnd()
        {
            if (this.coroutine != null)
            {
                this.coroutineDispatcher.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }
    }
}