using System;
using ArrayOperations;
using NUnit.Framework;

namespace ArrayOperations.Tests
{
    [TestFixture]
    public class FibonachchiGeneratorTests
    {
        [Test]
        [TestCase(10, new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(15, new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 })]
        public void GenerateFibonachchiTests(int length, int[] expected)
        {
            int[] actual = FibonachchiGenerator.GenerateFibonachchi(length);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
