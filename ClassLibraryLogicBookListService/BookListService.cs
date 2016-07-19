using ClassLibraryLogicBook;
using System;
using System.Collections.Generic;
using System.IO;
using NLog;

namespace ClassLibraryLogicBookListService
{
    public class BookListService : BinaryBookListStorage
    {
        #region Fields
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<Book> _booksList;
        #endregion

        #region Properties

        public List<Book> BookList
        {
            get { return _booksList; }
            private set
            {
                if (value != null)
                    _booksList = new List<Book>(value);
                else
                    logger.Error(new ArgumentException(nameof(value)), "Reported empty list of books!");
            }
        }

        #endregion

        #region Ctors

        public BookListService(List<Book> books)
        {
            BookList = books;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method AddBook add book in list of books
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            bool isExist = false;

            isExist = FindBook(book);

            if (!isExist)
                BookList.Add(book);
            else
                logger.Error(new ArgumentException(nameof(book)), "This Book already in list!");
        }

        /// <summary>
        /// Method RemoveBook if find book remove it from list of books.
        /// </summary>
        /// <param name="book">Book that need remove.</param>
        public void RemoveBook(Book book)
        {
            logger.Trace("Method FormatDataForDisplay end");

            bool isExist = false;

            isExist = FindBook(book);

            if (isExist)
                BookList.Remove(book);
            else
                logger.Error("Cannot delete this book!");
        }

        /// <summary>
        /// Method FindBookByTag findes book by predicate.
        /// </summary>
        /// <param name="tag">Predicate.</param>
        public Book FindBookByTag(Predicate<Book> tag)
        {
            Book needBook = new Book();

            if(tag != null)
                needBook = BookList.Find(tag);
            else
                logger.Error(new ArgumentNullException(nameof(tag)), "Cannot find book: tag is null!");

            return needBook;
        }

        /// <summary>
        /// Method SortBooksByTag sortes list of book by tag.
        /// </summary>
        /// <param name="books">List of books.</param>
        /// <param name="comparison">Tag for sort.</param>
        public void SortBooksByTag(List<Book> books, Comparison<Book> comparison)
        {
            if(BookList == null)
                logger.Error(new ArgumentNullException(nameof(books)), "Reported empty list of books!");

            if(comparison == null)
                logger.Error(new ArgumentException(nameof(comparison)), "Cannot sort book by tag!");

            books.Sort(comparison);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Method FindBook search book in list of books.
        /// </summary>
        /// <param name="book">Need Book.</param>
        /// <returns>True if need book is find.</returns>
        private bool FindBook(Book book)
        {
            bool result = false;

            result = BookList.Contains(book);

            return result;
        }

        #endregion
    }
}
