using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class IndexerScenario : ScenarioBase
    {
        public int Index { get; set; }

        public Type ExpectedExceptionType{ get; set; }

        public TestItem ExceptedItem { get; set; }
    }
}
