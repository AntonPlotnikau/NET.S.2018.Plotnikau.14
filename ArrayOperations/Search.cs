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
        /// <returns>index of element that was found</returns>
        /// <exception cref="ArgumentNullException">
        /// array is null
        /// or
        /// comparer is null
        /// </exception>
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

            return BinarySearch(array, key, 0, array.Length - 1, comparer);
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T">type of array elements</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="key">The key.</param>
        /// <param name="left">The left border.</param>
        /// <param name="right">The right border.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>index of element that was found</returns>
        private static int BinarySearch<T>(T[] array, T key, int left, int right, IComparer<T> comparer)
        {
            if (right < left)
            {
                return -1;
            }

            int middle = left + ((right - left) / 2);

            if (comparer.Compare(array[middle], key) < 0) 
            {
                return BinarySearch(array, key, middle + 1, right, comparer);
            }

            if (comparer.Compare(array[middle], key) > 0) 
            {
                return BinarySearch(array, key, left, middle - 1, comparer);
            }

            return middle;
        }
    }
}
