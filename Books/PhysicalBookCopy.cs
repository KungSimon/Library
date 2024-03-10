using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Books
{
    public class PhysicalBookCopy
    {
        public Book Book { get; private set; }
        public bool IsBorrowed { get; set; }
        public int Quantity { get; set; }

        public PhysicalBookCopy(Book book, int quantity)
        {
            Book = book;
            IsBorrowed = false;
            Quantity = quantity;
        }
        public string GetTitle()
        {
            return Book.Title;
        }
    }
}
