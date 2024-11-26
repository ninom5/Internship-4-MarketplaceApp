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
        public Buyer(string name, string email, double amount) : base(name, email)
        {
            Amount = amount;
        }
    }
}
