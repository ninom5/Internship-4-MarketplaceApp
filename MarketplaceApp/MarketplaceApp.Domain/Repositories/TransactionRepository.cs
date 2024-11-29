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
        public static DomainEnums.Result FinishTransaction(Marketplace marketplace, Product product, Buyer buyer, PromoCodes promoCodes)
        {
            double price = product.Price;

            if (promoCodes != null)
                price *= (1 - promoCodes.Discount);

            buyer.Amount -= price;
            product.Seller.Earnings += (price * 0.95);

            Data.Models.Transaction transaction = new Data.Models.Transaction(Guid.NewGuid(), buyer, product.Seller, product, price, product.ProductType);

            marketplace.TransactionsList.Add(transaction);

            product.ProductStatus = Data.Enum.ProductStatus.Prodano;

            marketplace.MarketPlaceBalance += (price * MarketplaceProvision);

            return DomainEnums.Result.Success;
        }

        public static Result ProcessReturnTransaction(Marketplace marketPlace, Data.Models.Transaction transaction, Buyer buyer)
        {
            double amountToReturn = transaction.Price * 0.8;

            buyer.Amount += amountToReturn;
            transaction.Seller.Earnings -= amountToReturn;

            marketPlace.TransactionsList.Remove(transaction);

            var sellerReturnProvision = transaction.Price - amountToReturn - (MarketplaceProvision * transaction.Price);

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
