﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Users
{
    public class UserManager
    {
        private IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IUser CreateCustomer()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Maximum number of books you can borrow: 5");

            return new Customer(name, 5);
        }

        public void SaveUsers(List<Customer> customers)
        {
            userRepository.SaveUsers(customers);
        }
    }
}