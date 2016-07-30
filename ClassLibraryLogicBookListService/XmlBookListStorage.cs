using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibraryLogicBooks;

namespace ClassLibraryLogicBookListService
{
    public class XmlBookListStorage : IBookListStorage
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

        public XmlBookListStorage() {   }

        public XmlBookListStorage(string path)
        {
            FileName = path;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method LoadBooks loads list of books from xml documents.
        /// </summary>
        /// <returns>List of books.</returns>
        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            XDocument xDoc = XDocument.Load(FileName);

            IEnumerable<XElement> elements = xDoc.Descendants("Book");

            foreach (var element in elements)
            {
                books.Add(new Book((string)element.Element("Author"), (string)element.Element("Title"), (int)element.Element("Year"), (int)element.Element("Pages")));
            }

            return books;
        }
        
        /// <summary>
        /// Method SaveBooks save list of books to xml document.
        /// </summary>
        /// <param name="books">List of books.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            XDocument xDoc = new XDocument(new XElement("Books"));
            foreach (var book in books)
            {
                xDoc.Element("Books").Add(new XElement("Book", new XElement("Title", book.Title),
                    new XElement("Author", book.Author),
                    new XElement("Pages", book.Pages),
                    new XElement("Year", book.Year)));
            }

            if(FileName != null)
                xDoc.Save(FileName);
            else
                xDoc.Save("Books.xml");
        }
        #endregion
    }
}
