using Library.Books;
using Library.Commands;
using Library.Interfaces;
using Library.Menus;
using Library.Users;
using System.ComponentModel.Design;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new CSVUserRepository("users.csv");
            UserManager userManager = new UserManager(userRepository);
            List<Customer> customers = new List<Customer>();
            //customers.Add((Customer)userManager.CreateCustomer());
            userManager.SaveUsers(customers);
            Library library = new Library();
            LibraryInventory inventory = new LibraryInventory();

            IUser user; //= userManager.CreateCustomer();

            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Are you a (1) Customer or (2) Librarian? ");
            string userTypeChoice = Console.ReadLine();

            //IUser user;
            if (userTypeChoice == "1")
            {
                user = userManager.CreateCustomer();
                user.IsLibrarian = false;
                CustomerMenu customerMenu = new CustomerMenu(user, inventory);
                customerMenu.DisplayMenu();
            }
            else if (userTypeChoice == "2")
            {
                user = new Librarian("Librarian");  
                user.IsLibrarian = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                
                return;
            }


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

            


           //library.RegisterCommand("Borrow book", new BorrowBookCommand(inventory, user));
           //library.RegisterCommand("Return book", new ReturnBookCommand(inventory, user));
           //library.RegisterCommand("Add a new book", new AddNewBook(inventory, user));
           //library.RegisterCommand("Quit", new QuitCommand());
           //
           //
           //
           //while (true)
           //{
           //    Console.WriteLine("What do you want to do?");
           //    Console.WriteLine("Borrow book?\t Return book?\t Add a new book?\t Quit ");
           //    
           //    var commandName = Console.ReadLine();
           //
           //    library.RunCommand(commandName);
           //}
        }
    }
}