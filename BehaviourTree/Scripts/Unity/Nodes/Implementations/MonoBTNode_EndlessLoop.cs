using System.Collections;
using Asyncoroutine;
using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Node «Endless Loop»")]
    public sealed class MonoBTNode_EndlessLoop : MonoBTNode, IBTNodeCallback
    {
        [SerializeField]
        private MonoBTNode child;

        protected override void Run()
        {
            this.child.Run(callback: this);
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            this.StartCoroutine(this.RunInNextFrame());
        }

        private IEnumerator RunInNextFrame()
        {
            yield return new WaitForNextFrame();
            this.child.Run(callback: this);
        }

        protected override void OnAbort()
        {
            this.StopAllCoroutines();
            if (this.child.IsRunning)
            {
                this.child.Abort();
            }
        }
    }
}