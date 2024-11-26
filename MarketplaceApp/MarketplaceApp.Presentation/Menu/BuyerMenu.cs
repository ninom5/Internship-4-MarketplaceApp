using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Presentation.Utility;
using MarketplaceApp.Presentation.FinishPurchase;
using MarketplaceApp.Domain.DomainEnums;
using MarketplaceApp.Presentation.PurchaseReturnActions;

namespace MarketplaceApp.Presentation.Menu
{
    public class BuyerMenu
    {
        public static void ShowBuyerOptions(Buyer buyer, Marketplace marketPlace)
        {
            Console.Clear();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Pregled svih dostupnih proizvoda \n2.Kupnja proizvoda s ID \n3.Povratak kupljenog proizvoda \n4.Dodavanje proizvoda u listu omiljenih \n5.Pregled povijesti kupljenih dogadaja " +
                    "\n6.Pregled liste omiljenih proizvoda \n\n0.Povratak na glavni izbornik");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        Helper.ShowAllProductsOnSale(marketPlace);
                        return;
                    case '2':
                        if (Helper.ShowAllProductsOnSale(marketPlace) != Result.Success)
                            return;
                        Guid id = ReadInput.EnterIdOfProduct();
                        Product product = Helper.GetProduct(marketPlace, id);

                        if (Helper.CheckIsNull(product))
                            return;

                        ValidatePurchase validatePurchase = new ValidatePurchase();
                        validatePurchase.CreateTransaction(product, buyer, marketPlace, out string message);

                        Console.WriteLine(message);

                        return;
                    case '3':
                        ReturnAction action = new ReturnAction();
                        action.ReturnProduct(marketPlace, buyer);
                        return;
                    case '4':  
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
