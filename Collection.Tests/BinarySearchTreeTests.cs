using System;
using System.Collections.Generic;
using Collections;
using NUnit.Framework;

namespace Collection.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]       
        [TestCase(19,13,3,17,15,18,33,31,35)]
        public void PreOrderTestWithIntWithDefaultComparer(params int[] source)
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>();
            actual.Insert(source);
            int[] expected = { 19, 13, 3, 17, 15, 18, 33, 31, 35 };

            int i = -1;
            foreach(int value in actual.PreOrder())
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase(19, 13, 3, 17, 15, 18, 33, 31, 35)]
        public void InOrderTestWithIntWithDefaultComparer(params int[] source)
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>();
            actual.Insert(source);
            int[] expected = { 3, 13, 15, 17, 18, 19, 31, 33, 35 };

            int i = -1;
            foreach (int value in actual)
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase(19, 13, 3, 17, 15, 18, 33, 31, 35)]
        public void PostOrderTestWithIntWithDefaultComparer(params int[] source)
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>();
            actual.Insert(source);
            int[] expected = { 3, 15, 18, 17, 13, 31, 35, 33, 19 };

            int i = -1;
            foreach (int value in actual.PostOrder())
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase(19, 13, 3, 17, 15, 18, 33, 31, 35)]
        public void PreOrderTestWithIntWithComparer(params int[] source)
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>(new IntComparer());
            actual.Insert(source);
            int[] expected = { 19, 33, 35, 31, 13, 17, 18, 15, 3 };

            int i = -1;
            foreach (int value in actual.PreOrder())
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase(19, 13, 3, 17, 15, 18, 33, 31, 35)]
        public void InOrderTestWithIntWithComparer(params int[] source)
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>(new IntComparer());
            actual.Insert(source);
            int[] expected = { 3, 13, 15, 17, 18, 19, 31, 33, 35 };
            Array.Reverse(expected);

            int i = -1;
            foreach (int value in actual)
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase(19, 13, 3, 17, 15, 18, 33, 31, 35)]
        public void PostOrderTestWithIntWithComparer(params int[] source)
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>(new IntComparer());
            actual.Insert(source);
            int[] expected = { 35, 31, 33, 18, 15, 17, 3, 13, 19 };

            int i = -1;
            foreach (int value in actual.PostOrder())
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase("F", "B", "A", "D", "C", "E", "G", "I", "H")]
        public void PreOrderTestWithStringWithDefaultComparer(params string[] source)
        {
            BinarySearchTree<string> actual = new BinarySearchTree<string>();
            actual.Insert(source);
            string[] expected = { "F", "B", "A", "D", "C", "E", "G", "I", "H" };

            int i = -1;
            foreach (string value in actual.PreOrder())
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase("F", "B", "A", "D", "C", "E", "G", "I", "H")]
        public void InOrderTestWithStringWithComparer(params string[] source)
        {
            BinarySearchTree<string> actual = new BinarySearchTree<string>(new StringComparer());
            actual.Insert(source);
            string[] expected = { "F", "B", "A", "D", "C", "E", "G", "I", "H" };
            Array.Sort(expected);
            Array.Reverse(expected);

            int i = -1;
            foreach (string value in actual)
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        [TestCase(19, 13, 3, 17, 15, 18, 33, 31)]
        public void InOrderTestWithPointWithComparer(params int[] source)
        {
            BinarySearchTree<Point> actual = new BinarySearchTree<Point>(new PointComparer());
            Point[] array = new Point[source.Length / 2];
            for (int j = 0, k = 0; j < array.Length; j++, k += 2) 
            {
                array[j] = new Point(source[k], source[k + 1]);
            }

            actual.Insert(array);
            Point[] expected = { new Point(3, 17), new Point(15, 18), new Point(19, 13),  new Point(33, 31) };

            int i = -1;
            foreach (Point value in actual)
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        public void InOrderTestWithBookWithDefaultComparer()
        {
            BinarySearchTree<Book> actual = new BinarySearchTree<Book>();
            Book[] array = new Book[4];
            array[0] = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            array[1] = new Book("978-0-7356-6745-7", "Troelsen", "For beginners", "Microsoft Press", 2010, 813, 9.99);
            array[2] = new Book("568-0-7546-6555-4", "Anton Pypkin", "C#", "Playboy", 2005, 666, 100);
            array[3] = new Book("242-1-7766-3215-5", "Блинов", "Java SE", "Четыре четверти", 2013, 896, 3.5);

            actual.Insert(array);
            Book[] expected = { new Book("242-1-7766-3215-5", "Блинов", "Java SE", "Четыре четверти", 2013, 896, 3.5),
                                new Book("978-0-7356-6745-7", "Troelsen", "For beginners", "Microsoft Press", 2010, 813, 9.99),
                                new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99),
                                new Book("568-0-7546-6555-4", "Anton Pypkin", "C#", "Playboy", 2005, 666, 100) };
            Array.Reverse(expected);

            int i = -1;
            foreach (Book value in actual)
            {
                Assert.AreEqual(expected[++i], value);
            }
        }

        [Test]
        public void InOrderTestWithBookWithComparer()
        {
            BinarySearchTree<Book> actual = new BinarySearchTree<Book>(new BookComparer());
            Book[] array = new Book[4];
            array[0] = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            array[1] = new Book("978-0-7356-6745-7", "Troelsen", "For beginners", "Microsoft Press", 2010, 813, 9.99);
            array[2] = new Book("568-0-7546-6555-4", "Anton Pypkin", "C#", "Playboy", 2005, 666, 100);
            array[3] = new Book("242-1-7766-3215-5", "Блинов", "Java SE", "Четыре четверти", 2013, 896, 3.5);

            actual.Insert(array);
            Book[] expected = { new Book("242-1-7766-3215-5", "Блинов", "Java SE", "Четыре четверти", 2013, 896, 3.5),
                                new Book("978-0-7356-6745-7", "Troelsen", "For beginners", "Microsoft Press", 2010, 813, 9.99),
                                new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99),
                                new Book("568-0-7546-6555-4", "Anton Pypkin", "C#", "Playboy", 2005, 666, 100) };

            int i = -1;
            foreach (Book value in actual)
            {
                Assert.AreEqual(expected[++i], value);
            }
        }
    }
}
