using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreeNode<T>
    {
        public TreeNode(T item)
        {
            this.Value = item;
        }

        public TreeNode(T item, TreeNode<T> parent)
        {
            this.Value = item;
            this.Parent = parent;
        }

        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode<T> Uncle
        {
            get
            {
                if (this.Parent.IsLeftSon)
                {
                    return this.Parent.Parent.Right;
                }
                else if (this.Parent.IsRightSon)
                {
                    return this.Parent.Parent.Left;
                }

                return null;
            }
        }

        public bool IsLeftSon { get { return this.Parent != null && this.Parent.Left == this; } }
        public bool IsRightSon { get { return this.Parent != null && this.Parent.Right == this; } }

        public int SonCount
        {
            get
            {
                int left = this.Left == null ? 0 : 1;
                int right = this.Right == null ? 0 : 1;
                return left + right;
            }
        }
    }
}
