using NUnit.Framework;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Queue
{
    [TestFixture]
    class Tests : TestsClass
    {
        static object QueueTests = Prepare(DataStructuresFactory.GetQueues(), new ScenarioGenerator());

        [Test]
        [Timeout(1000)]
        [TestCaseSource("QueueTests")]
        public void Queue(Scenario scenario)
        {
            var queue = (MyQueue<TestItem>)scenario.List;

            for (int i = 0; i < scenario.ToEnqueue.Length; i++)
            {
                queue.Enqueue(scenario.ToEnqueue[i]);
            }

            for (int i = 0; i < scenario.Dequeued.Length; i++)
            {
                TestItem dequeued = queue.Dequeue();
                Assert.AreEqual(scenario.Dequeued[i], dequeued);
            }

            AssertHelper.AreCollectionSame(scenario.Expected, queue);
        }
    }
}
