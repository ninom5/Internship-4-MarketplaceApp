using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;

namespace MarketplaceApp.Domain.Repositories
{
    public class ProductRepository
    {
        public void SetProductOnSale(Product product)
        {
            product.ProductStatus = ProductStatus.Na_prodaji;
        }

        public List<Product> GetAllProductsOnSale(Marketplace marketplace)
        {
            return marketplace.ProductList
                .Where(product => product.ProductStatus == Data.Enum.ProductStatus.Na_prodaji).ToList();
        }

        public static List<Product> BuyerProducts(Buyer buyer, Marketplace? marketPlace = null)
        {
            if(marketPlace == null)
                return buyer.FavouriteProductsList;

            return marketPlace.TransactionsList
                .Where(buyerFromList => buyerFromList.Buyer == buyer)
                .Select(product => product.Product).ToList();
        }
        public List<Product> SellerProducts(Marketplace marketplace, Seller seller, Category? category = null)
        {
            var products = marketplace.ProductList.Where(product => product.Seller == seller);

            if (category.HasValue)
                products = products.Where(product => product.ProductType == category && product.ProductStatus == ProductStatus.Prodano);

            return products.ToList();
        }

        public static void AddProductToFavourite(Buyer buyer, Product product)
        {
            buyer.FavouriteProductsList.Add(product);
        }
        public static DomainEnums.Result AddNewProduct(Marketplace marketplace, Product product)
        {
            marketplace.ProductList.Add(product);
            
            return Result.Success;
        }
    }
}