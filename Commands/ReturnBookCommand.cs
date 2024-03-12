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

        public string GetDescription()
        {
            return "Return a borrowed book";
        }
    }
}
