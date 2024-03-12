using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Interfaces;

namespace Library
{
    public class LibraryNotifer : ILibraryObserver
    {
        public void Update(Book book)
        {
            Console.WriteLine($"Notifying subscribers: A new book '{book.Title}' is available for borrowing.");
        }
    }
}
