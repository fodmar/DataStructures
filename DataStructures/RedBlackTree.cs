using DataStructures.BinaryTrees;

namespace DataStructures
{
    public class RedBlackTree<T> : BinaryTree<T>
    {
        private readonly Rotate rotate = new Rotate();

        public RedBlackTree(T[] initializer) : base(initializer)
        {
        }

        public RedBlackTree() : this(null)
        {
        }

        protected RedBlackTreeNode<T> Root
        {
            get { return this.root as RedBlackTreeNode<T>; }
        }

        protected override TreeNode<T> CreateNode(T item)
        {
            this.lastAdded = new RedBlackTreeNode<T>(item);
            return this.lastAdded;
        }

        protected override TreeNode<T> CreateNode(T item, TreeNode<T> parent)
        {
            this.lastAdded = new RedBlackTreeNode<T>(item, (RedBlackTreeNode<T>)parent);
            return this.lastAdded;
        }

        private RedBlackTreeNode<T> lastAdded;

        public override bool Add(T item)
        {
            base.Add(item);
            RedBlackTreeNode<T> current = this.lastAdded;

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
                        this.rotate.RotateLeft(ref this.root, current);
                    }

                    this.ColorParentAndGrandParent(current);
                    this.rotate.RotateRight(ref this.root, current.rbParent.rbParent);
                }
                else
                {
                    if (current.IsLeftSon)
                    {
                        current = current.rbParent;
                        this.rotate.RotateRight(ref this.root, current.rbParent);
                    }

                    this.ColorParentAndGrandParent(current);
                    this.rotate.RotateLeft(ref this.root, current.rbParent.rbParent);
                }

                break;
            }

            this.Root.Color = NodeColor.Black;
            return true;
        }

        private RedBlackTreeNode<T> FixRedUncleScenario(RedBlackTreeNode<T> current)
        {
            current.rbParent.Color = NodeColor.Black;
            current.rbUncle.Color = NodeColor.Black;

            var grandParent = current.rbParent.rbParent;
            grandParent.Color = NodeColor.Red;
            return grandParent;
        }

        private void ColorParentAndGrandParent(RedBlackTreeNode<T> node)
        {
            node.rbParent.Color = NodeColor.Black;
            node.rbParent.rbParent.Color = NodeColor.Red;
        }
    }
}
