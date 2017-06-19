using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using DataStructures;
using DataStructures.Tests.Scenarios.Collection;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;

namespace DataStructures.Tests.Queue
{
    [TestFixture]
    class Tests
    {
        [Test]
        [TestCaseSource(typeof(TestFactory), "Queue")]
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
