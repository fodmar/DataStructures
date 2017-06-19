using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Scenarios.Collection
{
    class AddPerformanceScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new AddScenario
            {
                ItemsToAdd = Generate(50000)
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(100000)
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(150000)
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(200000)
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(250000)
            };
        }
    }
}
