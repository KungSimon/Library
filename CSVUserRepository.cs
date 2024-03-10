using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CSVUserRepository : IUserRepository
    {
        private string filePath;
        public CSVUserRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveUsers(List<Customer> customers)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Name");
                foreach(Customer customer in customers)
                {
                    writer.WriteLine($"{customer.Name}.");
                }
            }
        }
    }
}
