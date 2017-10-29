using System.Diagnostics;

namespace DataStructures.BinaryTrees
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class RedBlackTreeNode<T> : TreeNode<T>
    {
        private static RedBlackTreeNode<T> Guard = new RedBlackTreeNode<T>();
        private readonly bool isGuard;

        private RedBlackTreeNode() : base(default(T))
        {
            this.isGuard = true;
            this.Color = NodeColor.Black;
        }

        public RedBlackTreeNode(T item) : base(item)
        {
        }

        public RedBlackTreeNode(T item, RedBlackTreeNode<T> parent) : base(item, parent)
        {
        }

        public NodeColor Color { get; set; }

        public RedBlackTreeNode<T> rbParent { get { return this.Parent as RedBlackTreeNode<T> ?? Guard; } }
        public RedBlackTreeNode<T> rbRight { get { return this.Right as RedBlackTreeNode<T> ?? Guard; } }
        public RedBlackTreeNode<T> rbLeft { get { return this.Left as RedBlackTreeNode<T> ?? Guard; } }
        public RedBlackTreeNode<T> rbUncle { get { return this.Uncle as RedBlackTreeNode<T> ?? Guard; } }

        private string DebuggerDisplay
        {
            get
            {
                if (this.isGuard)
                {
                    return "Guard";
                }

                return string.Format("{0} - {1}", this.Color, this.Value);
            }
        }
    }
}
