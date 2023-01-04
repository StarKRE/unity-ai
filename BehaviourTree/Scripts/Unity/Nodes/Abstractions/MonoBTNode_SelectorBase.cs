namespace AI.BTree
{
    public abstract class MonoBTNode_SelectorBase : MonoBTNode, IBTNodeCallback
    {
        protected abstract MonoBTNode[] Children { get; }
        
        private int pointer;

        private MonoBTNode currentNode;

        protected override void Run()
        {
            var children = this.Children;
            if (children == null && children.Length <= 0)
            {
                this.Return(false);
                return;
            }

            this.pointer = 0;

            this.currentNode = children[this.pointer];
            this.currentNode.Run(callback: this);
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            if (success)
            {
                this.Return(true);
                return;
            }

            var children = this.Children;
            if (this.pointer + 1 >= children.Length)
            {
                this.Return(false);
                return;
            }

            this.pointer++;
            this.currentNode = children[this.pointer];
            this.currentNode.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.currentNode != null && this.currentNode.IsRunning)
            {
                this.currentNode.Abort();
            }
        }
    }
}