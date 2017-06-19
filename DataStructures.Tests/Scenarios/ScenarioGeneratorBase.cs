using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios
{
    abstract class ScenarioGeneratorBase
    {
        public abstract IEnumerable<ScenarioBase> Generate();

        protected TestItem GenerateOne(int number)
        {
            return new TestItem
            {
                IntValue = number,
                StringValue = number.ToString()
            };
        }

        protected TestItem GenerateOne(string number)
        {
            return new TestItem
            {
                IntValue = int.Parse(number),
                StringValue = number
            };
        }

        protected TestItem[] Generate(int count)
        {
            TestItem[] items = new TestItem[count];

            for (int i = 0; i < count; i++)
            {
                items[i] = GenerateOne(i);
            }

            return items;
        }

        protected TestItem[] Generate(string sequence)
        {
            return sequence.Split(' ').Select(n => this.GenerateOne(n)).ToArray();
        }

        protected TestItem[] GenerateRandom(int count)
        {
            TestItem[] items = new TestItem[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                items[i] = GenerateOne(random.Next());
            }

            return items;
        }

        protected int[] Array(params int[] array)
        {
            return array;
        }
    }
}
