using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Node «Stub»")]
    public sealed class MonoBTNode_Stub : MonoBTNode
    {
        [SerializeField]
        private bool success = true;
        
        protected override void Run()
        {
            this.Return(this.success);
        }
    }
}