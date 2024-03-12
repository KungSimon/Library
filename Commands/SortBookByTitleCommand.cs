using Library.Books;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands
{
    public class SortBookByTitleCommand : ICommand
    {
        private readonly List<Book> books;

        public SortBookByTitleCommand(List<Book> books)
        {
            this.books = books;
        }

        public void Execute()
        {
            if (books == null || books.Count == 0)
            {
                Console.WriteLine("No books available to sort.");
                return;
            }

            BookSorter.QuickSortByTitle(books);

            Console.WriteLine("Books sorted by title:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
            //BookSorter.QuickSortByTitle(books);
            //Console.WriteLine("Books sorted by title. ");
        }

        public string GetDescription()
        {
            return "Sort books by title";
        }
    }
}
