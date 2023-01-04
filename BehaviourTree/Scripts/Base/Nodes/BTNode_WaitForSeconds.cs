using System;
using System.Collections;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public sealed class BTNode_WaitForSeconds : BTNode_Coroutine
    {
        public float WaitSeconds
        {
            set { this.waitSeconds = value; }
        }

        [SerializeField]
        private float waitSeconds;

        public BTNode_WaitForSeconds()
        {
        }

        public BTNode_WaitForSeconds(MonoBehaviour coroutineDispatcher) : base(coroutineDispatcher)
        {
        }

        protected override IEnumerator RunRoutine()
        {
            yield return new WaitForSeconds(this.waitSeconds);
            this.Return(true);
        }
    }
}