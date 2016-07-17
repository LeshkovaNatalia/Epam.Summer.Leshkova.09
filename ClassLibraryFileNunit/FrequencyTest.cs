using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicFrequencyWords;
using NUnit.Framework;

namespace ClassLibraryFrequencyWordsNunit
{
    [TestFixture]
    public class FrequencyTest
    {
        private readonly string FilePath = "Test.txt";

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileTest_ContainWord_ReturnException()
        {
            FrequencyWords.GetFrequencyWord("NotExist.txt", "IL");
        }

        [Test]
        public void FileTest_ContainWord_ReturnFrequency()
        {
            FrequencyWords.GetFrequencyAllWords(FilePath);
        }

        [Test]
        public void FileTest_ContainWordCLR_ReturnFrequency()
        {
            string expexted = "0,70%";

            string actual = FrequencyWords.GetFrequencyWord(FilePath, "CLR");

            Assert.AreEqual(expexted, actual, expexted, " != ", actual);
        }

        [Test]
        public void FileTest_ContainWord_Return0()
        {
            string expexted = "0,00%";

            string actual = FrequencyWords.GetFrequencyWord(FilePath, "Hi");

            Assert.AreEqual(expexted, actual, expexted, " != ", actual);
        }
    }
}
