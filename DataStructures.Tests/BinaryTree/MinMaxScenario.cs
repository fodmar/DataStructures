using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryTree
{
    class MinMaxScenario : ScenarioBase
    {
        public TestItem ExpectedMin { get; set; }

        public TestItem ExpectedMax { get; set; }
    }
}
