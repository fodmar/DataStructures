using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Scenarios.Collection;

namespace DataStructures.Tests.Infrastructure.Factory
{
    class CollectionTestFactory : TestFactoryBase
    {
        public CollectionTestFactory() : base(DataStructuresFactory.GetCollections())
        {
        }

        public IEnumerable<ScenarioBase> Add()
        {
            return CreateScenarios(new AddScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> AddPerformance()
        {
            return CreateScenarios(new AddPerformanceScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> Remove()
        {
            return CreateScenarios(new RemoveScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> RemovePerformance()
        {
            return CreateScenarios(new RemovePerformanceScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> Contains()
        {
            return CreateScenarios(new ContainsScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> ContainsPerformance()
        {
            return CreateScenarios(new ContainsPerformanceScenarioGenerator());
        }
    }
}
