using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyQueue<T> : IMyQueue<T>
    {
        private T[] array;
        private int allocated;
        private int first;
        private int last;

        public MyQueue(T[] initializer)
        {
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

                this.last = initializer.Length;
                this.allocated = arrayLength;
            }
        }

        public MyQueue() : this(null)
        {
        }

        public int Count { get { return this.last - this.first; } }

        public T Current
        {
            get { return this.array[first]; }
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T current = this.array[first];

            this.array[first++] = default(T);

            return current;
        }

        public void Enqueue(T item)
        {
            if (this.last < this.allocated)
            {
                this.array[this.last++] = item;
                return;
            }

            this.allocated *= 2;
            T[] temp = new T[this.allocated];

            for (int i = this.first; i < this.last; i++)
            {
                temp[i] = this.array[i];
            }

            temp[this.last++] = item;
            this.array = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this.array, this.first, this.last);
        }

        private class Enumerator<T> : IEnumerator<T>
        {
            private int first;
            private int last;
            private int current;
            private T[] array;

            public Enumerator(T[] array, int first, int last)
            {
                this.array = array;
                this.first = first;
                this.last = last;
                this.current = first - 1;
            }

            public T Current
            {
                get { return this.array[current]; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                this.current++;
                return this.current < this.last;
            }

            public void Reset()
            {
                this.current = this.first - 1;
            }

            public void Dispose()
            {
            }
        }
    }
}
