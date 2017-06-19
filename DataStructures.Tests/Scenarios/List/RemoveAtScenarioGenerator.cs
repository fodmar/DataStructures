using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class RemoveAtScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            TestItem[] five = Generate(5);

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = 0,
                ExpectedElements = Generate("1 2 3 4")
            };

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = 4,
                ExpectedElements = Generate("0 1 2 3")
            };

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = 1,
                ExpectedElements = Generate("0 2 3 4")
            };

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = 3,
                ExpectedElements = Generate("0 1 2 4")
            };

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = -1,
                ExpectedElements = Generate("0 1 2 3 4"),
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = 5,
                ExpectedElements = Generate("0 1 2 3 4"),
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new RemoveAtScenario
            {
                Initial = five,
                ToRemove = 6,
                ExpectedElements = Generate("0 1 2 3 4"),
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };
        }
    }
}
