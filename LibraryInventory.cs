using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Users;

namespace Library
{
    public class LibraryInventory
    {
        public List<PhysicalBookCopy> availableBooks = new List<PhysicalBookCopy>();
        private List<ILibraryObserver> observers = new List<ILibraryObserver>();

        public void AddBook(Book book, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                availableBooks.Add(new PhysicalBookCopy(book, quantity));
            }
            NotifyObservers(book);
        }

        public void ListBooks()
        {
            if (availableBooks.Count == 0)
            {
                Console.WriteLine("There are currently no books avalible");
                return;
            }
            Console.WriteLine("Here's a list of available books: ");
            for (int i = 0; i < availableBooks.Count; i++)
            {
                var book = availableBooks[i];
                Console.WriteLine($"{i + 1}.{book.GetTitle()}");
            }
        }

        public bool BorrowBook(string title)
        {
            var availableCopy = availableBooks.FirstOrDefault(b => b.Book.Title == title && !b.IsBorrowed);
            if (availableCopy != null)
            {
                availableCopy.IsBorrowed = true;
                availableCopy.Quantity--;
                availableBooks.Remove(availableCopy);
                //Console.WriteLine($"You have now successfully borrowed {availableCopy.Book.Title}.");
                return true; // Return true if borrowing was successful
            }
            else
            {
                // Book not found or unavailable
                return false; // Return false if borrowing failed
            }
        }
        /*public void BorrowBook(string title, int quantityToBorrow)
        {
            var book = availableBooks.FirstOrDefault(b => b.GetTitle() == title);
            if (book != null)
            {
                availableBooks.Remove(book);
                Console.WriteLine($"You have now successfully borrowed {book.GetTitle()}.");
            }
        }*/

        public void NotifyObservers(Book book)
        {
            foreach (var observer in observers)
            {
                observer.Update(book);
            }
        }

        public PhysicalBookCopy _BorrowBook(string title)
        {

            var availableCopy = availableBooks.FirstOrDefault(b => b.Book.Title == title && !b.IsBorrowed);
            if (availableCopy != null)
            {
                availableCopy.IsBorrowed = true;
                availableCopy.Quantity--;  
                availableBooks.Remove(availableCopy);
                //Console.WriteLine($"You have now successfully borrowed {availableCopy.Book.Title}.");
                return availableCopy;
            }
            return null;

            /*var availableCopy = availableBooks.FirstOrDefault(b => b.Book.Title == title && !b.IsBorrowed);
            if (availableCopy != null)
            {
                availableCopy.IsBorrowed = true;
                availableBooks.Remove(availableCopy); // Remove the borrowed copy
                Console.WriteLine($"You have now successfully borrowed {availableCopy.Book.Title}.");
                return availableCopy;
            }
            return null;*/
        }
        /*public bool ReturnBook(string title, Customer customer)
        {
            // ... Your logic to check if the book is available for return and update inventory
            // This might involve finding the book by title, checking if it's borrowed by the customer,
            // updating the book's availability, and removing it from the customer's borrowed list.

            // Example (replace with your actual implementation)
            var availableCopy = availableBooks.FirstOrDefault(b => b.Book.Title == title && b.IsBorrowed && b.BorrowedBy == customer);
            if (availableCopy != null)
            {
                availableCopy.IsBorrowed = false;
                customer.RemoveBorrowedBook(title); // Remove from customer's list
                return true;
            }
            else
            {
                return false;
            }
        }*/

    }
}
