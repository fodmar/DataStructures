using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Enumerable
{
    class ForeachScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new ForeachScenario
            {
                Initial = Generate(10),
                ExpectedOutput = 45,
            };

            yield return new ForeachScenario
            {
                Initial = Generate("2 3 1 4 9 88 2 1 3 3 4 8 7 0 2 0 1 2"),
                ExpectedOutput = 140,
            };

            yield return new ForeachScenario
            {
                Initial = null,
                ExpectedOutput = 0,
            };

            yield return new ForeachScenario
            {
                Initial = new TestItem[0],
                ExpectedOutput = 0,
            };
        }
    }
}
