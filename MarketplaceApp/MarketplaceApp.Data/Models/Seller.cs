using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Data.Models
{
    public class Seller : User
    {
        public double Earnings { get; set; }
        public Seller(string name, string email) : base(name, email)
        {
            Earnings = 0;
        }
    }
}
