using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class IndexerScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            TestItem[] two = Generate(2);

            yield return new IndexerScenario
            {
                Index = 0,
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new IndexerScenario
            {
                Initial = two,
                Index = -1,
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new IndexerScenario
            {
                Initial = two,
                Index = 2,
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new IndexerScenario
            {
                Initial = two,
                Index = 0,
                ExceptedItem = two.First()
            };

            yield return new IndexerScenario
            {
                Initial = two,
                Index = 1,
                ExceptedItem = two.Last()
            };
        }
    }
}
