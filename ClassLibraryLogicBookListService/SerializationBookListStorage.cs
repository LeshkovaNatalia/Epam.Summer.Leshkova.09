using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicBooks;

namespace ClassLibraryLogicBookListService
{
    public class SerializationBookListStorage : IBookListStorage
    {

        #region Fields
        private string _fileName;
        #endregion

        #region Property

        public string FileName
        {
            get { return _fileName; }
            private set
            {
                if (value != null)
                    _fileName = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        #endregion

        #region Ctors

        public SerializationBookListStorage(){  }

        public SerializationBookListStorage(string fileName)
        {
            FileName = fileName;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method LoadBooks loads list of books using serialization from binary file.
        /// </summary>
        /// <returns>List of books.</returns>
        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            IFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.OpenRead(FileName))
            {
                books = (List<Book>)formatter.Deserialize(stream);
            }

            return books;
        }

        /// <summary>
        /// Method SaveBooks save list of books using serialization to binary file.
        /// </summary>
        /// <param name="books">List of books.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(FileName))
            {
                    formatter.Serialize(stream, books);
            }
        }

        #endregion
    }
}
