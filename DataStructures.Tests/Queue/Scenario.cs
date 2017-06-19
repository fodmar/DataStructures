using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Queue
{
    class Scenario : ScenarioBase
    {
        public TestItem[] ToEnqueue { get; set; }

        public TestItem[] Dequeued { get; set; }

        public TestItem[] Expected { get; set; }
    }
}
