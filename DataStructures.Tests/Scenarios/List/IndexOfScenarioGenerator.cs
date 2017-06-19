using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class IndexOfScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            TestItem[] initial = Generate(8);

            TestItem[] four = Generate(4);
            TestItem nonExisting = GenerateOne(-5);

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = four[0],
                ExpectedIndex = 0
            };

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = four[0],
                ExpectedIndex = 0
            };

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = four[1],
                ExpectedIndex = 1
            };

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = four[2],
                ExpectedIndex = 2
            };

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = four[3],
                ExpectedIndex = 3
            };

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = GenerateOne(3),
                ExpectedIndex = 3
            };

            yield return new IndexOfScenario
            {
                Initial = initial,
                ToFind = nonExisting,
                ExpectedIndex = -1
            };
        }
    }
}
