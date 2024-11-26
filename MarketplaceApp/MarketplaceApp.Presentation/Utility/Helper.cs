using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Show;

namespace MarketplaceApp.Presentation.Utility
{
    public class Helper
    {
        public static Category ChooseCategory()
        {
            while (true)
            {
                Console.WriteLine("Odaberite kategoriju: \n\t1.Elektronika \n\t2.Odjeca \n\t3.Knjige \n\t4.Obuca");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        return Category.Elektronika;
                    case '2':
                        return Category.Odjeca;
                    case '3':
                        return Category.Knjige;
                    case '4':
                        return Category.Obuća;
                    default:
                        Console.WriteLine("Ne ispravan unos");
                        break;
                }
            }
        }
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
