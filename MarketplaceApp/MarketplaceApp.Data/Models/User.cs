using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Data.Models
{
    public abstract class User
    {
        private static int id = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public User(string name, string email)
        {
            Id = id++;
            Name = name;
            Email = email;
        }

        public abstract string UserType();
    }
}
