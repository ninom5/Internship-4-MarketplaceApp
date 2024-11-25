using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Data.Models
{
    public class Transaction
    {
        private static int numberOfTransactions = 0;
        public int IdOfTransaction { get; }
        public Guid Id { get; }
        public Buyer Buyer { get; protected set; }
        public Seller Seller { get; protected set; }
        public DateTime DateTimeOfTransaction { get; protected set; }
        public Product Product { get; protected set; }
        public Enum.Category ProductType { get; set; }
        public Transaction(Guid id, Buyer buyer, Seller seller, Product product, Enum.Category category)
        {
            numberOfTransactions++;
            IdOfTransaction = numberOfTransactions;
            Id = id;
            Buyer = buyer;
            Seller = seller;
            DateTimeOfTransaction = DateTime.Now;
            ProductType = category;
            Product = product;
        }
    }
}
