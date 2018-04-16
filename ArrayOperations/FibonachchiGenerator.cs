using System;
using System.Collections.Generic;
using System.Numerics;

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
        /// <returns>
        /// numerical series
        /// </returns>
        /// <exception cref="ArgumentException">length Of numerical is less than two</exception>
        public static IEnumerable<BigInteger> GenerateFibonachchi(int lengthOfNumerical)
        {
            if (lengthOfNumerical < 2)
            {
                throw new ArgumentException(nameof(lengthOfNumerical) + "must be equal or more than two");
            }

            BigInteger value = 1;
            BigInteger result = 0;

            for (int i = 1; i <= lengthOfNumerical; i++) 
            {
                BigInteger temp = result;
                result += value;
                yield return result;
                value = temp;
            }
        }
    }
}
