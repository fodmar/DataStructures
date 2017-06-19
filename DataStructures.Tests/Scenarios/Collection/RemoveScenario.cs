using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Collection
{
    class RemoveScenario : ScenarioBase
    {
        public TestItem ToRemove { get; set; }

        public bool ExpectedRemoved { get; set; }

        public TestItem[] ExpectedElements { get; set; }
    }
}
