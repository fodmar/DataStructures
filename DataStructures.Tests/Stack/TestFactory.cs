using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Stack
{
    class TestFactory : TestFactoryBase
    {
        public TestFactory() : base(DataStructuresFactory.GetStacks())
        {
        }

        public IEnumerable<ScenarioBase> Stack()
        {
            return this.CreateScenarios(new ScenarioGenerator());
        }
    }
}
