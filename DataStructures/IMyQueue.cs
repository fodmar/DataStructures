using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IMyQueue<T> : IMyEnumerable<T>
    {
        int Count { get; }
        T Current { get; }
        T Dequeue();
        void Enqueue(T item);
    }
}
