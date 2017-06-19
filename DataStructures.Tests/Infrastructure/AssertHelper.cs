using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace DataStructures.Tests.Infrastructure
{
    static class AssertHelper
    {
        public static void AreCollectionSame(TestItem[] expected, IMyEnumerable<TestItem> actual)
        {
            Assert.AreEqual(expected.Length, actual.Count);

            foreach (var item in actual)
            {
                Assert.That(expected.Contains(item));
            }
        }
    }
}
