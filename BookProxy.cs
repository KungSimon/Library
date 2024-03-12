using Library.Books;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookProxy
    {
        private PhysicalBookCopy realBook;
        private IUser user;
        private LibraryInventory inventory;  

        public BookProxy(PhysicalBookCopy realBook, IUser user, LibraryInventory inventory)
        {
            this.realBook = realBook;
            this.user = user;
            this.inventory = inventory;  
        }

        public bool BorrowBook()
        {
            if (user.HasBorrowingPermission(realBook.Book))
            {
                bool borrowed = inventory.BorrowBook(realBook.Book.Title);  
                if (borrowed)
                {
                    realBook.IsBorrowed = true;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Book {realBook.Book.Title} is not available for borrowing.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"User {user.Name} does not have permission to borrow {realBook.Book.Title}.");
                return false;
            }
        }

        public string GetTitle() => realBook.GetTitle();
        public string GetAuthor() => realBook.Book.Author;
        public string GetGenre() => realBook.Book.Genre;
    }
}
        