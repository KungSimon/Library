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

        private readonly LibraryInventory inventory;
        private readonly ISortStrategy sortStrategy;

        public SortBookByTitleCommand(LibraryInventory inventory, ISortStrategy sortStrategy)
        {
            this.inventory = inventory;
            this.sortStrategy = sortStrategy;
        }

        public void Execute()
        {
            if (inventory == null || !inventory.availableBooks.Any())
            {
                Console.WriteLine("No books available to sort.");
                return;
            }

            var books = inventory.availableBooks.ToList();
            sortStrategy.Sort(books);

            Console.WriteLine("Books sorted by title:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Book.Title} by {book.Book.Author}");
            }
        }

        public string GetDescription()
        {
            return "Sort books by title";
        }
    }
}

    

