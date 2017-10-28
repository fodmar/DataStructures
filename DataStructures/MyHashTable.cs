using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyHashTable<T> : IMyCollection<T>
    {
        private IMyList<T>[] buckets;
        private IEqualityComparer<T> equalityComparer;

        public MyHashTable(T[] initializer)
        {
            this.buckets = new MyList<T>[128];
            this.equalityComparer = EqualityComparer<T>.Default;

            if (initializer != null)
            {
                for (int i = 0; i < initializer.Length; i++)
                {
                    this.Add(initializer[i]);
                }
            }
        }

        public MyHashTable() : this(null)
        {
        }

        public int Count { get; private set; }

        public bool Add(T item)
        {
            int bucket = this.CalculateHash(item);

            if (this.buckets[bucket] == null)
            {
                this.buckets[bucket] = new MyList<T>();
            }

            this.buckets[bucket].Add(item);
            this.Count++;
            return true;
        }

        public bool Remove(T item)
        {
            int bucket = this.CalculateHash(item);

            if (this.buckets[bucket] == null)
            {
                return false;
            }

            bool removed = this.buckets[bucket].Remove(item);

            if (removed)
            {
                this.Count--;
            }

            return removed;
        }

        public bool Contains(T item)
        {
            int bucket = this.CalculateHash(item);

            if (this.buckets[bucket] == null)
            {
                return false;
            }

            return this.buckets[bucket].Contains(item);
        }

        private int CalculateHash(T item)
        {
            int hash = item.GetHashCode() % this.buckets.Length;

            if (hash < 0)
            {
                hash += this.buckets.Length;
            }

            return hash;
        }

        public IEnumerator<T> GetEnumerator()
        {
            IMyList<IEnumerator<T>> enumerators = new MyList<IEnumerator<T>>();

            for (int i = 0; i < this.buckets.Length; i++)
            {
                IMyList<T> bucket = this.buckets[i];

                if (bucket != null && bucket.Count > 0)
                {
                    enumerators.Add(bucket.GetEnumerator());
                }
            }

            return new MyHashTableEnumerator<T>(enumerators);
        }

        private class MyHashTableEnumerator<T> : IEnumerator<T>
        {
            private int nextIndex;
            private IMyList<IEnumerator<T>> enumerators;
            private IEnumerator<T> currentEnumerator;

            public MyHashTableEnumerator(IMyList<IEnumerator<T>> enumerators)
            {
                this.enumerators = enumerators;
                this.Reset();
            }

            public T Current
            {
                get { return this.currentEnumerator.Current; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                if (this.currentEnumerator.MoveNext())
                {
                    return true;
                }

                if (this.nextIndex < this.enumerators.Count)
                {
                    this.currentEnumerator = this.enumerators[nextIndex++];
                    return this.currentEnumerator.MoveNext();
                }

                return false;
            }

            public void Reset()
            {
                if (enumerators.Count > 0)
                {
                    this.currentEnumerator = enumerators[0];
                    this.nextIndex = 1;
                }
                else
                {
                    this.currentEnumerator = new EmptyEnumerator<T>();
                }
            }

            public void Dispose()
            {
            }
        }
    }
}
