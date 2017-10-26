using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests
{
    class TestsClass
    {
        public static IEnumerable<ScenarioBase> Prepare(IEnumerable<ConstructorPair> constructors, ScenarioGeneratorBase generator)
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

        protected void SaveResultsToFile(Type collectionType, string fileName, int elements, long miliseconds)
        {
            using (StreamWriter streamWriter = File.AppendText(string.Format("_{0}{1}", fileName, collectionType.Name)))
            {
                streamWriter.WriteLine(string.Format("{0} {1}", elements, miliseconds));
            }
        }
    }
}
