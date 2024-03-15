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
        ISortStrategy strategy;
        IUser user;
        private readonly LibraryCommandExecutor commandExecutor;


        public Library()
        {
            userManager = new UserManager(userRepository);
            inventory = new LibraryInventory();
            userManager.SaveUsers(customers);
            //commandExecutor = new LibraryCommandExecutor(inventory);
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

            InitializeUser(userTypeChoice);

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                DisplayUserOptions(user.IsLibrarian);

                var commandName = Console.ReadLine();

                if (commandName == "2" && user.IsLibrarian)
                {
                    ChooseSortingAlgorithm();
                    RunCommand("2"); 
                }
                else if (commandName == "3" && (!user.IsLibrarian))
                {
                    ChooseSortingAlgorithm();
                    RunCommand("3"); 
                }
                else
                {
                    RunCommand(commandName);
                }
            }
        }

        private void InitializeUser(string userTypeChoice)
        {
            if (userTypeChoice == "1")
            {
                user = userManager.CreateCustomer();
                user.IsLibrarian = false;
                RegisterCustomerCommands();
            }
            else if (userTypeChoice == "2")
            {
                Librarian librarian = new Librarian("Librarian");
                user = librarian; // Initialize the user object here
                user.IsLibrarian = true;
                RegisterLibrarianCommands();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                Environment.Exit(0); // Exit gracefully
            }
        }

        private void RegisterCustomerCommands()
        {
            RegisterCommand("1", new BorrowBookCommand(inventory, user));
            RegisterCommand("2", new ReturnBookCommand(inventory, (Customer)user));
            RegisterCommand("3", new SortBookByTitleCommand(inventory, new QuickSortStrategy()));
            RegisterCommand("4", new QuitCommand());
        }

        private void RegisterLibrarianCommands()
        {
            RegisterCommand("1", new AddNewBookCommand(inventory, commands, user));
            RegisterCommand("2", new SortBookByTitleCommand(inventory, new QuickSortStrategy()));
            RegisterCommand("3", new QuitCommand());
        }

        private void ChooseSortingAlgorithm()
        {
            Console.WriteLine("Choose your sorting algorithm:");
            Console.WriteLine("1. QuickSort");
            Console.WriteLine("2. BubbleSort");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            if (choice == "2")
            {
                strategy = new BubbleSortStrategy();
            }
            else
            {
                strategy = new QuickSortStrategy();
            }
        }

        private void DisplayUserOptions(bool isLibrarian)
        {
            if (isLibrarian)
            {
                Console.WriteLine("(1) Add a new book\t(2) Sort Books by Title\t(3) Quit");
            }
            else
            {
                Console.WriteLine("(1) Borrow book\t(2) Return book\t(3) Sort Books by Title\t(4) Quit");
            }
        }
        /*public void RunLibrary()
        {
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Are you a (1) Customer or (2) Librarian? ");
            string userTypeChoice = Console.ReadLine();

            if (userTypeChoice == "1")
            {
                Customer customer = (Customer)userManager.CreateCustomer();
                customer.IsLibrarian = false;
                user = customer;
                RegisterCommand("1", new BorrowBookCommand(inventory, user));
                RegisterCommand("2", new ReturnBookCommand(inventory, customer));
                RegisterCommand("3", new SortBookByTitleCommand(inventory, strategy));
                RegisterCommand("4", new QuitCommand());
            }
            else if (userTypeChoice == "2")
            {
                Librarian librarian = new Librarian("Librarian");
                librarian.IsLibrarian = true;
                user = librarian;
                RegisterCommand("1", new AddNewBookCommand(inventory, commands, user));
                RegisterCommand("2", new SortBookByTitleCommand(inventory, strategy));
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

                if ((commandName == "2" && user.IsLibrarian) || (commandName == "3" && !user.IsLibrarian))
                {
                    Console.WriteLine("Choose sorting algorithm:");
                    Console.WriteLine("1. QuickSort");
                    Console.WriteLine("2. BubbleSort");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    ISortStrategy sortStrategy;
                    if (choice == "1")
                    {
                        sortStrategy = new QuickSortStrategy();
                    }
                    else if (choice == "2")
                    {
                        sortStrategy = new BubbleSortStrategy();
                    }
                    else
                    {
                        sortStrategy = new QuickSortStrategy();
                    }
                    strategy = sortStrategy;
                    ICommand sortCommand = new SortBookByTitleCommand(inventory, strategy);
                    sortCommand.Execute();
                }
                else
                {
                    RunCommand(commandName);
                }
            }
        }*/
    }
}
