using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class RemoveAtScenario : ScenarioBase
    {
        public int ToRemove { get; set; }

        public TestItem[] ExpectedElements { get; set; }

        public Type ExpectedExceptionType { get; set; }
    }
}
