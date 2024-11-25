using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class TransactionFunctions
    {
        public static Transaction CreateTransaction(Guid id, Buyer buyer, Seller seller, Product product, Data.Category productCategory)
        {
            return new Transaction(id, buyer, seller, product, productCategory);
        }
        public static void ShowAllTransactions(MarketPlace marketPlace)
        {
            foreach(var transaction in marketPlace.TransactionsList)
            {
                Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, kupac: {transaction.Buyer.Name}, prodavac: {transaction.Seller.Name}, " +
                    $"datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, kategorija proizvoda: {transaction.ProductType}");
            }
        }
    }
}
