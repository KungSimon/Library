using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;

namespace Library
{
    internal interface ILibraryObserver
    {
        void Update(Book book);
    }
}
