using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T> : IMyCollection<T>
    {
        protected class Node<T>
        {
            public Node(T item)
            {
                this.Value = item;
            }

            public Node(T item, Node<T> parent)
            {
                this.Value = item;
                this.Parent = parent;
            }

            public T Value { get; set; }
            public Node<T> Parent { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
        }

        protected IEqualityComparer<T> equalityComparer;
        protected IComparer<T> comparer;
        protected Node<T> root;

        public BinaryTree(T[] initializer)
        {
            this.comparer = Comparer<T>.Default;
            this.equalityComparer = EqualityComparer<T>.Default;

            if (initializer != null)
            {
                for (int i = 0; i < initializer.Length; i++)
                {
                    this.Add(initializer[i]);
                }
            }
        }

        public BinaryTree() : this(null)
        {
        }

        private bool IsGreater(T a, T b)
        {
            return this.comparer.Compare(a, b) == 1;
        }

        protected virtual Node<T> CreateNode(T item)
        {
            return new Node<T>(item);
        }

        protected virtual Node<T> CreateNode(T item, Node<T> parent)
        {
            return new Node<T>(item, parent);
        }

        public int Count { get; private set; }

        public virtual void Add(T item)
        {
            this.Count++;

            if (this.root == null)
            {
                this.root = this.CreateNode(item);
                return;
            }

            Node<T> parent = null;
            Node<T> currentNode = this.root;
            bool isGreater;

            do
            {
                parent = currentNode;
                isGreater = this.IsGreater(item, currentNode.Value);

                if (isGreater)
                {
                    currentNode = parent.Right;
                }
                else
                {
                    currentNode = parent.Left;
                }
            }
            while (currentNode != null);

            if (isGreater)
            {
                parent.Right = this.CreateNode(item, parent);
            }
            else
            {
                parent.Left = this.CreateNode(item, parent);
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            Node<T> current = this.root;

            while (current != null)
            {
                int compare = this.comparer.Compare(item, current.Value);

                if (compare == 1)
                {
                    current = current.Right;
                }
                else if (compare == -1)
                {
                    current = current.Left;
                }
                else
                {
                    return this.equalityComparer.Equals(item, current.Value);
                }
            }

            return false;
        }

        public T Min()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            return this.MinInSubTree(this.root).Value;
        }

        public T Max()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            return this.MaxInSubTree(this.root).Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.PreOrder().GetEnumerator();
        }

        public IEnumerable<T> PreOrder()
        {
            if (this.root == null)
            {
                yield break;
            }

            MyStack<Node<T>> stack = new MyStack<Node<T>>();

            stack.Push(this.root);

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();

                yield return current.Value;

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }

        public IEnumerable<T> InOrder()
        {
            if (this.root ==  null)
	        {
                yield break;
	         }

            MyStack<Node<T>> stack = new MyStack<Node<T>>();

            Node<T> current = this.root;

            do
            {
                if (current == null)
                {
                    current = stack.Pop();

                    yield return current.Value;

                    current = current.Right;
                }
                else
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }
            while (stack.Count > 0 || current != null);
        }

        public IEnumerable<T> PostOrder()
        {
            if (this.root == null)
            {
                yield break;
            }

            MyStack<Node<T>> stack = new MyStack<Node<T>>();

            Node<T> current = null;
            Node<T> parent = null;

            stack.Push(this.root);

            do
            {
                current = stack.Top;

                if (parent == null || parent.Left == current || parent.Right == current)
                {
                    if (current.Left != null)
                    {
                        stack.Push(current.Left);
                    }
                    else if (current.Right != null)
                    {
                        stack.Push(current.Right);
                    }
                }
                else if (parent == current.Left)
                {
                    if (current.Right != null)
                    {
                        stack.Push(current.Right);
                    }
                }
                else
                {
                    yield return current.Value;
                    stack.Pop();
                }

                parent = current;
            }
            while (stack.Count > 0);
        }

        public IEnumerable<T> BreadthFirst()
        {
            if (this.root == null)
            {
                yield break;
            }

            MyQueue<Node<T>> queue = new MyQueue<Node<T>>();
            Node<T> current = this.root;

            queue.Enqueue(current);

            do
            {
                current = queue.Dequeue();

                yield return current.Value;

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
            while (queue.Count > 0);
        }

        protected Node<T> MinInSubTree(Node<T> subTree)
        {
            Node<T> result = subTree;

            while (result.Left != null)
            {
                result = result.Left;
            }

            return result;
        }

        protected Node<T> MaxInSubTree(Node<T> subTree)
        {
            Node<T> result = subTree;

            while (result.Right != null)
            {
                result = result.Right;
            }

            return result;
        }
    }
}
