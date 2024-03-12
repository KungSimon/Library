using Library.Interfaces;
using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands
{
    public class BorrowBookCommand : ICommand
    {
        //private LibraryInventory inventory;

        LibraryInventory inventory = new LibraryInventory();

        private IUser currentUser;

        public BorrowBookCommand(LibraryInventory inventory, IUser currentUser)
        {
            this.inventory = inventory;
            this.currentUser = currentUser;
        }


        public void Execute()
        {
            if (currentUser is Customer customer)
            {
                if (customer.borrowedBooks < 5)
                {
                    Console.WriteLine("Available books: ");
                    inventory.ListBooks();
                    Console.WriteLine();

                    Console.WriteLine("Enter the title of the book you want to borrow: ");
                    string bookTitle = Console.ReadLine();

                    bool borrowed = inventory.BorrowBook(bookTitle);
                    if (borrowed)
                    {
                        customer.BorrowBook(inventory.availableBooks.FirstOrDefault(b => b.Book.Title == bookTitle)); // Update customer's borrowed books
                        Console.WriteLine($"You have now successfully borrowed {bookTitle}.");
                    }
                    else
                    {
                        Console.WriteLine($"Book {bookTitle} is not available for borrowing.");
                    }
                }
                else
                {
                    Console.WriteLine("You have already borrowed the maximum number of books (5). Please return some books before borrowing more.");
                }
            }
        }

        public string GetDescription()
        {
            return "Borrow a book from the library";
        }
    }
}
