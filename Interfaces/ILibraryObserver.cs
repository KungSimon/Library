using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;

namespace Library.Interfaces
{
    internal interface ILibraryObserver
    {
        void Update(Book book);
    }
}
