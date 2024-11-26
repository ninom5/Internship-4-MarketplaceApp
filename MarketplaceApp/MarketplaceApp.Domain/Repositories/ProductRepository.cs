using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;

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

        public static List<Product> BuyerProducts(Marketplace marketPlace, Buyer buyer)
        {
            return marketPlace.TransactionsList
                .Where(buyerFromList => buyerFromList.Buyer == buyer)
                .Select(product => product.Product).ToList();
        }
        public static List<Product> BuyerProducts(Buyer buyer)
        {
            return buyer.FavouriteProductsList;
        }
        public static void AddProductToFavourite(Buyer buyer, Product product)
        {
            buyer.FavouriteProductsList.Add(product);
        }
        public static DomainEnums.Result AddNewProduct(Marketplace marketplace, Product product)
        {
            try
            {
                marketplace.ProductList.Add(product);
            }
            catch (Exception ex)
            {
                return Result.Failed;
            }
            return Result.Success;
        }
    }
}