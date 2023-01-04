using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Decorator Node")]
    public sealed class MonoBTNode_Decorator : MonoBTNode, IBTNodeCallback
    {
        [SerializeField]
        private MonoBTNode node;

        [SerializeField]
        private bool success = true;

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