using NUnit.Framework;
using DataStructures.Tests.Scenarios.Enumerable;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests
{
    [TestFixture]
    class EnumerableTests : TestsClass
    {
        static object ForeachTests = Prepare(DataStructuresFactory.GetEnumerables(), new ForeachScenarioGenerator());

        [Test]
        [Timeout(1000)]
        [TestCaseSource("ForeachTests")]
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
