using System;
using System.Collections.Generic;

namespace ClassLibraryBinarySearchNUnit
{
    public class DefaultComparer<T> : IComparer<T> where T : IComparable
    {
        /// <summary>
        /// Method Compare compare elements in right order.
        /// </summary>
        /// <param name="x">First parameter of type T.</param>
        /// <param name="y">Second parameter of type T.</param>
        /// <returns>Return result of comparisons.</returns>
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }

    public class ReverseComparer<T> : IComparer<T> where T : IComparable
    {
        /// <summary>
        /// Method Compare compare elements in reverse order.
        /// </summary>
        /// <param name="x">First parameter of type T.</param>
        /// <param name="y">Second parameter of type T.</param>
        /// <returns>Return result of comparisons.</returns>
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
}

