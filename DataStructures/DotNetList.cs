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

        public new IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
