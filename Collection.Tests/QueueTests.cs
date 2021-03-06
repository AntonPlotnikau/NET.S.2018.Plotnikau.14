﻿using Collections;
using NUnit.Framework;

namespace Collection.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        [TestCase(232, 43243, 324, 3, 43, 2, 5, 3, ExpectedResult = 43243)]
        [TestCase(1, 43, 434, 34, 4234, 32, 565, 765, 5543, ExpectedResult = 43)]
        public int DequeueTestsWithInt(params int[] values)
        {
            Queue<int> queue = new Queue<int>(values);
            queue.Dequeue();
            return queue.Dequeue();
        }

        [Test]
        [TestCase(232, 43243, 324, 3, 43, 2, 5, 3)]
        [TestCase(1, 43, 434, 34, 4234, 32, 565, 765, 5543)]
        public void GetEnumeratorTests(params int[] values)
        {
            var queue = new Queue<int>(values);

            int i = -1;
            foreach (var item in queue)
            {
                Assert.AreEqual(item, values[++i]);
            }
        }
    }
}
