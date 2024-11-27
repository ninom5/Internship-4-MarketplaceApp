using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;
using System;
using System.Diagnostics;
using System.Transactions;

namespace MarketplaceApp.Domain.Repositories
{
    public class TransactionRepository
    {
        private static double MarketplaceProvision = 0.05;
        public static DomainEnums.Result FinishTransaction(Marketplace marketplace, Product product, Buyer buyer)
        {
            buyer.Amount -= product.Price;
            product.Seller.Earnings += (product.Price * 0.95);

            Data.Models.Transaction transaction = new Data.Models.Transaction(Guid.NewGuid(), buyer, product.Seller, product, product.ProductType);
            marketplace.TransactionsList.Add(transaction);
            product.ProductStatus = Data.Enum.ProductStatus.Prodano;

            marketplace.MarketPlaceBalance += (product.Price * MarketplaceProvision);

            return DomainEnums.Result.Success;
        }

        public static Result ProcessReturnTransaction(Marketplace marketPlace, Data.Models.Transaction transaction, Buyer buyer)
        {
            double amountToReturn = transaction.Product.Price * 0.8;

            buyer.Amount += amountToReturn;
            transaction.Seller.Earnings -= amountToReturn;

            marketPlace.TransactionsList.Remove(transaction);

            return Result.Success;
        }
        public static Data.Models.Transaction FindTransaction(Marketplace marketPlace, Buyer buyer, Product product)
        {
            return marketPlace.TransactionsList
                .FirstOrDefault(buy => buy.Buyer == buyer && buy.Product.Id == product.Id); 
        }
    }
}
