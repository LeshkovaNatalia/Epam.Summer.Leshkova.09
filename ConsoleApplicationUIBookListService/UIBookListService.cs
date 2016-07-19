using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicBook;
using ClassLibraryLogicBookListService;

namespace ConsoleApplicationUIBookListService
{
    class UIBookListService
    {
        static void Main(string[] args)
        {
            // List of books 
            IEnumerable<Book> books = new Book[]
            {
                new Book("Richter", "CLR via C#", 2013, 896),
                new Book("Albahari", "C# 5.0 in nutshell", 2014, 1008),
                new Book("Bertrand Meyer", "Basics of Object Oriented Programming", 2005, 500)
            };

            // Create instance of BookListService
            BookListService listService = new BookListService(books.ToList());
            Console.WriteLine(Environment.NewLine + "---- List of books not modified ----" + Environment.NewLine);
            
            foreach (var book in books)
                Console.WriteLine(book);

            Console.WriteLine(Environment.NewLine + "---- Find book by tag Author ----" + Environment.NewLine);
            Book searchBook = null;

            searchBook = listService.FindBookByTag(x => x.Author == "Albahari");

            Console.WriteLine(searchBook.ToString());

            Console.WriteLine(Environment.NewLine + "---- Remove book with Author Abahari ----" + Environment.NewLine);
            listService.RemoveBook(searchBook);
            // Message to file nlog.txt
            listService.RemoveBook(searchBook);

            Console.WriteLine(Environment.NewLine + "---- List of books after remove ----" + Environment.NewLine);

            foreach (var book in listService.BookList)
                Console.WriteLine(book);

            Console.WriteLine(Environment.NewLine + "---- List of books after sort by tag Year ----" + Environment.NewLine);
            listService.SortBooksByTag(listService.BookList, (x, y) => x.Year);

            foreach (var book in listService.BookList)
                Console.WriteLine(book);

            Console.ReadLine();
        }
    }
}
