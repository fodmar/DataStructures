using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinaryTrees
{
    public class Rotate
    {
        public void RotateLeft<T>(ref TreeNode<T> root, TreeNode<T> node)
        {
            bool wasLeftChild = node.IsLeftSon;
            var child = node.Right;
            var parent = node.Parent;

            if (child == null)
            {
                return;
            }

            node.Right = child.Left;
            if (node.Right != null)
            {
                node.Right.Parent = node;
            }

            child.Left = node;
            node.Parent = child;
            child.Parent = parent;

            if (parent != null)
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
                root = child;
            }
        }

        public void RotateRight<T>(ref TreeNode<T> root, TreeNode<T> node)
        {
            bool wasLeftChild = node.IsLeftSon;
            var child = node.Left;
            var parent = node.Parent;

            if (child == null)
            {
                return;
            }

            node.Left = child.Right;
            if (node.Left != null)
            {
                node.Left.Parent = node;
            }

            child.Right = node;
            child.Parent = parent;
            node.Parent = child;

            if (parent != null)
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
                root = child;
            }
        }
    }
}
