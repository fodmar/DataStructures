using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Queue
{
    class ScenarioGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new Scenario
            {
                Initial = Generate("6 4 2 3"),
                ToEnqueue = Generate("1 2 3"),
                Dequeued = Generate("6 4 2 3 1"),
                Expected = Generate("2 3")
            };

            yield return new Scenario
            {
                ToEnqueue = Generate("1 2 3 4 5 6"),
                Dequeued = Generate("1 2"),
                Expected = Generate("3 4 5 6")
            };

            yield return new Scenario
            {
                ToEnqueue = Generate(100),
                Dequeued = Generate(90),
                Expected = Generate("90 91 92 93 94 95 96 97 98 99")
            };
        }
    }
}
