using NUnit.Framework;
using ArrayOperations;

namespace ArrayOperations.Tests
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4, ExpectedResult = 3)]
        [TestCase(new int[] { 10, 140, 208, 329, 428, 512, 690, 770, 800 }, 428, ExpectedResult = 4)]
        [TestCase(new int[] { 10, 140, 208, 329, 428, 512, 690, 770, 800 }, 1000, ExpectedResult = -1)]
        public int BinarySearchTestsWithInt(int[] array, int key)
            => Search.BinarySearch<int>(array, key, new IntComparer());

        [Test]
        [TestCase(new string[] { "AAA", "BdA", "CrT", "Zrt"}, "CrT", ExpectedResult = 2)]
        public int BinarySearchTestsWithString(string[] array, string key)
            => Search.BinarySearch<string>(array, key, new StringComparer());
    }
}
