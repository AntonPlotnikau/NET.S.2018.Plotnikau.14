using System;
using System.Collections.Generic;
using System.Numerics;
using ArrayOperations;
using NUnit.Framework;

namespace ArrayOperations.Tests
{
    [TestFixture]
    public class FibonachchiGeneratorTests
    {
        [Test]
        [TestCase(10, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55)]
        [TestCase(15, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610)]
        public void GenerateFibonachchiTests(int length, params int[] source)
        {
            BigInteger[] array = new BigInteger[source.Length];
            for (int i = 0; i < source.Length; i++) 
            {
                array[i] = source[i];
            }

            IEnumerable<BigInteger> expected=array;
            IEnumerable<BigInteger> actual = FibonachchiGenerator.GenerateFibonachchi(length);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
