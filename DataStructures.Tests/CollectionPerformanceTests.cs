using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit;
using NUnit.Framework;
using DataStructures;
using DataStructures.Tests;
using DataStructures.Tests.Scenarios.Collection;
using DataStructures.Tests.Infrastructure.Factory;
using DataStructures.Tests.Infrastructure;
using System.Diagnostics;
using System.Reflection;
namespace DataStructures.Tests
{
    [TestFixture]
    class CollectionPerformanceTests
    {
        [Test]
        [TestCaseSource(typeof(CollectionTestFactory), "AddPerformance")]
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
        [TestCaseSource(typeof(CollectionTestFactory), "RemovePerformance")]
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
        [TestCaseSource(typeof(CollectionTestFactory), "ContainsPerformance")]
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

        private void SaveResultsToFile(Type collectionType, string fileName, int elements, long miliseconds)
        {
            using (StreamWriter streamWriter = File.AppendText(string.Format("_{0}{1}", fileName, collectionType.Name)))
            {
                streamWriter.WriteLine(string.Format("{0} {1}", elements, miliseconds));
            }
        }
    }
}
