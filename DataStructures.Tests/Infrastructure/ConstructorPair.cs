using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures.Tests.Infrastructure
{
    class ConstructorPair
    {
        public Func<IMyEnumerable<TestItem>> WithoutInitial { get; set; }
        public Func<TestItem[], IMyEnumerable<TestItem>> WithInitial { get; set; }
    }
}
