using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using DataStructures.Tests.Scenarios.Collection;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;

namespace DataStructures.Tests.BinaryHeap
{
    [TestFixture]
    class Tests
    {
        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(TestFactory), "Pop")]
        public void Pop(PopScenario scenario)
        {
            var heap = (MyBinaryHeap<TestItem>)scenario.List;

            for (int i = 0; i < scenario.PopResult.Length; i++)
            {
                TestItem item = heap.Pop();
                Assert.AreEqual(scenario.PopResult[i], item);
            }

            AssertHelper.AreCollectionSame(scenario.Expected, heap);
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(TestFactory), "Add")]
        public void Add(AddScenario scenario)
        {
            var heap = (MyBinaryHeap<TestItem>)scenario.List;

            for (int i = 0; i < scenario.ToAdd.Length; i++)
            {
                heap.Add(scenario.ToAdd[i]);
                Assert.AreEqual(scenario.PopResult[i], heap.Root);
            }

            AssertHelper.AreCollectionSame(scenario.Expected, heap);
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(TestFactory), "Remove")]
        public void Remove(RemoveScenario scenario)
        {
            var heap = (MyBinaryHeap<TestItem>)scenario.List;

            for (int i = 0; i < scenario.ToRemove.Length; i++)
            {
                heap.Remove(scenario.ToRemove[i]);
                Assert.AreEqual(scenario.PopResult[i], heap.Root);
            }

            AssertHelper.AreCollectionSame(scenario.Expected, heap);
        }
    }
}
