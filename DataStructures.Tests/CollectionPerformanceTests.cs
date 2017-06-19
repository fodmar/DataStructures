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

            using (StreamWriter streamWriter = File.AppendText(string.Format("{0}{1}", "AddPerformance", list.GetType().Name)))
            {
                streamWriter.WriteLine(string.Format("{0} {1}", scenario.ItemsToAdd.Length, stopwatch.ElapsedMilliseconds));
            }
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

            using (StreamWriter streamWriter = File.AppendText(string.Format("{0}{1}", "RemovePerformance", list.GetType().Name)))
            {
                streamWriter.WriteLine(string.Format("{0} {1}", scenario.ToRemove.Length, stopwatch.ElapsedMilliseconds));
            }
        }
    }
}
