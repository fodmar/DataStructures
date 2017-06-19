using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Scenarios.Enumerable;

namespace DataStructures.Tests.Infrastructure.Factory
{
    class EnumerableTestFactory : TestFactoryBase
    {
        public EnumerableTestFactory() : base(DataStructuresFactory.GetEnumerables())
        {
        }

        public IEnumerable<ScenarioBase> Foreach()
        {
            return CreateScenarios(new ForeachScenarioGenerator());
        }
    }
}
