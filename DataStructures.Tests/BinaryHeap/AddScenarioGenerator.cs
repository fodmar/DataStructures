using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryHeap
{
    class AddScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new AddScenario
            {
                Initial = this.Generate("2 3 4 5 100"),
                ToAdd = this.Generate("0 0 0 200 5 199"),
                PopResult = this.Generate("100 100 100 200 200 200"),
                Expected = this.Generate("2 3 4 5 100 0 0 0 200 5 199")
            };

            yield return new AddScenario
            {
                ToAdd = this.Generate("0 0 0 200 5 199"),
                PopResult = this.Generate("0 0 0 200 200 200"),
                Expected = this.Generate("0 0 0 200 5 199")
            };
        }
    }
}
