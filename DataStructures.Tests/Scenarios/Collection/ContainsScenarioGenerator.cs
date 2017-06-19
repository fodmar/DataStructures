using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Collection
{
    class ContainsScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            TestItem[] initial = Generate(8);

            TestItem[] four = Generate(4);
            TestItem nonExisting = GenerateOne(-5);

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = four[0],
                Expected = true
            };

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = four[0],
                Expected = true
            };

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = four[1],
                Expected = true
            };

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = four[2],
                Expected = true
            };

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = four[3],
                Expected = true
            };

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = GenerateOne(3),
                Expected = true
            };

            yield return new ContainsScenario
            {
                Initial = initial,
                ToFind = nonExisting,
                Expected = false
            };
        }
    }
}
