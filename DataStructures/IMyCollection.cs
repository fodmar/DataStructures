using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IMyCollection<T> : IMyEnumerable<T>
    {
        int Count { get; }

        void Add(T item);
        bool Remove(T item);
        bool Contains(T item);
    }
}
