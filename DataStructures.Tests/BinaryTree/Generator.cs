using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;

namespace DataStructures.Tests.BinaryTree
{
    class Generator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new Scenario
            {
                List = new BinaryTree<TestItem>(),
                ExpectedPreOrder = string.Empty,
                ExpectedInOrder = string.Empty,
                ExpectedPostOrder = string.Empty,
                ExpectedBreadthFirst = string.Empty
            };

            TestItem[] testItems = this.Generate("10 8 12 6 2 7 13 11 22 9");
            BinaryTree<TestItem> tree = new BinaryTree<TestItem>(testItems);

            yield return new Scenario
            {
                List = tree,
                ExpectedPreOrder = "10 8 6 2 7 9 12 11 13 22 ",
                ExpectedInOrder = "2 6 7 8 9 10 11 12 13 22 ",
                ExpectedPostOrder = "2 7 6 9 8 11 22 13 12 10 ",
                ExpectedBreadthFirst = "10 8 12 6 9 11 13 2 7 22 "
            };
        }
    }
}
