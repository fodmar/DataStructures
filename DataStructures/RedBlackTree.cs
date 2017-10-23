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

            public void ToggleColor()
            {
                if (this.Color == NodeColor.Black)
                {
                    this.Color = NodeColor.Red;
                }
                else
                {
                    this.Color = NodeColor.Black;
                }
            }
        }

        public RedBlackTree(T[] initializer) : base()
        {
            if (initializer != null)
            {
                for (int i = 0; i < initializer.Length; i++)
                {
                    this.Add(initializer[i]);
                }
            }
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

            if (this.LastAdded.rbParent.Color == NodeColor.Black)
            {
                return;
            }

            if (this.LastAdded.rbUncle.Color == NodeColor.Red)
            {
                if (this.FixRedUncleScenario(this.LastAdded))
                {
                    return;
                }
            }

            if (this.LastAdded.rbUncle.Color == NodeColor.Black)
            {
                if (this.LastAdded.rbUncle.IsRightSon && this.LastAdded.IsRightSon)
                {
                    this.RotateLeft(this.LastAdded);
                }
                else if (this.LastAdded.rbUncle.IsLeftSon && this.LastAdded.IsLeftSon)
                {
                    this.RotateRight(this.LastAdded);
                }
            }

            if (this.LastAdded.rbUncle.Color == NodeColor.Black)
            {
                if (this.LastAdded.rbUncle.IsRightSon && this.LastAdded.IsLeftSon)
                {
                    this.RotateRight(this.LastAdded.rbParent);
                }
                else if (this.LastAdded.rbUncle.IsLeftSon && this.LastAdded.IsRightSon)
                {
                    this.RotateLeft(this.LastAdded.rbParent);
                }
            }

            this.LastAdded.ToggleColor();
            this.LastAdded.rbParent.ToggleColor();
        }

        protected bool FixRedUncleScenario(RedBlackNode<T> node)
        {
            var grandParent = node.rbParent.rbParent;
            grandParent.rbLeft.Color = NodeColor.Black;
            grandParent.rbRight.Color = NodeColor.Black;

            if (grandParent == this.Root)
            {
                grandParent.Color = NodeColor.Black;
                return true;
            }

            this.LastAdded = grandParent;
            return false;
        }

        protected void RotateLeft(RedBlackNode<T> node)
        {
            var parent = node.Parent;
            var grandParent = parent.Parent;
            var leftChild = node.Left;

            grandParent.Left = node;
            node.Parent = grandParent;

            node.Left = parent;
            parent.Parent = node;

            parent.Right = leftChild;
            leftChild.Parent = parent;

            this.LastAdded = (RedBlackNode<T>)parent;
        }

        protected void RotateRight(RedBlackNode<T> node)
        {
            var parent = node.Parent;
            var grandParent = parent.Parent;
            var rightChild = node.Right;

            grandParent.Right = node;
            node.Parent = grandParent;

            node.Right = parent;
            parent.Parent = node;

            parent.Left = rightChild;
            rightChild.Parent = parent;

            this.LastAdded = (RedBlackNode<T>)parent;
        }
    }
}
