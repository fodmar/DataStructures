using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class InsertScenario : ScenarioBase
    {
        public KeyValuePair<int, TestItem>[] ToInsert { get; set; }

        public TestItem[] ExpectedElements { get; set; }

        public Type ExpectedExceptionType { get; set; }
    }
}
