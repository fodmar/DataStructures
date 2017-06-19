using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.Infrastructure
{
    class TestItemComparer : IComparer, IComparer<TestItem>
    {
        public int Compare(object x, object y)
        {
            return this.Compare(x as TestItem, y as TestItem);
        }

        public int Compare(TestItem x, TestItem y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null && y != null)
            {
                return -1;
            }

            if (x != null && y == null)
            {
                return 1;
            }

            if (x.IntValue > y.IntValue)
            {
                return 1;
            }

            if (x.IntValue < y.IntValue)
            {
                return -1;
            }

            return 0;
        }
    }
}