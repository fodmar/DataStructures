using NUnit.Framework;
using DataStructures.Tests.Scenarios.Collection;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests
{
    [TestFixture]
    class CollectionTests : TestsClass
    {
        static object AddTests = Prepare(DataStructuresFactory.GetCollections(), new AddScenarioGenerator());
        static object RemoveTests = Prepare(DataStructuresFactory.GetCollections(), new RemoveScenarioGenerator());
        static object ContainsTests = Prepare(DataStructuresFactory.GetCollections(), new ContainsScenarioGenerator());

        [Test]
        [Timeout(1000)]
        [TestCaseSource("AddTests")]
        public void Add(AddScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            foreach (var item in scenario.ItemsToAdd)
            {
                list.Add(item);
            }

            AssertHelper.AreCollectionSame(scenario.ExpectedElements, list);
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource("RemoveTests")]
        public void Remove(RemoveScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            bool wasRemoved = list.Remove(scenario.ToRemove);

            Assert.AreEqual(scenario.ExpectedRemoved, wasRemoved);
            AssertHelper.AreCollectionSame(scenario.ExpectedElements, list);
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource("ContainsTests")]
        public void Contains(ContainsScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            bool contains = list.Contains(scenario.ToFind);

            Assert.AreEqual(scenario.Expected, contains);
        }
    }
}
