using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public enum NodeColor
    {
        Red = 0,
        Black = 1
    }

    public class RedBlackTreeNode<T> : TreeNode<T>
    {
        public static RedBlackTreeNode<T> Guard = new RedBlackTreeNode<T>();
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

        public RedBlackTreeNode(T item, TreeNode<T> parent) : base(item, (RedBlackTreeNode<T>)parent)
        {
        }

        public NodeColor Color { get; set; }

        public RedBlackTreeNode<T> rbParent { get { return this.Parent as RedBlackTreeNode<T> ?? Guard; } }
        public RedBlackTreeNode<T> rbRight { get { return this.Right as RedBlackTreeNode<T> ?? Guard; } }
        public RedBlackTreeNode<T> rbLeft { get { return this.Left as RedBlackTreeNode<T> ?? Guard; } }
        public RedBlackTreeNode<T> rbUncle { get { return this.Uncle as RedBlackTreeNode<T> ?? Guard; } }
    }
}
