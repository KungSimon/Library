using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;

namespace Library.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }

        public bool IsLibrarian { get; set; }
        bool HasBorrowingPermission(Book book);

    }
}
