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
    public class AddNewBookCommand : ICommand
    {
        Librarian librarian;
        BookBuilder bookBuilder;
        LibraryInventory inventory;
        //private IUser user;
        private Dictionary<string, ICommand> commands;

        public AddNewBookCommand(LibraryInventory inventory, Dictionary<string, ICommand> commands, IUser user)
        {
            this.inventory = inventory;
            //this.user = user;
            this.commands = commands;
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
            //inventory.ListBooks();
            // Update the list of available books after adding a new book
            //var availableBooks = inventory.availableBooks.Select(pb => pb.Book).ToList();
            //commands["2"] = new SortBookByTitleCommand(availableBooks); // Assuming "3" is the command for sorting books
            //commands["2"] = new SortBookByTitleCommand(inventory.availableBooks.Select(pb => pb.Book).ToList());

            // Execute the sorting command immediately after updating
            //commands["2"].Execute();
        }

        public string GetDescription()
        {
            return "Add a new book to the inventory"; 
        }
    }
}
