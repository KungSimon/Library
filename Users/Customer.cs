using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;

namespace Library.Users
{
    public class Customer : IUser
    {
        public string Name { get; set; }
        public int borrowedBooks;

        public Customer(string name, int borrowedBooks)
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
        }
    }
}
