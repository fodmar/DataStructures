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
            private readonly RedBlackNode<T> guard;
            private readonly bool isGuard;

            public RedBlackNode() : base(default(T))
            {
                this.isGuard = true;
                this.color = NodeColor.Black;
            }

            public RedBlackNode(T item, RedBlackNode<T> guard) : base(item)
            {
                this.guard = guard;
            }

            public RedBlackNode(T item, Node<T> parent, RedBlackNode<T> guard)
                : base(item, parent)
            {
                this.guard = guard;
            }

            private NodeColor color;
            public NodeColor Color
            {
                get { return this.color; } 
                set
                {
                    this.color = value;

                    if (this.isGuard)
                    {
                        this.color = NodeColor.Black;
                    }
                }
            }

            public RedBlackNode<T> rbParent { get { return this.Parent as RedBlackNode<T> ?? guard; } }
            public RedBlackNode<T> rbRight { get { return this.Right as RedBlackNode<T> ?? guard; } }
            public RedBlackNode<T> rbLeft { get { return this.Left as RedBlackNode<T> ?? guard; } }

            public RedBlackNode<T> rbUncle
            {
                get
                {
                    RedBlackNode<T> uncle = null;

                    if (this.Parent.IsLeftSon)
                    {
                        uncle = this.rbParent.rbParent.rbRight;
                    }
                    else if (this.Parent.IsRightSon)
                    {
                        uncle = this.rbParent.rbParent.rbLeft;
                    }

                    return uncle ?? this.guard;
                } 
            }
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

        protected RedBlackNode<T> guard;

        protected override Node<T> CreateNode(T item)
        {
            this.LastAdded = new RedBlackNode<T>(item, this.guard);
            return this.LastAdded;
        }

        protected override Node<T> CreateNode(T item, Node<T> parent)
        {
            this.LastAdded = new RedBlackNode<T>(item, parent, this.guard);
            return this.LastAdded;
        }

        protected RedBlackNode<T> LastAdded { get; set; }

        public override void Add(T item)
        {
            if (this.Root == null)
            {
                this.guard = new RedBlackNode<T>();
                base.Add(item);
                this.Root.Color = NodeColor.Black;
                return;
            }

            base.Add(item);
            RedBlackNode<T> current = this.LastAdded;

            while (current != this.Root && current.rbParent.Color == NodeColor.Red)
            {
                if (current.rbUncle.Color == NodeColor.Red)
                {
                    current = this.FixRedUncleScenario(current);
                    continue;
                }

                if (current.Parent.IsLeftSon)
                {
                    if (current.IsRightSon)
                    {
                        current = current.rbParent;
                        this.RotateLeft(current);
                    }

                    this.ColorParentAndGrandParent(current);
                    this.RotateRight(current.rbParent.rbParent);
                }
                else
                {
                    if (current.IsLeftSon)
                    {
                        current = current.rbParent;
                        this.RotateRight(current.rbParent);
                    }

                    this.ColorParentAndGrandParent(current);
                    this.RotateLeft(current.rbParent.rbParent);
                }

                break;
            }

            this.Root.Color = NodeColor.Black;
        }

        protected RedBlackNode<T> FixRedUncleScenario(RedBlackNode<T> current)
        {
            current.rbParent.Color = NodeColor.Black;
            current.rbUncle.Color = NodeColor.Black;

            var grandParent = current.rbParent.rbParent;
            grandParent.Color = NodeColor.Red;
            return grandParent;
        }

        protected void ColorParentAndGrandParent(RedBlackNode<T> node)
        {
            node.rbParent.Color = NodeColor.Black;
            node.rbParent.rbParent.Color = NodeColor.Red;
        }

        protected void RotateLeft(RedBlackNode<T> node)
        {
            bool wasLeftChild = node.IsLeftSon;
            var child = node.rbRight;
            var parent = node.rbParent;

            if (child == this.guard)
            {
                return;
            }

            node.Right = child.Left;
            if (node.rbRight != this.guard)
            {
                node.Right.Parent = node;
            }

            child.Left = node;
            node.Parent = child;
            child.Parent = parent;

            if (parent != this.guard)
            {
                if (wasLeftChild)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }
            else
            {
                this.root = child;
            }
        }

        protected void RotateRight(RedBlackNode<T> node)
        {
            bool wasLeftChild = node.IsLeftSon;
            var child = node.rbLeft;
            var parent = node.rbParent;

            if (child == this.guard)
            {
                return;
            }

            node.Left = child.Right;
            if (node.rbLeft != this.guard)
            {
                node.Left.Parent = node;
            }

            child.Right = node;
            child.Parent = parent;
            node.Parent = child;

            if (parent != this.guard)
            {
                if (wasLeftChild)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }
            else
            {
                this.root = child;
            }
        }
    }
}
