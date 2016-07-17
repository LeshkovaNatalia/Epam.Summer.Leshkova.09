using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicGenericBinarySearch
{
    public sealed class GenericBinarySearch
    {
        #region Public method

        /// <summary>
        /// Method BinarySearch of generic type is searches an one-dimensional sorted array for a value
        /// using the IComparer of genetic type.
        /// </summary>
        /// <typeparam name="T">T is type of elements.</typeparam>
        /// <param name="array">The sorted one-dimensional array of elements.</param>
        /// <param name="element">The object to search for.</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.</param>
        /// <returns>Returns the index of the specified value in the specified array.</returns>
        public static int BinarySearch<T>(T[] array, T element, IComparer<T> comparer)
        {
            if(array.Length == 0)
                throw new ArgumentNullException(nameof(array));

            int left = 0;
            int right = array.Length;
            int middle = left + (right - left) / 2;

            while (left <= right)
            {
                if (array[middle].Equals(element))
                    return middle;

                if (comparer.Compare(array[middle], element) > 0)
                    right = middle;
                else
                    left = middle + 1;

                middle = left + (right - left) / 2;
            }

            return -1;
        }

        #endregion
    }
}
