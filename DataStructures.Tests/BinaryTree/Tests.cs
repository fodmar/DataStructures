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

            string result = string.Empty;

            foreach (var item in tree)
            {
                result += item.StringValue + " ";
            }

            Assert.AreEqual(scenario.ExpectedPreOrder, result);

            result = string.Empty;

            foreach (var item in tree.InOrder())
            {
                result += item.StringValue + " ";
            }

            Assert.AreEqual(scenario.ExpectedInOrder, result);

            result = string.Empty;

            foreach (var item in tree.PostOrder())
            {
                result += item.StringValue + " ";
            }

            Assert.AreEqual(scenario.ExpectedPostOrder, result);

            result = string.Empty;

            foreach (var item in tree.BreadthFirst())
            {
                result += item.StringValue + " ";
            }

            Assert.AreEqual(scenario.ExpectedBreadthFirst, result);
        }

    }
}
