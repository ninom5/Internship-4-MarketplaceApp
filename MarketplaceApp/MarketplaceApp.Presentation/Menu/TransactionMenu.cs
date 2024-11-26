using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Menu
{
    public class TransactionMenu
    {
        public static void ShowAllTransactions(Marketplace marketplace)
        {
            var list = TransactionRepository.GetAllTransactions(marketplace);
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
    }
}
