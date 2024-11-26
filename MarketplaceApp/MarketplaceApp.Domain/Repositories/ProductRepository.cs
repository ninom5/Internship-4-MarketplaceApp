using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using System.Transactions;

namespace MarketplaceApp.Domain.Repositories
{
    public class ProductRepository
    {
        public static void SetProductOnSale(Product product)
        {
            product.ProductStatus = ProductStatus.Na_prodaji;
        }

        public static List<Product> AllProductsOnSale(Marketplace marketplace)
        {
            return marketplace.ProductList
                .Where(product => product.ProductStatus == Data.Enum.ProductStatus.Na_prodaji).ToList();
        }



    }
}