using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicFrequencyWords
{
    public sealed class FrequencyWords
    {
        #region Public Methods GetFrequencyAllWords | GetFrequencyWord

        /// <summary>
        /// Method GetFrequencyAllWords get frequency of entries of words.
        /// </summary>
        /// <param name="filePath">Path to file with text.</param>
        /// <returns>Return txt file with frequency of entries of words.</returns>
        public static void GetFrequencyAllWords(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(nameof(filePath));

            Dictionary<string, int> frequency = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            string text = File.ReadAllText(filePath, Encoding.Default);
            
            string result = String.Empty;

            GetFullDictionary(ref frequency, text);

            result = GetFrequencyString(frequency);

            File.WriteAllText("Frequency.txt", result, Encoding.Default);
        }

        /// <summary>
        /// Method GetFrequencyWord get frequency of entries of word.
        /// </summary>
        /// <param name="filePath">Path to file with text.</param>
        /// <param name="findWord">Search word.</param>
        /// <returns>Return frequency of entries of word.</returns>
        public static string GetFrequencyWord(string filePath, string findWord)
        {
            int count = 0;
            int countWords = 0;
            double frequency = 0;

            string text = File.ReadAllText(filePath, Encoding.Default);

            GetCountWord(text, findWord, ref count, ref countWords);

            frequency = (double)count / countWords;
            string result = $"{frequency:P}";

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method GetFullDictionary writes dictionary with words ant its quantity. 
        /// </summary>
        /// <param name="frequency">Dictionary with key word and value quantity word.</param>
        /// <param name="text">Text from file.</param>
        private static void GetFullDictionary(ref Dictionary<string, int> frequency, string text)
        {
            string[] words = { };
            char[] separators = { ' ', '/', '.', ',', '!', '?', '*', '-', '"', ')', '(', '\r', '\n', '"' };

            words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                throw new ArgumentNullException(nameof(text));

            for (int i = 0; i < words.Length; i++)
            {
                if (frequency.ContainsKey(words[i]))
                    frequency[words[i]]++;
                else
                    frequency.Add(words[i], 1);
            }
        }

        /// <summary>
        /// Method GetFrequencyString represents frequency for each word int text.
        /// </summary>
        /// <param name="frequency">Dictionary that contain word and its entries in text.</param>
        /// <param name="words">Array of words.</param>
        /// <returns>Frequency in string.</returns>
        private static string GetFrequencyString(Dictionary<string, int> frequency)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int numberOfWords = frequency.Values.Sum();

            stringBuilder.AppendLine(numberOfWords.ToString());

            string[] words = frequency.Keys.ToArray();
            
            for (int i = 0; i < frequency.Count; i++)
            {
                stringBuilder.AppendLine(words[i] + ' ' + $"{frequency[words[i]]} -> {(double)frequency[words[i]] / numberOfWords:P}");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Method GetCountWord finds numbers of entries a word in a string.Ref parameter.
        /// </summary>
        /// <param name="text">Current line of words.</param>
        /// <param name="findWord">Search word.</param>
        /// <param name="count">Numbers of search word in line. Ref parameter.</param>
        /// <param name="countWords">Numbers of all words in line. Ref parameter.</param>
        private static void GetCountWord(string text, string findWord, ref int count, ref int countWords)
        {
            char[] separators = { ' ', '/', '.', ',', '!', '?', '*', '-', '"', ')', '(', '\r', '\n', '"' };

            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                throw new ArgumentNullException(nameof(text));

            foreach (var word in words)
            {
                if (word == findWord)
                    count++;
                countWords++;
            }
        }

        #endregion
    }
}
