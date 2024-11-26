using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Utility;
using MarketplaceApp.Presentation.Actions.PurchaseReturnActions;
using MarketplaceApp.Presentation.Actions.Favourites;

namespace MarketplaceApp.Presentation.Menu
{
    public class BuyerMenu
    {
        public static void ShowBuyerOptions(Buyer buyer, Marketplace marketPlace)
        {
            Thread.Sleep(2000);
            Console.Clear();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Pregled svih dostupnih proizvoda \n2.Kupnja proizvoda s ID \n3.Povratak kupljenog proizvoda \n4.Dodavanje proizvoda u listu omiljenih \n5.Pregled povijesti kupljenih proizvoda " +
                    "\n6.Pregled liste omiljenih proizvoda \n\n0.Povratak na glavni izbornik");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        Helper.ShowAllProductsOnSale(marketPlace);
                        return;
                    case '2':
                        StartPurchase.StartPurchaseAction(marketPlace, buyer);
                        return;
                    case '3':
                        ReturnAction action = new ReturnAction();
                        action.ReturnProduct(marketPlace, buyer);
                        return;
                    case '4':  
                        FavouriteProduct favourite = new FavouriteProduct();
                        favourite.StartNewFavoriteAction(marketPlace, buyer);
                        return;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("\nne ispravan unos");
                        break;
                }
            }
        }
    }
}
