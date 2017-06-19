using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyBinaryHeap<T> : IMyCollection<T>
    {
        private IMyList<T> array;
        private IComparer<T> comparer;

        public MyBinaryHeap(T[] initializer)
        {
            this.comparer = Comparer<T>.Default;
            this.array = new MyList<T>();

            if (initializer != null)
            {
                for (int i = 0; i < initializer.Length; i++)
                {
                    this.Add(initializer[i]);
                }
            }
        }

        public MyBinaryHeap() : this(null)
        {
        }


        public int Count
        {
            get { return this.array.Count; }
        }

        public T Root
        {
            get
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("Heap is empty");
                }

                return this.array[0];
            }
        }

        private int LastIndex
        {
            get { return this.Count - 1; }
        }

        private T LastItem
        {
            get { return this.array[this.LastIndex]; }
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private int Left(int index)
        {
            return (index * 2) + 1;
        }

        private int Right(int index)
        {
            return (index * 2) + 2;
        }

        private void Swap(int a, int b)
        {
            T temp = this.array[a];
            this.array[a] = this.array[b];
            this.array[b] = temp;
        }

        private bool IsGreater(int a, int b)
        {
            return this.comparer.Compare(this.array[a], this.array[b]) == 1;
        }

        private bool IsGreater(T a, int b)
        {
            return this.comparer.Compare(a, this.array[b]) == 1;
        }

        private bool IsGreater(int a, T b)
        {
            return this.comparer.Compare(this.array[a], b) == 1;
        }

        private bool IsGreater(T a, T b)
        {
            return this.comparer.Compare(a, b) == 1;
        }

        private void Heapify(int index)
        {
            int higherIndex;

            do
            {
                higherIndex = index;
                int leftIndex = this.Left(index);
                int rightIndex = this.Right(index);

                if (leftIndex < this.Count && this.IsGreater(leftIndex, higherIndex))
                {
                    higherIndex = leftIndex;
                }

                if (rightIndex < this.Count && this.IsGreater(rightIndex, higherIndex))
                {
                    higherIndex = rightIndex;
                }

                if (higherIndex != index)
                {
                    this.Swap(higherIndex, index);
                    index = higherIndex;
                }
            }
            while (higherIndex != index);
        }

        public void Add(T item)
        {
            int childIndex = this.Count;
            this.array.Add(item);

            int parentIndex = this.Parent(childIndex);

            while (this.IsGreater(item, parentIndex))
            {
                this.Swap(childIndex, parentIndex);

                childIndex = parentIndex;
                parentIndex = this.Parent(childIndex);
            }
        }

        public bool Remove(T item)
        {
            int itemIndex = this.array.IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            this.array[itemIndex] = this.LastItem;

            this.array.RemoveAt(this.LastIndex);
            this.Heapify(itemIndex);

            return true;
        }

        public T Pop()
        {
            T root = this.Root;
            T lastItem = this.LastItem;

            this.array.RemoveAt(this.LastIndex);

            if (this.Count > 0)
            {
                this.array[0] = lastItem;
                this.Heapify(0);
            }

            return root;
        }

        public bool Contains(T item)
        {
            return this.array.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.array.GetEnumerator();
        }
    }
}
