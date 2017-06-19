using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Collection
{
    class AddScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new AddScenario
            {
                ItemsToAdd = new TestItem[0],
                ExpectedElements = new TestItem[0]
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(1),
                ExpectedElements = Generate(1)
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(3),
                ExpectedElements = Generate(3)
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(6),
                ExpectedElements = Generate(6)
            };

            yield return new AddScenario
            {
                Initial = Generate("0 2 3"),
                ItemsToAdd = Generate("6 7"),
                ExpectedElements = Generate("0 2 3 6 7")
            };

            yield return new AddScenario
            {
                Initial = Generate("0 2 3 3 3"),
                ItemsToAdd = Generate("6 7 3"),
                ExpectedElements = Generate("0 2 3 3 3 6 7 3")
            };

            yield return new AddScenario
            {
                ItemsToAdd = Generate(100),
                ExpectedElements = Generate(100)
            };
        }
    }
}
