using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.Scenarios.Collection
{
    class ContainsPerformanceScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new ContainsPerformanceScenario
            {
                ToFind = this.GenerateRandom(5000),
                Initial = this.GenerateRandom(3 * 5000)
            };
        }
    }
}
