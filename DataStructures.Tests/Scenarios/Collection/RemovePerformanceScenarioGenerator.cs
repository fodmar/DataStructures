using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.Scenarios.Collection
{
    class RemovePerformanceScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new RemovePerformanceScenario
            {
                Initial = GenerateRandom(25000),
                ToRemove = GenerateRandom(2500)
            };

            yield return new RemovePerformanceScenario
            {
                Initial = GenerateRandom(25000),
                ToRemove = GenerateRandom(5000)
            };

            yield return new RemovePerformanceScenario
            {
                Initial = GenerateRandom(25000),
                ToRemove = GenerateRandom(7500)
            };

            yield return new RemovePerformanceScenario
            {
                Initial = GenerateRandom(25000),
                ToRemove = GenerateRandom(10000)
            };
        }
    }
}
