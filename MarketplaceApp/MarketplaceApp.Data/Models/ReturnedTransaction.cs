using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Data.Models
{
    public class ReturnedTransaction
    {
        private static int numberOfTransactions = 0;
        public int IdOfTransaction { get; }
        public Guid Id { get; }
        public Buyer Returner { get; protected set; }
        public Seller Seller { get; protected set; }
        public DateTime DateTimeOfTransaction { get; protected set; }
        public Product Product { get; protected set; }
        public double AmountToReturn { get; set; }
        public double SellerReturnProvision { get; set; }

        public ReturnedTransaction(Guid id, Buyer buyer, Seller seller, Product product, double amountToReturn, double sellerReturnProvision)
        {
            numberOfTransactions++;
            IdOfTransaction = numberOfTransactions;
            Id = id;
            Returner = buyer;
            Seller = seller;
            DateTimeOfTransaction = DateTime.Now;
            Product = product;
            AmountToReturn = amountToReturn;
            SellerReturnProvision = sellerReturnProvision;
        }
    }
}
