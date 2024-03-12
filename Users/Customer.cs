using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Interfaces;

namespace Library.Users
{
    public class Customer : IUser
    {
        public string Name { get; set; }
        //public int borrowedBooks;
        public List<PhysicalBookCopy> BorrowedBooks { get; } = new List<PhysicalBookCopy>();
        public bool IsLibrarian { get => false; set { } }

        public Customer(string name)
        {
            Name = name;
        }

        public bool HasBorrowingPermission(Book book)
        {
            // Implement your logic here
            return true;
        }

        public void BorrowBook(PhysicalBookCopy bookCopy)
        {
            BorrowedBooks.Add(bookCopy);
        }

        public void ReturnBook(PhysicalBookCopy bookCopy)
        {
            BorrowedBooks.Remove(bookCopy);
        }

        public void ListBorrowedBooks()
        {
            Console.WriteLine($"Borrowed book by {Name}");
            foreach(var bookCopy in BorrowedBooks)
            {
                Console.WriteLine($"{bookCopy.Book.Title} by {bookCopy.Book.Author}");
            }
        }
        /*public Customer(string name, int borrowedBooks)
        {
            Name = name;
            this.borrowedBooks = 0;
        }

        public bool HasBorrowingPermission(Book book)
        {
            return true;
        }

        public int BorrowedBooks { get => borrowedBooks; }
       

        public void BorrowBook(PhysicalBookCopy bookCopy)
        {
            borrowedBooks++;
        }

        public void ReturnBook(PhysicalBookCopy bookCopy)
        {
            borrowedBooks--;
        }*/


    }
}
