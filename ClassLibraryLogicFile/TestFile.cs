using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicFile
{
    public sealed class TextFile
    {
        public static long GetFrequencyWord(string filePath, string findWord)
        {
            long frequency = 0;

            int count = FindTextInFile(filePath, findWord);

            FileInfo fileInfo = new FileInfo(filePath);

            frequency = (findWord.Length * sizeof(char)) / fileInfo.Length;

            return frequency;
        }

        private static int FindTextInFile(string filePath, string findWord)
        {
            int count = 0;

            try
            {
                using (StreamReader streamReader = new StreamReader(filePath, System.Text.Encoding.Default))
                {
                    string line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Contains(findWord))
                            count++;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(nameof(filePath));
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(filePath));
            }

            return count;
        }
    }
}
