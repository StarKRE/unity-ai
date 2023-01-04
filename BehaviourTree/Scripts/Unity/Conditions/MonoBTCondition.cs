using UnityEngine;

namespace AI.BTree
{
    public abstract class MonoBTCondition : MonoBehaviour, IBTCondition
    {
        public abstract bool IsTrue();
    }
}