using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Infrastructure.Factory;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryHeap
{
    class TestFactory : TestFactoryBase
    {
        public TestFactory() : base(DataStructuresFactory.GetBinaryHeaps())
        {
        }

        public IEnumerable<ScenarioBase> Pop()
        {
            return this.CreateScenarios(new PopScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> Add()
        {
            return this.CreateScenarios(new AddScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> Remove()
        {
            return this.CreateScenarios(new RemoveScenarioGenerator());
        }
    }
}
