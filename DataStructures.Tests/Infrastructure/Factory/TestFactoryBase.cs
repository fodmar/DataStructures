using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.Infrastructure.Factory
{
    abstract class TestFactoryBase
    {
        private ConstructorPair[] constructors;

        public TestFactoryBase(ConstructorPair[] constructors)
        {
            this.constructors = constructors;
        }

        protected IEnumerable<ScenarioBase> CreateScenarios(ScenarioGeneratorBase generator)
        {
            IEnumerable<ScenarioBase> scenarios = generator.Generate();

            foreach (var constructor in constructors)
            {
                foreach (var scenario in scenarios)
                {
                    if (scenario.Initial == null)
                    {
                        scenario.List = constructor.WithoutInitial();
                    }
                    else
                    {
                        scenario.List = constructor.WithInitial(scenario.Initial);
                    }

                    yield return scenario;
                }
            }
        }
    }
}
