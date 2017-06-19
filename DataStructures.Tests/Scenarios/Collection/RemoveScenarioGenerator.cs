using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Collection
{
    class RemoveScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            TestItem[] five = Generate(5);

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(0),
                ExpectedElements = Generate("1 2 3 4"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(4),
                ExpectedElements = Generate("0 1 2 3"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(1),
                ExpectedElements = Generate("0 2 3 4"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(3),
                ExpectedElements = Generate("0 1 2 4"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(8),
                ExpectedElements = Generate("0 1 2 3 4"),
                ExpectedRemoved = false
            };

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(5),
                ExpectedElements = Generate("0 1 2 3 4"),
                ExpectedRemoved = false
            };

            yield return new RemoveScenario
            {
                Initial = five,
                ToRemove = GenerateOne(-1),
                ExpectedElements = Generate("0 1 2 3 4"),
                ExpectedRemoved = false
            };
        }
    }
}
