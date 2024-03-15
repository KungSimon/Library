using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Interfaces;
using Library.Users;

namespace Library
{
    public class LibraryInventory
    {
        public List<PhysicalBookCopy> availableBooks = new List<PhysicalBookCopy>();
        private List<ILibraryObserver> observers = new List<ILibraryObserver>();

       

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
        public void AddBook(Book book, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                availableBooks.Add(new PhysicalBookCopy(book, quantity));
            }
            NotifyObservers(book);
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
                return true;
            }
            else
            {
                return false;
            }
        }


        public void NotifyObservers(Book book)
        {
            foreach (var observer in observers)
            {
                observer.Update(book);
            }
        }


        public bool ReturnBook(string title, Customer customer)
        {
            var borrowedCopy = customer.BorrowedBooks.FirstOrDefault(b => b.Book.Title == title);
            if (borrowedCopy != null)
            {
                availableBooks.Add(borrowedCopy); // Add the book copy back to inventory
                customer.BorrowedBooks.Remove(borrowedCopy); // Remove from customer's borrowed list
                borrowedCopy.IsBorrowed = false; // Update the book copy's borrowed status
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
