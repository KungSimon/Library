using Library.Books;
using Library.Interfaces;
using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands
{
    public class AddNewBook : ICommand
    {
        Librarian librarian;
        BookBuilder bookBuilder;
        LibraryInventory inventory;
        private IUser user;

        public AddNewBook(LibraryInventory inventory, IUser user)
        {
            this.inventory = inventory;
            this.user = user;
        }

        public void Execute()
        {
            Console.WriteLine("What is the name of the book?");
            string bookName = Console.ReadLine();
            Console.WriteLine("What is the name of the author?");
            string bookAuthor = Console.ReadLine();
            Console.WriteLine("What is the genre?");
            string bookGenre = Console.ReadLine();
            Console.WriteLine("How many copies?");
            string bookCopies = Console.ReadLine();

            Book newBook = new BookBuilder()
                .SetTitle(bookName)
                .SetAuthor(bookAuthor)
                .SetGenre(bookGenre)
                .Build();
            inventory.AddBook(newBook, int.Parse(bookCopies));
        }

        public string GetDescription()
        {
            return "Add a new book to the inventory"; 
        }
    }
}
