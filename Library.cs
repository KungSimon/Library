using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Commands;
using Library.Interfaces;
using Library.Users;
using System.ComponentModel.Design;

namespace Library
{
    public class Library
    {
        
        IUserRepository userRepository = new CSVUserRepository("users.csv");
        //public UserManager userManager;
        public UserManager userManager;
        public LibraryInventory inventory;
        List<Customer> customers = new List<Customer>();
        List<Book> books = new List<Book>();
        public bool programRunning = true;
        public Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        IUser user;


        public Library()
        {
            
            userManager = new UserManager(userRepository);
            inventory = new LibraryInventory();
            userManager.SaveUsers(customers);
            InitializeBooks();
        }

        private void InitializeBooks()
        {
            inventory.AddBook(new BookBuilder()
                .SetTitle("Olles äventyr")
                .SetAuthor("Olle")
                .SetGenre("Novel")
                .Build(), 1);

            inventory.AddBook(new BookBuilder()
                .SetTitle("Lord of the rings")
                .SetAuthor("J.R.R. Tolkien")
                .SetGenre("Fantasy")
                .Build(),
                3);

            inventory.AddBook(new BookBuilder()
                .SetTitle("Lord of the flies")
                .SetAuthor("William Golding")
                .SetGenre("Novel")
                .Build(),
                2);


            inventory.AddBook(new BookBuilder()
                .SetTitle("Dracula")
                .SetAuthor("Bram Stoker")
                .SetGenre("Horror Novel")
                .Build(),
                6);

            inventory.AddBook(new BookBuilder()
                .SetTitle("Harry Potter and the Philosopher's Stone")
                .SetAuthor("J. K. Rowling.")
                .SetGenre("Fantasy novel")
                .Build(),
                1);
        }


        public void RegisterCommand(string name, ICommand command)
        {
            commands[name] = command;
        }

        public void RunCommand(string name)
        {
            if (commands.TryGetValue(name, out var command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }

        public void AddBookToInventory(Book book, int quantity)
        {
            inventory.AddBook(book, quantity);
        }

        public void RunLibrary()
        {
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Are you a (1) Customer or (2) Librarian? ");
            string userTypeChoice = Console.ReadLine();

            //IUser user;
            if (userTypeChoice == "1")
            {
                Customer customer = (Customer)userManager.CreateCustomer();
                //user = userManager.CreateCustomer();
                //user.IsLibrarian = false;
                customer.IsLibrarian = false;
                //Customer customer = (Customer)user;
                user = customer;
                RegisterCommand("1", new BorrowBookCommand(inventory, user));
                RegisterCommand("2", new ReturnBookCommand(inventory, customer));
                RegisterCommand("3", new SortBookByTitleCommand(inventory));
                RegisterCommand("4", new QuitCommand());
            }
            else if (userTypeChoice == "2")
            {
                Librarian librarian = new Librarian("Librarian");
                librarian.IsLibrarian = true;
                user = librarian;
                //user = new Librarian("Librarian");
                //user.IsLibrarian = true;
                RegisterCommand("1", new AddNewBookCommand(inventory, commands, user));
                RegisterCommand("2", new SortBookByTitleCommand(inventory));
                RegisterCommand("3", new QuitCommand());
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");

                return;
            }

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                if (user.IsLibrarian)
                {
                    Console.WriteLine("(1) Add a new book?\t (2) Sort Books by Title?\t (3) Quit?");
                }
                else
                {
                    Console.WriteLine("(1) Borrow book?\t (2) Return book?\t (3) Sort Books by Title?\t (4) Quit?");
                }

                var commandName = Console.ReadLine();

                RunCommand(commandName);
            }
        
        }
    }
}
