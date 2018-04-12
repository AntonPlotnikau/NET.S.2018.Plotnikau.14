using System;

namespace ArrayOperations
{
    /// <summary>
    /// Fibonachchi number series generator.
    /// </summary>
    public static class FibonachchiGenerator
    {
        /// <summary>
        /// Generates the Fibonachchi number series.
        /// </summary>
        /// <param name="lengthOfNumerical">The length of numerical series.</param>
        /// <returns>array that represents numerical series</returns>
        /// <exception cref="ArgumentException">length Of numerical is less than two</exception>
        public static int[] GenerateFibonachchi(int lengthOfNumerical)
        {
            if (lengthOfNumerical < 2)
            {
                throw new ArgumentException(nameof(lengthOfNumerical) + "must be equal or more than two");
            }

            int[] array = new int[lengthOfNumerical];
            array[0] = 1;
            array[1] = 1;

            for (int i = 2; i < lengthOfNumerical; i++) 
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array;
        }
    }
}
