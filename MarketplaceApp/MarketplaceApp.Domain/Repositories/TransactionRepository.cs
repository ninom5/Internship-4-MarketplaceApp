using MarketplaceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Domain.Repositories
{
    public class TransactionRepository
    {
        private double MarketplaceProvision = 0.05;
        public void CreateTransaction(Product product, Buyer buyer, Marketplace marketplace, out string message)
        {
            if(buyer.Amount < product.Price)
            {
                message = "Nemate dovoljno para na racunu";
                return;
            }

            if (product.ProductStatus != Data.Enum.ProductStatus.Na_prodaji)
            {
                message = "Proizvod je vec kupljen";
                return;
            }

            buyer.Amount -= product.Price;
            product.Seller.Earnings += (product.Price * 0.95);

            Transaction transaction = new Transaction(Guid.NewGuid(), buyer, product.Seller, product, product.ProductType);
            marketplace.TransactionsList.Add(transaction);
            product.ProductStatus = Data.Enum.ProductStatus.Prodano;

            marketplace.MarketPlaceBalance += (product.Price * MarketplaceProvision);

            message = $"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {product.Price}";
        }
        public static List<Transaction> GetAllTransactions(Marketplace marketplace)
        {
            return marketplace.TransactionsList;
        }
    }
}
