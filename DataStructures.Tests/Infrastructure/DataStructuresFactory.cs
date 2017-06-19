using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests.Infrastructure
{
    static class DataStructuresFactory
    {
        public static ConstructorPair[] GetLists()
        {
            return new ConstructorPair[]
            {
                new ConstructorPair
                {
                    WithoutInitial = () => new MyList<TestItem>(),
                    WithInitial = (initial) => new MyList<TestItem>(initial),
                },
                new ConstructorPair
                {
                    WithoutInitial = () => new DotNetList<TestItem>(),
                    WithInitial = (initial) => new DotNetList<TestItem>(initial),
                }
            };
        }

        public static ConstructorPair[] GetCollections()
        {
            var lists = GetLists();

            var collections = new ConstructorPair[]
            {
                new ConstructorPair
                {
                    WithoutInitial = () => new DotNetLinkedList<TestItem>(),
                    WithInitial = (initial) => new DotNetLinkedList<TestItem>(initial),
                },
                new ConstructorPair
                {
                    WithoutInitial = () => new MyLinkedList<TestItem>(),
                    WithInitial = (initial) => new MyLinkedList<TestItem>(initial),
                },
                new ConstructorPair
                {
                    WithoutInitial = () => new MyHashTable<TestItem>(),
                    WithInitial = (initial) => new MyHashTable<TestItem>(initial),
                },
                new ConstructorPair
                {
                    WithoutInitial = () => new MyBinaryHeap<TestItem>(),
                    WithInitial = (initial) => new MyBinaryHeap<TestItem>(initial),
                },
                new ConstructorPair
                {
                    WithoutInitial = () => new BinaryTree<TestItem>(),
                    WithInitial = (initial) => new BinaryTree<TestItem>(initial),
                },
            };

            return collections.Union(lists).ToArray();
        }

        public static ConstructorPair[] GetEnumerables()
        {
            var collections = GetCollections();

            var enumerables = new ConstructorPair[]
            {
                new ConstructorPair
                {
                    WithoutInitial = () => new MyStack<TestItem>(),
                    WithInitial = (initial) => new MyStack<TestItem>(initial),
                },
                new ConstructorPair
                {
                    WithoutInitial = () => new MyQueue<TestItem>(),
                    WithInitial = (initial) => new MyQueue<TestItem>(initial),
                },
            };

            return collections.Union(enumerables).ToArray();
        }

        public static ConstructorPair[] GetBinaryHeaps()
        {
            return new ConstructorPair[]
            {
                new ConstructorPair
                {
                    WithoutInitial = () => new MyBinaryHeap<TestItem>(),
                    WithInitial = (initial) => new MyBinaryHeap<TestItem>(initial),
                },
            };
        }

        public static ConstructorPair[] GetQueues()
        {
            return new ConstructorPair[]
            {
                new ConstructorPair
                {
                    WithoutInitial = () => new MyQueue<TestItem>(),
                    WithInitial = (initial) => new MyQueue<TestItem>(initial),
                },
            };
        }

        public static ConstructorPair[] GetStacks()
        {
            return new ConstructorPair[]
            {
                new ConstructorPair
                {
                    WithoutInitial = () => new MyStack<TestItem>(),
                    WithInitial = (initial) => new MyStack<TestItem>(initial),
                },
            };
        }
    }
}
