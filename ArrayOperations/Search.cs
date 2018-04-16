using System;
using System.Collections.Generic;

namespace ArrayOperations
{
    /// <summary>
    /// Search in the array
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T">type of array elements</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// index of element that was found
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// array is null
        /// or
        /// comparer is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">array length is less than 1</exception>
        public static int BinarySearch<T>(T[] array, T key, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            return BinarySearch(array, key, 0, array.Length - 1, comparer.Compare);
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T">type of array elements</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <param name="comparison">The comparison delegate.</param>
        /// <returns>
        /// index of element that was found
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// array is null
        /// or
        /// comparison is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">array length is less than 1</exception>
        public static int BinarySearch<T>(T[] array, T key, Comparison<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            return BinarySearch(array, key, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T">type of array elements</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <param name="left">The left border.</param>
        /// <param name="right">The right border.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns>
        /// index of element that was found
        /// </returns>
        private static int BinarySearch<T>(T[] array, T key, int left, int right, Comparison<T> comparison)
        {
            if (right < left)
            {
                return -1;
            }

            int middle = left + ((right - left) / 2);

            if (comparison(array[middle], key) < 0) 
            {
                return BinarySearch(array, key, middle + 1, right, comparison);
            }

            if (comparison(array[middle], key) > 0) 
            {
                return BinarySearch(array, key, left, middle - 1, comparison);
            }

            return middle;
        }
    }
}
