using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Show;
using MarketplaceApp.Presentation.Utility;

namespace MarketplaceApp.Presentation.Actions.Favourites
{
    public class FavouriteProduct
    {
        public void StartNewFavoriteAction(Marketplace marketPlace, Buyer buyer)
        {
            Helper.ShowAllProductsOnSale(marketPlace);
            //ShowProduct.PrintProducts(marketPlace.ProductList);

            Console.WriteLine("\nUnesite id proizvoda kojeg zelite dodati u omiljene");
            var id = ReadInput.EnterIdOfProduct();

            Product product = Helper.GetProduct(marketPlace, id);
            if(Helper.CheckIsNull(product) || product.ProductStatus == ProductStatus.Prodano)
            {
                Console.WriteLine("Proizvod nije pronaden");
                return;
            }

            if (buyer.FavouriteProductsList.Contains(product))
            {
                Console.WriteLine("\nProizvod je vec u omiljenim proizvodima\n");
                return;
            }

            ProductRepository.AddProductToFavourite(buyer, product);
            Console.WriteLine("Proizvod uspjesno dodan u omiljene");
        }

        public static void ShowFavouriteProducts(Buyer buyer)
        {
            var listOfFavourites = ProductRepository.BuyerProducts(buyer);

            if(!listOfFavourites.Any())
            {
                Console.WriteLine("Nema omiljenih proizvoda");
                return;
            }

            Console.WriteLine("\nOmiljeni proizvodi:");
            ShowProduct.PrintProducts(listOfFavourites);
        }
    }
}
