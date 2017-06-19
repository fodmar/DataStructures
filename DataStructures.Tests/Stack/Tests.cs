using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using NUnit.Framework;

namespace DataStructures.Tests.Stack
{
    [TestFixture]
    class Tests
    {
        [Test]
        [TestCaseSource(typeof(TestFactory), "Stack")]
        public void Stack(Scenario scenario)
        {
            var stack = (MyStack<TestItem>)scenario.List;

            for (int i = 0; i < scenario.Pushed.Length; i++)
            {
                stack.Push(scenario.Pushed[i]);
            }

            for (int i = 0; i < scenario.ToPop.Length; i++)
            {
                TestItem poped = stack.Pop();
                Assert.AreEqual(scenario.ToPop[i], poped);
            }

            AssertHelper.AreCollectionSame(scenario.Expected, stack);
        }
    }
}
