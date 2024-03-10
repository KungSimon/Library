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
        private IUser _currentUser;

        public ReturnBookCommand(LibraryInventory inventory, IUser currentUser)
        {
            _inventory = inventory;
            _currentUser = currentUser;
        }

        public void Execute()
        {
            if (_currentUser is Customer customer)
            {
                if (customer.BorrowedBooks > 0) // Check if there are borrowed books
                {
                    Console.WriteLine("Here are your borrowed books: ");
                    foreach (var book in _inventory.availableBooks.Where(b => b.IsBorrowed && b.BorrowedBy == customer))
                    {
                        Console.WriteLine($"{book.GetTitle()}");
                    }

                    Console.WriteLine("Enter the title of the book you want to return: ");
                    string bookTitle = Console.ReadLine();

                    // Find the book copy to return
                    var bookCopy = _inventory.availableBooks.FirstOrDefault(b => b.Book.Title == bookTitle && b.IsBorrowed && b.BorrowedBy == customer);

                    if (bookCopy != null)
                    {
                        _inventory.ReturnBook(bookCopy); // Return the book
                        Console.WriteLine($"You have successfully returned {bookTitle}.");
                    }
                    else
                    {
                        Console.WriteLine($"Book {bookTitle} was not found in your borrowed books or is not available for return.");
                    }
                }
                else
                {
                    Console.WriteLine("You currently have no borrowed books to return.");
                }
            }
            else
            {
                Console.WriteLine("This functionality is only available for customers.");
            }
        }

        public string GetDescription()
        {
            return "Return a borrowed book";
        }
        /*if (_currentUser is Customer customer)
{
   if (customer.borrowedBooks.Count > 0) // Check if there are borrowed books
   {
       Console.WriteLine("Here are your borrowed books: ");
       foreach (var book in customer.borrowedBooks)
       {
           Console.WriteLine($"{book.Book.Title}");
       }

       Console.WriteLine("Enter the title of the book you want to return: ");
       string bookTitle = Console.ReadLine();

       bool returned = _inventory.ReturnBook(bookTitle, customer); // Call inventory's return method
       if (returned)
       {
           customer.borrowedBooks.Remove(customer.borrowedBooks.FirstOrDefault(b => b.Book.Title == bookTitle)); // Remove from customer's list
           Console.WriteLine($"You have successfully returned {bookTitle}.");
       }
       else
       {
           Console.WriteLine($"Book {bookTitle} was not found in your borrowed books or is not available for return.");
       }
   }
   else
   {
       Console.WriteLine("You currently have no borrowed books to return.");
   }
}
else
{
   Console.WriteLine("This functionality is only available for customers.");
}*/

    }
}
