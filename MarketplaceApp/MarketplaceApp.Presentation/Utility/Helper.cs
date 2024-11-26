using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Utility
{
    public class Helper
    {
        public static void ShowAllProductsOnSale(Marketplace marketPlace)
        {
            var listOfProducts = ProductRepository.AllProductsOnSale(marketPlace);
            if (!listOfProducts.Any())
            {
                Console.WriteLine("Nema dostupnih proizvoda");
                return;
            }

            ProductRepository.PrintProducts(listOfProducts);
        }
        public static Product GetProduct(Marketplace marketPlace, Guid id)
        {
            Product product = ProductRepository.GetProduct(marketPlace, id);
            if (product == null)
            {
                Console.WriteLine("Nije pronaden proizvod");
                return null;
            }
            return product;
        }

        public static bool CheckIsNull(Product product)
        {
            return product == null;
        }
    }
}
