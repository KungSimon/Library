using Library.Commands;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Menus
{
    public class CustomerMenu
    {
        private IUser user;
        private LibraryInventory inventory;
        private Dictionary<string, Action> options;

        public CustomerMenu(IUser user, LibraryInventory inventory)
        {
            this.user = user;
            this.inventory = inventory;
            this.options = new Dictionary<string, Action>();

            options.Add("Borrow Book", () => new BorrowBookCommand(inventory, user).Execute());
            options.Add("Return Book", () => new ReturnBookCommand(inventory, user).Execute());
            options.Add("Exit", () => new QuitCommand().Execute());
        }


        public void DisplayMenu()
        {
            Console.WriteLine("Customer Menu:");
            int counter = 1;  // Optional: counter for numbered options
            foreach (var optionText in options.Keys)
            {
                Console.WriteLine($"{counter++}. {optionText}");
            }

            var choice = GetChoice();

            if (options.ContainsKey(choice)) // Check if key exists
            {
                options[choice](); // Execute action for the chosen key
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private int GetChoice()
        {
            while (true)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice > 0 && choice <= options.Count)
                {
                    return choice - 1; // Adjust for zero-based indexing
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and {0}.", options.Count);
                }
            }
        }
    }
}
