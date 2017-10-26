using NUnit.Framework;
using DataStructures.Tests.Scenarios.Collection;
using DataStructures.Tests.Infrastructure;
using System.Diagnostics;
using System.Reflection;
namespace DataStructures.Tests
{
    [TestFixture]
    class CollectionPerformanceTests : TestsClass
    {
        static object AddTests = Prepare(DataStructuresFactory.GetCollections(), new AddPerformanceScenarioGenerator());
        static object RemoveTests = Prepare(DataStructuresFactory.GetCollections(), new RemovePerformanceScenarioGenerator());
        static object ContainsTests = Prepare(DataStructuresFactory.GetCollections(), new ContainsPerformanceScenarioGenerator());

        [Test]
        [TestCaseSource("AddTests")]
        [Ignore]
        public void AddPerformance(AddScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in scenario.ItemsToAdd)
            {
                list.Add(item);
            }
            stopwatch.Stop();

            this.SaveResultsToFile(
                list.GetType(),
                MethodBase.GetCurrentMethod().Name,
                scenario.ItemsToAdd.Length,
                stopwatch.ElapsedMilliseconds);
        }

        [Test]
        [TestCaseSource("RemoveTests")]
        [Ignore]
        public void RemovePerformance(RemovePerformanceScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in scenario.ToRemove)
            {
                list.Remove(item);
            }
            stopwatch.Stop();

            this.SaveResultsToFile(
                list.GetType(),
                MethodBase.GetCurrentMethod().Name,
                list.Count,
                stopwatch.ElapsedMilliseconds);
        }

        [Test]
        [TestCaseSource("ContainsTests")]
        [Ignore]
        public void ContainsPerformance(ContainsPerformanceScenario scenario)
        {
            IMyCollection<TestItem> list = (IMyCollection<TestItem>)scenario.List;

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in scenario.ToFind)
            {
                list.Contains(item);
            }
            stopwatch.Stop();

            this.SaveResultsToFile(
                list.GetType(),
                MethodBase.GetCurrentMethod().Name,
                list.Count,
                stopwatch.ElapsedMilliseconds);
        }
    }
}
