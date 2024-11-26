using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.Favourites
{
    public class FavouriteProduct
    {
        public void StartNewFavoriteAction(Marketplace marketPlace, Buyer buyer)
        {
            var listOfBoughtProducts = ProductRepository.BuyerProducts(marketPlace, buyer);
            if (!ShowProduct.PrintProducts(listOfBoughtProducts))
                return;

            Console.WriteLine("Unesite id proizvoda kojeg zelite dodati u omiljene");
            var id = ReadInput.EnterIdOfProduct();

            foreach(var product in listOfBoughtProducts)
            {
                if(product.Id == id)
                {
                    buyer.FavouriteProductsList.Add(product);
                }
            }
        }
    }
}
