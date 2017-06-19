using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using DataStructures.Tests.Scenarios.List;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;

namespace DataStructures.Tests
{
    [TestFixture]
    class ListTests
    {
        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(ListTestFactory), "IndexerGet")]
        public void Indexer(IndexerScenario scenario)
        {
            IMyList<TestItem> list = (IMyList<TestItem>)scenario.List;

            try
            {
                TestItem testItem = list[scenario.Index];
                Assert.AreEqual(testItem, scenario.ExceptedItem);
            }
            catch (Exception ex)
            {
                if (scenario.ExpectedExceptionType == null)
                {
                    throw;
                }

                Assert.IsInstanceOfType(scenario.ExpectedExceptionType, ex);
            }
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(ListTestFactory), "IndexOf")]
        public void IndexOf(IndexOfScenario scenario)
        {
            IMyList<TestItem> list = (IMyList<TestItem>)scenario.List;

            int index = list.IndexOf(scenario.ToFind);

            Assert.AreEqual(scenario.ExpectedIndex, index);
        }


        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(ListTestFactory), "RemoveAt")]
        public void RemoveAt(RemoveAtScenario scenario)
        {
            IMyList<TestItem> list = (IMyList<TestItem>)scenario.List;

            try
            {
                list.RemoveAt(scenario.ToRemove);
            }
            catch (Exception ex)
            {
                if (scenario.ExpectedExceptionType == null)
                {
                    throw;
                }

                Assert.IsInstanceOfType(scenario.ExpectedExceptionType, ex);
            }

            AssertHelper.AreCollectionSame(scenario.ExpectedElements, list);
        }


        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(ListTestFactory), "Insert")]
        public void Insert(InsertScenario scenario)
        {
            IMyList<TestItem> list = (IMyList<TestItem>)scenario.List;

            try
            {
                foreach (var toInsert in scenario.ToInsert)
                {
                    list.Insert(toInsert.Key, toInsert.Value);
                }
            }
            catch (Exception ex)
            {
                if (scenario.ExpectedExceptionType == null)
                {
                    throw;
                }

                Assert.IsInstanceOfType(scenario.ExpectedExceptionType, ex);
            }

            AssertHelper.AreCollectionSame(scenario.ExpectedElements, list);
        }
    }
}
