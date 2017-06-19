using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryHeap
{
    class PopScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new PopScenario
            {
                Initial = this.Generate("2 3 4 5 100"),
                PopResult = this.Generate("100 5 4"),
                Expected = this.Generate("2 3")
            };

            yield return new PopScenario
            {
                Initial = this.Generate("2 3 100 4 5 100 0"),
                PopResult = this.Generate("100 100 5 4"),
                Expected = this.Generate("2 3 0")
            };
        }
    }
}
