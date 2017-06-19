using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures;

namespace DataStructures.Tests.Scenarios
{
    class ScenarioBase
    {
        public IMyEnumerable<TestItem> List { get; set; }

        public TestItem[] Initial { get; set; }
    }
}
