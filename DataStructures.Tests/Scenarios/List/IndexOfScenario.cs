using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class IndexOfScenario : ScenarioBase
    {
        public TestItem ToFind { get; set; }

        public int ExpectedIndex { get; set; }
    }
}
