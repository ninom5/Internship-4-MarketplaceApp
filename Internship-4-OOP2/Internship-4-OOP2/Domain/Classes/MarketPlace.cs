using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class MarketPlace
    {
        public List<Buyer> BuyerList { get; set; } = new List<Buyer>();
        public List<Seller> SellerList { get; set; } = new List<Seller>();
        public List<Product> ProductList { get; set; } = new List<Product> { };
        public MarketPlace()
        {
            BuyerList = new List<Buyer>();
            SellerList = new List<Seller>();
            ProductList = new List<Product>();
        }
    }
}
