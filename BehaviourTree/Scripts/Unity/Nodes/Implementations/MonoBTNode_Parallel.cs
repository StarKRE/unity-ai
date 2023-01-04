using System.Collections.Generic;
using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Parallel Node")]
    public class MonoBTNode_Parallel : MonoBTNode_ParallelBase
    {
        protected override MonoBTNode[] Children
        {
            get { return this.children; }
        }

        private MonoBTNode[] children;

        private void Awake()
        {
            var children = new List<MonoBTNode>();
            foreach (Transform child in this.transform)
            {
                if (child.gameObject.activeSelf && child.TryGetComponent(out MonoBTNode node))
                {
                    children.Add(node);
                }
            }

            this.children = children.ToArray();
        }
    }
}