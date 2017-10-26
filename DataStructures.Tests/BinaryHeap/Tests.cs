using NUnit.Framework;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.BinaryHeap
{
    [TestFixture]
    class Tests : TestsClass
    {
        static object PopTests = Prepare(DataStructuresFactory.GetBinaryHeaps(), new PopScenarioGenerator());
        static object AddTests = Prepare(DataStructuresFactory.GetBinaryHeaps(), new AddScenarioGenerator());
        static object RemoveTests = Prepare(DataStructuresFactory.GetBinaryHeaps(), new RemoveScenarioGenerator());

        [Test]
        [Timeout(1000)]
        [TestCaseSource("PopTests")]
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
        [TestCaseSource("AddTests")]
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
        [TestCaseSource("RemoveTests")]
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
