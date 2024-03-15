using Library.Books;
using Library.Commands;
using Library.Interfaces;
using Library.Commands;
using Library.Users;
using System.ComponentModel.Design;

namespace Library
{
    //Funkar inte att lägga till ny bok och sedan sortera!!!!!
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.RunLibrary();
        }
    }
}