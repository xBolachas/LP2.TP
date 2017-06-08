using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Models
{
    public class User
    {
        public User(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }

        public User(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
