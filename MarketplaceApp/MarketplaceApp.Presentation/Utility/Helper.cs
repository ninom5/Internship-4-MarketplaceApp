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
            int numOfCategory = 1;
            Console.WriteLine("Odaberite kategoriju:");
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"\t{numOfCategory++}. {category}");
            }

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int option) && Enum.IsDefined(typeof(Category), option))
                {
                    return (Category)option;
                }

                Console.WriteLine("Ne ispravan unos, unesite ponovo.");
            }
        }
        public static Result AllProductsOnSale(Marketplace marketPlace)
        {
            ProductRepository productRepository = new ProductRepository();

            var listOfProducts = productRepository.GetAllProductsOnSale(marketPlace);

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
            return marketPlace.ProductList.FirstOrDefault(product => product.Id == id);
        }
    }
}
