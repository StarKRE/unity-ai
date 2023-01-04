using System.Collections;
using Elementary;
using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Node «Wait For Seconds»")]
    public sealed class MonoBTNode_WaitForSeconds : MonoBTNode_Coroutine
    {
        [SerializeField]
        private FloatAdapter waitSeconds;

        protected override IEnumerator RunRoutine()
        {
            yield return new WaitForSeconds(this.waitSeconds.Value);
            this.Return(true);
        }
    }
}