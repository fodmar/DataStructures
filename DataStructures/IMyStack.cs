using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IMyStack<T> : IMyEnumerable<T>
    {
        int Count { get; }
        T Top { get; }
        T Pop();
        void Push(T item);
    }
}
