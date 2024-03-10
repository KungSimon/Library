using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;

namespace Library.Users
{
    public interface IUser
    {
        string Name { get; set; }
        bool HasBorrowingPermission(Book book);

    }
}
