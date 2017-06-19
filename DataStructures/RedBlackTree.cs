using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RedBlackTree<T> : BinaryTree<T>
    {
        protected enum NodeColor
        {
            Red = 0,
            Black = 1
        }

        protected class RedBlackNode<T> : Node<T>
        {
            public RedBlackNode(T item) : base(item)
            {
            }

            public RedBlackNode(T item, Node<T> parent) : base(item, parent)
            {
            }

            public NodeColor Color { get; set; }
        }

        public RedBlackTree(T[] initializer) : base(initializer)
        {
        }

        public RedBlackTree() : base()
        {
        }

        protected RedBlackNode<T> Root
        {
            get { return this.root as RedBlackNode<T>; }
        }

        protected override Node<T> CreateNode(T item)
        {
            return new RedBlackNode<T>(item);
        }

        protected override Node<T> CreateNode(T item, Node<T> parent)
        {
            return new RedBlackNode<T>(item, parent);
        }

        public override void Add(T item)
        {
            base.Add(item);
        }
    }
}
