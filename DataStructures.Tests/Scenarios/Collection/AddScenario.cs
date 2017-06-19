using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.Collection
{
    class AddScenario : ScenarioBase
    {
        public TestItem[] ItemsToAdd { get; set; }

        public TestItem[] ExpectedElements { get; set; }

        public string Description
        {
            get
            {
                return string.Format("Type: {0}, Initial count: {1}, Items to add: {2}",
                    List.GetType().Name,
                    Initial == null ? 0 : Initial.Length,
                    ItemsToAdd.Length);
            }
        }
    }
}
