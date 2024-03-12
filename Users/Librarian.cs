using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Interfaces;

namespace Library.Users
{
    public class Librarian : IUser
    {
        public string Name { get; set; }
        public bool IsLibrarian { get => true; set { } }

        public Librarian (string name)
        {
            Name = name;
        }

        public bool HasBorrowingPermission(Book book)
        {
            return true;
        }
    }
}
