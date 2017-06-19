using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Collection
{
    class ContainsScenario : ScenarioBase
    {
        public TestItem ToFind { get; set; }

        public bool Expected { get; set; }
    }
}
