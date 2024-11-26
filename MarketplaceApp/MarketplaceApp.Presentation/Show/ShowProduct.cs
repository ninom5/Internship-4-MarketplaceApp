using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Show
{
    public class ShowProduct
    {
        public static bool PrintProducts(List<Product> productList)
        {
            if(!productList.Any())
            {
                Console.WriteLine("\nnema dostupnih proizvoda");
                return false;
            }

            Console.WriteLine("\n");
            foreach (var product in productList)
            {
                Console.WriteLine($"Ime proizvoda: {product.Name}, opis proizvoda: {product.Description}, id proizvoda: {product.Id}, cijena: {product.Price}, status proizvoda: {product.ProductStatus}, kategorija: {product.ProductType}, prodavac: {product.Seller.Name}");
            }

            return true;
        }
        private void ShowBuyerProducts(Marketplace marketplace, Buyer buyer, List<Transaction> boughtProducts)
        {
            if (!boughtProducts.Any())
            {
                Console.WriteLine("\nNema proizvoda, unesite 0 za prekid");
                return;
            }

            Console.WriteLine("\n");
            foreach (var transaction in boughtProducts)
            {
                Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, kupac: {transaction.Buyer.Name}, " +
                    $"prodavac: {transaction.Seller.Name}, datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, kategorija proizvoda: {transaction.ProductType}");
            }
        }
    }
}
