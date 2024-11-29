using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MarketplaceApp.Data.Models
{
    public class Marketplace
    {
        public List<User> UserList { get; set; } = new List<User>();
        public List<Product> ProductList { get; set; } = new List<Product> { };
        public List<Transaction> TransactionsList { get; set; } = new List<Transaction> { };
        public List<ReturnedTransaction> ReturnedProductsTransactionList { get; set; } = new List<ReturnedTransaction> { };
        public List<PromoCodes> PromoCodesList { get; set; } = new List<PromoCodes> { };    
        public double MarketPlaceBalance { get; set; }
        public Marketplace()
        {
            UserList = new List<User>();
            ProductList = new List<Product>();
            TransactionsList = new List<Transaction>();
            ReturnedProductsTransactionList = new List<ReturnedTransaction>();
            PromoCodesList = new List<PromoCodes> { };
            MarketPlaceBalance = 0.0;
        }
    }
}
