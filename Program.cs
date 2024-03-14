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
            /*IUserRepository userRepository = new CSVUserRepository("users.csv");
            UserManager userManager = new UserManager(userRepository);
            List<Customer> customers = new List<Customer>();
            //customers.Add((Customer)userManager.CreateCustomer());
            List<Book> books = new List<Book>();
            //ICommand sortBooksCommand = new SortBookByTitleCommand(books);
            userManager.SaveUsers(customers);
            Library library = new Library();
            LibraryInventory inventory = new LibraryInventory();
            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

            IUser user; //= userManager.CreateCustomer();

            Book ollesÄventyr = new BookBuilder()
                .SetTitle("Olles äventyr")
                .SetAuthor("Olle")
                .SetGenre("Novel")
                .Build();
            inventory.AddBook(ollesÄventyr, 1);


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


            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Are you a (1) Customer or (2) Librarian? ");
            string userTypeChoice = Console.ReadLine();

            //IUser user;
            if (userTypeChoice == "1")
            {
                
                user = userManager.CreateCustomer();
                user.IsLibrarian = false;
                Customer customer = (Customer)user;
                library.RegisterCommand("1", new BorrowBookCommand(inventory, user));
                library.RegisterCommand("2", new ReturnBookCommand(inventory, customer));
                library.RegisterCommand("3", new SortBookByTitleCommand(inventory));
                library.RegisterCommand("4", new QuitCommand());
            }
            else if (userTypeChoice == "2")
            {
                user = new Librarian("Librarian");
                user.IsLibrarian = true;
                library.RegisterCommand("1", new AddNewBookCommand(inventory, commands, user));
                library.RegisterCommand("2", new SortBookByTitleCommand(inventory));
                library.RegisterCommand("3", new QuitCommand());
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

                library.RunCommand(commandName);
            }*/
        }
    }
}