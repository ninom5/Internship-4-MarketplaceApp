using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Data.Models
{
    public class Buyer : User
    {
        public double Amount { get; set; }
        public List<Product> FavouriteProductsList { get; set; }
        public Buyer(string name, string email, double amount) : base(name, email)
        {
            Amount = amount;
            FavouriteProductsList = new List<Product>();
        }
        public override string UserType()
        {
            return ($"Vrsta korisnika: kupac(trenutni raspolozivi saldo: {Math.Round(Amount, 2)})");
        }
    }
}
