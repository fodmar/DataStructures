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

            yield return new RemoveScenario
            {
                Initial = Generate("55"),
                ToRemove = GenerateOne(55),
                ExpectedElements = new TestItem[0],
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("55 33"),
                ToRemove = GenerateOne(55),
                ExpectedElements = Generate("33"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("55 33"),
                ToRemove = GenerateOne(33),
                ExpectedElements = Generate("55"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("55 77"),
                ToRemove = GenerateOne(55),
                ExpectedElements = Generate("77"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("55 77 33"),
                ToRemove = GenerateOne(55),
                ExpectedElements = Generate("77 33"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("4 3 1 2 5 6 7"),
                ToRemove = GenerateOne(5),
                ExpectedElements = Generate("4 3 1 2 6 7"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("4 3 1 2 5 6 7"),
                ToRemove = GenerateOne(4),
                ExpectedElements = Generate("5 3 1 2 6 7"),
                ExpectedRemoved = true
            };

            yield return new RemoveScenario
            {
                Initial = Generate("4 3 1 2 5 6 7"),
                ToRemove = GenerateOne(10),
                ExpectedElements = Generate("4 3 1 2 5 6 7"),
                ExpectedRemoved = false
            };
        }
    }
}
