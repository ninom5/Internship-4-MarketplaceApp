using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Show
{
    public class ShowTransaction
    {
        public static void ShowAllTransactions(Marketplace marketplace)
        {
            var list = GetAllTransactions(marketplace);
            if (!list.Any())
            {
                Console.WriteLine("Nema transakcija");
                return;
            }
            foreach (var transaction in list)
            {
                Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, kupac: {transaction.Buyer.Name}, " +
                    $"prodavac: {transaction.Seller.Name}, datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, kategorija proizvoda: {transaction.ProductType}");
            }

            Console.WriteLine("\nza povratak na glavni menu pritisnite bilo koju tipku");
            Console.ReadKey();
        }
        private static List<Transaction> GetAllTransactions(Marketplace marketplace)
        {
            return marketplace.TransactionsList;
        }
    }
}
