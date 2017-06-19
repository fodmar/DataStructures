using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Stack
{
    class Scenario : ScenarioBase
    {
        public TestItem[] ToPop { get; set; }

        public TestItem[] Pushed { get; set; }

        public TestItem[] Expected { get; set; }
    }
}
