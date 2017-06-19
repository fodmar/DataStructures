using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using DataStructures.Tests.Scenarios.Enumerable;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;

namespace DataStructures.Tests
{
    [TestFixture]
    class EnumerableTests
    {
        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(EnumerableTestFactory), "Foreach")]
        public void Foreach(ForeachScenario scenario)
        {
            IMyEnumerable<TestItem> list = scenario.List;

            int output = 0;

            foreach (TestItem item in list)
            {
                output += item.IntValue;
            }

            Assert.AreEqual(scenario.ExpectedOutput, output);
        }
    }
}
