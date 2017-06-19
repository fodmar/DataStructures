using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using DataStructures.Tests.Scenarios.List;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Infrastructure.Factory
{
    class ListTestFactory : TestFactoryBase
    {
        public ListTestFactory() : base(DataStructuresFactory.GetLists())
        {
        }

        public IEnumerable<ScenarioBase> IndexerGet()
        {
            return CreateScenarios(new IndexerScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> IndexOf()
        {
            return CreateScenarios(new IndexOfScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> RemoveAt()
        {
            return CreateScenarios(new RemoveAtScenarioGenerator());
        }

        public IEnumerable<ScenarioBase> Insert()
        {
            return CreateScenarios(new InsertTestGenerator());
        }
    }
}
