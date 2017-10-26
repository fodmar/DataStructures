using System;
using NUnit.Framework;
using DataStructures.Tests.Scenarios.List;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests
{
    [TestFixture]
    class ListTests : TestsClass
    {
        static object IndexerTests = Prepare(DataStructuresFactory.GetLists(), new IndexerScenarioGenerator());
        static object IndexOfTests = Prepare(DataStructuresFactory.GetLists(), new IndexOfScenarioGenerator());
        static object RemoveAtTests = Prepare(DataStructuresFactory.GetLists(), new RemoveAtScenarioGenerator());
        static object InsertTests = Prepare(DataStructuresFactory.GetLists(), new InsertTestGenerator());

        [Test]
        [Timeout(1000)]
        [TestCaseSource("IndexerTests")]
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
        [TestCaseSource("IndexOfTests")]
        public void IndexOf(IndexOfScenario scenario)
        {
            IMyList<TestItem> list = (IMyList<TestItem>)scenario.List;

            int index = list.IndexOf(scenario.ToFind);

            Assert.AreEqual(scenario.ExpectedIndex, index);
        }


        [Test]
        [Timeout(1000)]
        [TestCaseSource("RemoveAtTests")]
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
        [TestCaseSource("InsertTests")]
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
