using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>();

        public void RegisterUser(User user) => _users.Add(user);

        public User GetUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username);
        }
    }
}
