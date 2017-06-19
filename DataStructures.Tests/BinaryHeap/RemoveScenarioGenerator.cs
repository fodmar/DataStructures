using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryHeap
{
    class RemoveScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new RemoveScenario
            {
                Initial = this.Generate("2 3 4 5 100"),
                ToRemove = this.Generate("2 3 5"),
                PopResult = this.Generate("100 100 100"),
                Expected = this.Generate("100 4")
            };

            yield return new RemoveScenario
            {
                Initial = this.Generate("2 3 4 5 100"),
                ToRemove = this.Generate("2 100 5"),
                PopResult = this.Generate("100 5 4"),
                Expected = this.Generate("4 3")
            };
        }
    }
}
