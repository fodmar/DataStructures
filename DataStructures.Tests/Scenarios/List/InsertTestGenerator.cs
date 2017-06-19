using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tests.Scenarios;
using DataStructures.Tests.Infrastructure;

namespace DataStructures.Tests.Scenarios.List
{
    class InsertTestGenerator : ScenarioGeneratorBase
    {
        public override IEnumerable<ScenarioBase> Generate()
        {
            yield return new InsertScenario
            {
                ToInsert = GeneratePairs(GeneratePair(0, 5)),
                ExpectedElements = Generate("5")
            };

            yield return new InsertScenario
            {
                ExpectedElements = Generate("2 1"),
                ToInsert = GeneratePairs(
                    GeneratePair(0, 1),
                    GeneratePair(0, 2))
            };

            yield return new InsertScenario
            {
                ExpectedElements = Generate("1 2"),
                ToInsert = GeneratePairs(
                    GeneratePair(0, 1),
                    GeneratePair(1, 2))
            };

            yield return new InsertScenario
            {
                ExpectedElements = Generate("1 2"),
                ToInsert = GeneratePairs(
                    GeneratePair(0, 1),
                    GeneratePair(1, 2),
                    GeneratePair(3, 2)),
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new InsertScenario
            {
                ExpectedElements = Generate("3 1 2"),
                ToInsert = GeneratePairs(
                    GeneratePair(0, 1),
                    GeneratePair(1, 2),
                    GeneratePair(0, 3)),
                ExpectedExceptionType = typeof(ArgumentOutOfRangeException)
            };

            yield return new InsertScenario
            {
                Initial = Generate("0 0 0 0"),
                ExpectedElements = Generate("0 0 3 1 2 0 0"),
                ToInsert = GeneratePairs(
                    GeneratePair(2, 3),
                    GeneratePair(3, 2),
                    GeneratePair(3, 1))
            };

            yield return new InsertScenario
            {
                Initial = Generate("0 6 0 6 0"),
                ExpectedElements = Generate("8 9 0 6 3 1 0 1 3 6 0 9 8"),
                ToInsert = GeneratePairs(
                    GeneratePair(0, 9),
                    GeneratePair(6, 9),
                    GeneratePair(3, 3),
                    GeneratePair(5, 3),
                    GeneratePair(0, 8),
                    GeneratePair(10, 8),
                    GeneratePair(5, 1),
                    GeneratePair(7, 1))
            };
        }

        private KeyValuePair<int, TestItem> GeneratePair(int index, int toGenerate)
        {
            return new KeyValuePair<int, TestItem>(index, GenerateOne(toGenerate));
        }

        private KeyValuePair<int, TestItem> GeneratePair(int index, TestItem item)
        {
            return new KeyValuePair<int, TestItem>(index, item);
        }

        private KeyValuePair<int, TestItem>[] GeneratePairs(params KeyValuePair<int, TestItem>[] array)
        {
            return array;
        }
    }
}
