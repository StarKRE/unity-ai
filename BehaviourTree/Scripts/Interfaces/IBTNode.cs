namespace AI.BTree
{
    public interface IBTNode
    {
        public bool IsRunning { get; }

        public void Run(IBTNodeCallback callback);

        public void Abort();
    }
}