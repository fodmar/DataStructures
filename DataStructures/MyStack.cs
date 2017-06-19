using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyStack<T> : IMyStack<T>
    {
        private IMyList<T> list;

        public MyStack(T[] initializer)
        {
            this.list = new MyList<T>(initializer);
        }

        public MyStack() : this(null)
        {
        }

        private int LastIndex
        {
            get { return this.Count - 1; }
        }

        public int Count
        { 
            get { return this.list.Count; }
        }

        public T Top
        { 
            get { return this.list[this.LastIndex]; } 
        }

        public T Pop()
        {
            T top = this.Top;

            this.list.RemoveAt(this.LastIndex);

            return top;
        }

        public void Push(T item)
        {
            this.list.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.list);
        }

        private class Enumerator : IEnumerator<T>
        {
            private IMyList<T> list;
            private int currentIndex;

            public Enumerator(IMyList<T> list)
            {
                this.list = list;
                this.currentIndex = this.list.Count;
            }

            public T Current
            {
                get { return this.list[currentIndex]; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                this.currentIndex--;
                return this.currentIndex > -1;
            }

            public void Reset()
            {
                this.currentIndex = this.list.Count;
            }

            public void Dispose()
            {
            }
        }
    }
}
