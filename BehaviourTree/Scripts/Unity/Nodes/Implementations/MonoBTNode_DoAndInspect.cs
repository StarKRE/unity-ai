using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Node «Do And Inspect»")]
    public sealed class MonoBTNode_DoAndInspect : MonoBTNode, IBTNodeCallback
    {
        [SerializeField]
        private MonoBTNode actionNode;

        [SerializeField]
        private MonoBTNode[] inspectorNodes;

        protected override void Run()
        {
            this.actionNode.Run(callback: this);
            
            for (int i = 0, count = this.inspectorNodes.Length; i < count; i++)
            {
                var inspector = this.inspectorNodes[i];
                inspector.Run(callback: this);
            }
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            if (ReferenceEquals(node, this.actionNode))
            {
                this.Return(success);
            }
            else //Any inspector node
            {
                this.Return(false);
            }
        }

        protected override void OnAbort()
        {
            if (this.actionNode.IsRunning)
            {
                this.actionNode.Abort();
            }
            
            for (int i = 0, count = this.inspectorNodes.Length; i < count; i++)
            {
                var inspector = this.inspectorNodes[i];
                if (inspector.IsRunning)
                {
                    inspector.Abort();
                }
            }
        }
    }
}