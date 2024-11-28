using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;
using System;
using System.Diagnostics;
using System.Transactions;
using Transaction = MarketplaceApp.Data.Models.Transaction;

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

            var sellerReturnProvision = transaction.Product.Price - amountToReturn - (MarketplaceProvision * transaction.Product.Price);

            ReturnedTransaction returnedTransaction = new ReturnedTransaction(Guid.NewGuid(), buyer, transaction.Seller, transaction.Product, amountToReturn, sellerReturnProvision);

            marketPlace.ReturnedProductsTransactionList.Add(returnedTransaction);

            return Result.Success;
        }
        public static Data.Models.Transaction FindTransaction(Marketplace marketPlace, Buyer buyer, Product product)
        {
            return marketPlace.TransactionsList
                .FirstOrDefault(buy => buy.Buyer == buyer && buy.Product.Id == product.Id); 
        }
        public List<Transaction> GetTransactionsWithinDateRange(Marketplace marketplace, DateTime startDate, DateTime endDate)
        {
                return marketplace.TransactionsList
                    .Where(transaction => transaction.DateTimeOfTransaction >= startDate && transaction.DateTimeOfTransaction <= endDate)
                    .ToList();
        }
        public List<ReturnedTransaction> GetReturnedTransactionsWithinDateRange(Marketplace marketplace, DateTime startDate, DateTime endDate)
        {
            return marketplace.ReturnedProductsTransactionList
                   .Where(transaction => transaction.DateTimeOfTransaction >= startDate && transaction.DateTimeOfTransaction <= endDate)
                   .ToList();
        }
    }
}
