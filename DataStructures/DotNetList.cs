using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DotNetList<T> : List<T>, IMyList<T>
    {
        public DotNetList() : base()
        {
        }

        public DotNetList(T[] initial) : base(initial)
        {
        }

        public bool Add(T item)
        {
            base.Add(item);
            return true;
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
