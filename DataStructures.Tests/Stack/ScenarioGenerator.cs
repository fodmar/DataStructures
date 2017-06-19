using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Stack
{
    class ScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new Scenario
            {
                Initial = Generate("6 4 2 3"),
                Pushed = Generate("1 2 3"),
                ToPop = Generate("3 2 1 3 2"),
                Expected = Generate("6 4")
            };

            yield return new Scenario
            {
                Pushed = Generate("1 2 3 4 5 6"),
                ToPop = Generate("6 5"),
                Expected = Generate("1 2 3 4")
            };
        }
    }
}
