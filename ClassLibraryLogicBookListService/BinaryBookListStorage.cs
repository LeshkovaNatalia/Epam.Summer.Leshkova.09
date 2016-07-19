using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicBook;

namespace ClassLibraryLogicBookListService
{
    public class BinaryBookListStorage : IBookListStorage
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
                if(value != null)
                    _fileName = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }

        #endregion
        
        #region Ctors

        public BinaryBookListStorage(){ }

        public BinaryBookListStorage(string fileName)
        {
            _fileName = fileName;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method LoadBooks loads list of books from binary file.
        /// </summary>
        /// <returns>List of books.</returns>
        public List<Book> LoadBooks()
        {
            List<Book> listBooks = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                string title = string.Empty;
                string author = string.Empty;
                int pages = 0;
                int years = 0;

                while (reader.PeekChar() != -1)
                {
                    title = reader.ReadString();
                    author = reader.ReadString();
                    pages = reader.ReadInt32();
                    years = reader.ReadInt32();
                    listBooks.Add(new Book(author, title, years, pages));
                }
            }

            return listBooks;
        }

        /// <summary>
        /// Method SaveBooks saves books to binary file.
        /// </summary>
        /// <param name="books">List of books.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(_fileName, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write((string)book.Title);
                    writer.Write((string)book.Author);
                    writer.Write((int)book.Pages);
                    writer.Write((int)book.Year);
                }
            }
        }

        #endregion
    }
}
