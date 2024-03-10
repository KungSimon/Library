using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IUserRepository
    {
        void SaveUsers(List<Customer> customers);
    }
}
