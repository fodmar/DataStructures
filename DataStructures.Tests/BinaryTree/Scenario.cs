using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryTree
{
    class Scenario : ScenarioBase
    {
        public string ExpectedPreOrder { get; set; }

        public string ExpectedInOrder { get; set; }

        public string ExpectedPostOrder { get; set; }

        public string ExpectedBreadthFirst { get; set; }
    }
}
