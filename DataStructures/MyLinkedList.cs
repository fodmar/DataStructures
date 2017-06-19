using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyLinkedList<T> : IMyCollection<T>
    {
        private class Node<T>
        {
            public Node(T item)
            {
                this.Value = item;
            }

            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }
        }

        private Node<T> first;
        private Node<T> last;

        private IEqualityComparer<T> equalityComparer;

        public MyLinkedList(T[] initializer)
        {
            this.equalityComparer = EqualityComparer<T>.Default;

            if (initializer != null)
            {
                for (int i = 0; i < initializer.Length; i++)
                {
                    this.Add(initializer[i]);
                }
            }
        }

        public MyLinkedList() : this(null)
        {
        }

        public T Head { get { return this.first.Value; } }
        public T Tail { get { return this.last.Value; } }
        public int Count { get; private set; }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);

            newNode.Prev = this.last;

            if (this.last != null)
            {
                this.last.Next = newNode;
            }

            this.last = newNode;

            if (this.first == null)
            {
                this.first = newNode;
            }

            this.Count++;
        }

        public bool Remove(T item)
        {
            Node<T> current = this.first;

            while (current != null)
            {
                if (this.equalityComparer.Equals(item, current.Value))
                {
                    Node<T> prev = current.Prev;
                    Node<T> next = current.Next;

                    if (prev != null)
                    {
                        prev.Next = next;
                    }

                    if (next != null)
                    {
                        next.Prev = prev;
                    }

                    if (current == this.first)
                    {
                        this.first = current.Next;
                    }

                    if (current == this.last)
                    {
                        this.last = null;
                    }

                    this.Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Contains(T item)
        {
            Node<T> current = this.first;

            while (current != null)
            {
                if (this.equalityComparer.Equals(item, current.Value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyLinkedListEnumerator<T>(this.first);
        }

        private class MyLinkedListEnumerator<T> : IEnumerator<T>
        {
            private Node<T> current;
            private Node<T> first;

            public MyLinkedListEnumerator(Node<T> first)
            {
                this.first = first;
            }

            public T Current
            {
                get { return this.current.Value; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                if (this.current == null)
                {
                    if (this.first == null)
                    {
                        return false;
                    }

                    this.current = this.first;
                    this.first = null;

                    return true;
                }

                this.current = this.current.Next;
                return this.current != null;
            }

            public void Reset()
            {
                this.current = null;
            }

            public void Dispose()
            {
            }
        }
    }
}
