using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DotNetLinkedList<T> : LinkedList<T>, IMyCollection<T>
    {
        public DotNetLinkedList() : base()
        {
        }

        public DotNetLinkedList(T[] initial) : base(initial)
        {
        }

        public bool Add(T item)
        {
            base.AddLast(item);
            return true;
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
