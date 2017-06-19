using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Queue
{
    class TestFactory : TestFactoryBase
    {
        public TestFactory() : base(DataStructuresFactory.GetQueues())
        {
        }

        public IEnumerable<ScenarioBase> Queue()
        {
            return this.CreateScenarios(new ScenarioGenerator());
        } 
    }
}
