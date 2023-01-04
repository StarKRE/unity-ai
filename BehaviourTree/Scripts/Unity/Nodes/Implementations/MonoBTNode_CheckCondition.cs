using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Condition Node")]
    public sealed class MonoBTNode_CheckCondition : MonoBTNode
    {
        [SerializeField]
        private bool invertCondition;
        
        [Space]
        [SerializeField]
        private MonoBTCondition[] conditions;

        protected override void Run()
        {
            var isConditionPerforms = this.IsConditionTrue();
            this.Return(isConditionPerforms);
        }

        private bool IsConditionTrue()
        {
            var conditionPerforms = true;
            if (this.conditions != null)
            {
                conditionPerforms = this.CheckConditions();
            }
            
            if (this.invertCondition)
            {
                conditionPerforms = !conditionPerforms;
            }

            return conditionPerforms;
        }

        private bool CheckConditions()
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue())
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}