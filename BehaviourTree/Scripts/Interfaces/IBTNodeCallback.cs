namespace AI.BTree
{
    public interface IBTNodeCallback
    {
        void Invoke(IBTNode node, bool success);
    }
}