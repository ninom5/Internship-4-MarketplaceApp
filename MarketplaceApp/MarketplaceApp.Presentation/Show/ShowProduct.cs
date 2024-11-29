using MarketplaceApp.Data.Models;

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
                Console.WriteLine($"Ime proizvoda: {product.Name}, opis proizvoda: {product.Description}, id proizvoda: {product.Id}, cijena: {product.Price}, status proizvoda: {product.ProductStatus}, kategorija: {product.ProductType}, prodavac: {product.Seller.Name}, ocjena: {product.Rating}");
            }

            return true;
        }
    }
}
