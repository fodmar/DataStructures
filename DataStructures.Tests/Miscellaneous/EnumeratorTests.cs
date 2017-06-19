using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;
using NUnit.Framework;

namespace DataStructures.Tests.Miscellaneous
{
    [TestFixture]
    class EnumeratorTests
    {
        [Test]
        [Ignore]
        public void Enumerate()
        {
            IEnumerator<TestItem> enumerator;
            Generator generator = new Generator();
            var list = (MyList<TestItem>)generator.Generate().First().List;

            enumerator = list.GetYieldEnumerator();

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
            }
            stopwatch.Stop();
            Console.WriteLine("Enumerator - {0}", stopwatch.ElapsedMilliseconds);

            enumerator = list.GetEnumerator();

            stopwatch = Stopwatch.StartNew();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
            }
            stopwatch.Stop();
            Console.WriteLine("YieldEnumerator - {0}", stopwatch.ElapsedMilliseconds);
        }

        private class Generator : ScenarioGeneratorBase
        {
            public override IEnumerable<ScenarioBase> Generate()
            {
                yield return new ScenarioBase
                {
                    List = new MyList<TestItem>(Generate(1000000))
                };
            }
        }
    }
}
