using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Models
{
    public class User
    {
        public User(string name,string password,string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
