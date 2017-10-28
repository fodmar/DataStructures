using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyList<T> : IMyList<T>
    {
        private IEqualityComparer<T> equalityComparer;
        private T[] array;

        private int allocated;

        public MyList(T[] initializer)
        {
            this.equalityComparer = EqualityComparer<T>.Default;

            if (initializer == null || initializer.Length == 0)
            {
                this.allocated = 32;
                this.array = new T[this.allocated];
            }
            else
            {
                int arrayLength = (int)Math.Pow(2, (int)(Math.Log(initializer.Length, 2)) + 1);
                this.array = new T[arrayLength];

                for (int i = 0; i < initializer.Length; i++)
                {
                    this.array[i] = initializer[i];
                }

                this.Count = initializer.Length;
                this.allocated = arrayLength;
            }
        }

        public MyList() : this(null)
        {
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return this.array[index];
            }

            set
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                this.array[index] = value;
            }
        }

        public bool Add(T item)
        {
            if (this.Count < this.allocated)
            {
                this.array[this.Count++] = item;
                return true;
            }

            this.allocated *= 2;
            T[] temp = new T[this.allocated];

            for (int i = 0; i < this.Count; i++)
            {
                temp[i] = this.array[i];
            }

            temp[this.Count++] = item;
            this.array = temp;
            return true;
        }

        public bool Remove(T item)
        {
            int itemIndex = this.IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            this.RemoveAt(itemIndex);
            return true;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || this.Count < index)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (this.Count < this.allocated)
            {
                int i = this.Count++;
                while (index < i)
                {
                    this.array[i] = this.array[--i];
                }

                this.array[index] = item;
            }
            else
            {
                this.allocated *= 2;
                T[] temp = new T[this.allocated];

                for (int i = 0; i < index; i++)
                {
                    temp[i] = this.array[i];
                }

                temp[index] = item;

                while (index < this.Count)
                {
                    T tempItem = this.array[index++];
                    temp[index] = tempItem;
                }

                this.Count++;
                this.array = temp;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            this.Count--;

            while (index < this.Count)
            {
                this.array[index] = this.array[++index];
            }

            this.array[this.Count] = default(T);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.equalityComparer.Equals(item, this.array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        public IEnumerator<T> GetYieldEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        private class MyListEnumerator<T> : IEnumerator<T>
        {
            private IMyList<T> list;
            private int current;

            public MyListEnumerator(IMyList<T> list)
            {
                this.list = list;
                this.current = -1;
            }

            public T Current
            {
                get { return this.list[current]; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                this.current++;
                return this.current < list.Count;
            }

            public void Reset()
            {
                this.current = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
