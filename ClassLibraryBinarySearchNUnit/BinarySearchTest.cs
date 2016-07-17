using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicGenericBinarySearch;
using NUnit.Framework;

namespace ClassLibraryBinarySearchNUnit
{
    [TestFixture]
    public class BinarySearchTest
    {
        private IEnumerable<TestCaseData> InputData
        {
            get
            {
                yield return new TestCaseData(new int [] {}, 12, -1).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new [] { 4, 6, 9, 12, 15 }, 12, 3);
            }
        }

        [Test, TestCaseSource("InputData")]
        public void BinarySearchTest_SearchInInt12_Return3(int[] array, int value, int expected)
        {
            int actual = GenericBinarySearch.BinarySearch(array, value, new DefaultComparer<int>());

            Assert.AreEqual(expected, actual, " != ", expected, actual);
        }

        [Test]
        public void BinarySearchTest_SearchInStringHi_Return2()
        {
            string[] strings = { "Abc", "Dif", "Hi", "Klm", "Opq", "Rst"};

            int expected = 2;

            int actual = GenericBinarySearch.BinarySearch(strings, "Hi", new DefaultComparer<string>());

            Assert.AreEqual(expected, actual, " != ", expected, actual);
        }

        [Test, TestCase(new[] { 15, 12, 8, 9, 6, 4, 3, 2 }, 12, 1)]
        public void BinarySearchReverseTest_SearchInInt12_Return1(int[] array, int value, int expected)
        {
            int actual = GenericBinarySearch.BinarySearch(array, value, new ReverseComparer<int>());

            Assert.AreEqual(expected, actual, " != ", expected, actual);
        }
    }
}
