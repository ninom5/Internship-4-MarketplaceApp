using MarketplaceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Domain.Repositories
{
    public class UserRepository
    {
        public void AddUser(Marketplace marketplace, string name, string email, double amount)
        {
            Buyer newBuyer = new Buyer(name, email, amount);
            marketplace.UserList.Add(newBuyer);
        }
        public void AddUser(Marketplace marketplace, string name, string email)
        {
            Seller newSeller = new Seller(name, email);
            marketplace.UserList.Add(newSeller);
        }
        public bool DoesEmailExist(Marketplace marketplace, string email)
        {
            return marketplace.UserList.Any(user => user.Email == email);
        }
        public User FindUser(string email, Marketplace marketplace)
        {
            return marketplace.UserList.FirstOrDefault(user => user.Email == email);
        }
    }
}
