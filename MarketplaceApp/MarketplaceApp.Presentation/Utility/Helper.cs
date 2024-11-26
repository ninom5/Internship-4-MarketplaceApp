using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Utility
{
    public class Helper
    {
        public static Result ShowAllProductsOnSale(Marketplace marketPlace)
        {
            var listOfProducts = ProductRepository.AllProductsOnSale(marketPlace);
            if (!listOfProducts.Any())
            {
                Console.WriteLine("\nNema dostupnih proizvoda");
                return Result.Failed;
            }

            ShowProduct.PrintProducts(listOfProducts);
            return Result.Success;
        }
        public static Product GetProduct(Marketplace marketPlace, Guid id)
        {
            Product product = marketPlace.ProductList.FirstOrDefault(product => product.Id == id);
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
