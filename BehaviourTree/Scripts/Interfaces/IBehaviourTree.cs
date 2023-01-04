using System;

namespace AI.BTree
{
    public interface IBehaviourTree
    {
        event Action OnComplete;

        event Action OnFailed; 

        event Action OnAbort;

        bool IsRunning { get; }
        
        void Run();

        void Abort();
    }
}