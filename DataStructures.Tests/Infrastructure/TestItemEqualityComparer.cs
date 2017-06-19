using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.Infrastructure
{
    class TestItemEqualityComparer : IEqualityComparer<TestItem>
    {
        public bool Equals(TestItem x, TestItem y)
        {
            if (x == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public int GetHashCode(TestItem obj)
        {
            return obj.GetHashCode();
        }
    }
}
