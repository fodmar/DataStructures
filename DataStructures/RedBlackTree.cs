using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RedBlackTree<T> : BinaryTree<T>
    {
        public RedBlackTree(T[] initializer) : base(initializer)
        {
        }

        public RedBlackTree() : base()
        {
        }

        protected RedBlackTreeNode<T> Root
        {
            get { return this.root as RedBlackTreeNode<T>; }
        }

        protected override TreeNode<T> CreateNode(T item)
        {
            this.LastAdded = new RedBlackTreeNode<T>(item);
            return this.LastAdded;
        }

        protected override TreeNode<T> CreateNode(T item, TreeNode<T> parent)
        {
            this.LastAdded = new RedBlackTreeNode<T>(item, parent);
            return this.LastAdded;
        }

        protected RedBlackTreeNode<T> LastAdded { get; set; }

        public override bool Add(T item)
        {
            base.Add(item);
            RedBlackTreeNode<T> current = this.LastAdded;

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
            return true;
        }

        protected RedBlackTreeNode<T> FixRedUncleScenario(RedBlackTreeNode<T> current)
        {
            current.rbParent.Color = NodeColor.Black;
            current.rbUncle.Color = NodeColor.Black;

            var grandParent = current.rbParent.rbParent;
            grandParent.Color = NodeColor.Red;
            return grandParent;
        }

        protected void ColorParentAndGrandParent(RedBlackTreeNode<T> node)
        {
            node.rbParent.Color = NodeColor.Black;
            node.rbParent.rbParent.Color = NodeColor.Red;
        }

        protected void RotateLeft(RedBlackTreeNode<T> node)
        {
            bool wasLeftChild = node.IsLeftSon;
            var child = node.rbRight;
            var parent = node.rbParent;

            if (child == RedBlackTreeNode<T>.Guard)
            {
                return;
            }

            node.Right = child.Left;
            if (node.rbRight != RedBlackTreeNode<T>.Guard)
            {
                node.Right.Parent = node;
            }

            child.Left = node;
            node.Parent = child;
            child.Parent = parent;

            if (parent != RedBlackTreeNode<T>.Guard)
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

        protected void RotateRight(RedBlackTreeNode<T> node)
        {
            bool wasLeftChild = node.IsLeftSon;
            var child = node.rbLeft;
            var parent = node.rbParent;

            if (child == RedBlackTreeNode<T>.Guard)
            {
                return;
            }

            node.Left = child.Right;
            if (node.rbLeft != RedBlackTreeNode<T>.Guard)
            {
                node.Left.Parent = node;
            }

            child.Right = node;
            child.Parent = parent;
            node.Parent = child;

            if (parent != RedBlackTreeNode<T>.Guard)
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
