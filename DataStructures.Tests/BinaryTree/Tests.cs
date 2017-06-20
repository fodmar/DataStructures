using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Infrastructure;
using DataStructures.Tests.Scenarios;
using NUnit.Framework;

namespace DataStructures.Tests.BinaryTree
{
    [TestFixture]
    class Tests
    {
        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(Generator), "Generate")]
        public void Traversal(Scenario scenario)
        {
            BinaryTree<TestItem> tree = (BinaryTree<TestItem>)scenario.List;
            string enumeratorResult = string.Empty;
            string inOrderResult = string.Empty;
            string postOrderResult = string.Empty;
            string breadthFirstResult = string.Empty;

            foreach (var item in tree)
            {
                enumeratorResult += item.StringValue + " ";
            }

            foreach (var item in tree.InOrder())
            {
                inOrderResult += item.StringValue + " ";
            }

            foreach (var item in tree.PostOrder())
            {
                postOrderResult += item.StringValue + " ";
            }

            foreach (var item in tree.BreadthFirst())
            {
                breadthFirstResult += item.StringValue + " ";
            }

            Assert.AreEqual(scenario.ExpectedPreOrder, enumeratorResult);
            Assert.AreEqual(scenario.ExpectedInOrder, inOrderResult);
            Assert.AreEqual(scenario.ExpectedPostOrder, postOrderResult);
            Assert.AreEqual(scenario.ExpectedBreadthFirst, breadthFirstResult);
        }

        [Test]
        [Timeout(1000)]
        [TestCaseSource(typeof(MinMaxGenerator), "Generate")]
        public void MinMax(MinMaxScenario scenario)
        {
            var tree = new BinaryTree<TestItem>(scenario.Initial);

            Assert.AreEqual(scenario.ExpectedMin, tree.Min());
            Assert.AreEqual(scenario.ExpectedMax, tree.Max());
        }
    }
}
