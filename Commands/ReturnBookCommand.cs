using Library.Books;
using Library.Interfaces;
using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands
{
    public class ReturnBookCommand : ICommand
    {
        private LibraryInventory _inventory;
        private Customer _customer;

        public ReturnBookCommand(LibraryInventory inventory, Customer currentCustomer)
        {
            _inventory = inventory;
            _customer = currentCustomer;
        }

        public void Execute()
        {
            _customer.ListBorrowedBooks();
            Console.WriteLine("Enter the title of the book you want to return: ");
            string title = Console.ReadLine();

            PhysicalBookCopy borrowedBook = _customer.BorrowedBooks.FirstOrDefault(book => book.Book.Title == title);
            if (borrowedBook != null)
            {
                // Decorate the book with rating functionality
                ILibraryItem ratedBook = new RatingDecorator(borrowedBook.Book);

                Console.WriteLine("Please rate the book (1-5): ");
                int rating = int.Parse(Console.ReadLine());

                // Rate the book using the decorator
                ratedBook.Rate(rating);

                // Attempt to return the book
                bool success = _inventory.ReturnBook(title, _customer);

                if (success)
                {
                    Console.WriteLine($"Book {title} returned successfully.");
                }
                else
                {
                    Console.WriteLine($"Book {title} not found or cannot be returned.");
                }
            }
            else
            {
                Console.WriteLine($"You have not borrowed a book titled {title}.");
            }
        }
            public string GetDescription()
        {
            return "Return a borrowed book";
        }
    }
}
