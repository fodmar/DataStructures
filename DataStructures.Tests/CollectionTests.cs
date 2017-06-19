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

namespace DataStructures.Tests
{
    [TestFixture]
    class CollectionTests
    {
        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(CollectionTestFactory), "Add")]
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
        [TestCaseSource(typeof(CollectionTestFactory), "Remove")]
        public void Remove(RemoveScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            bool wasRemoved = list.Remove(scenario.ToRemove);

            Assert.AreEqual(scenario.ExpectedRemoved, wasRemoved);
            AssertHelper.AreCollectionSame(scenario.ExpectedElements, list);
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(CollectionTestFactory), "Contains")]
        public void Contains(ContainsScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            bool contains = list.Contains(scenario.ToFind);

            Assert.AreEqual(scenario.Expected, contains);
        }
    }
}
