using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryTree
{
    class MinMaxGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new MinMaxScenario
            {
                Initial = this.Generate("12 1 2 39 29 1 2 3 -1 0 0 2"),
                ExpectedMin = this.GenerateOne("-1"),
                ExpectedMax = this.GenerateOne("39"),
            };

            yield return new MinMaxScenario
            {
                Initial = this.Generate("1 2 3 4 5 6"),
                ExpectedMin = this.GenerateOne("1"),
                ExpectedMax = this.GenerateOne("6"),
            };

            yield return new MinMaxScenario
            {
                Initial = this.Generate("6 2 3 4 5 1"),
                ExpectedMin = this.GenerateOne("1"),
                ExpectedMax = this.GenerateOne("6"),
            };
        }
    }
}
