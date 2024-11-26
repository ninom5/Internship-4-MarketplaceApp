using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.DomainEnums;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.PurchaseReturnActions
{
    public class StartPurchase
    {
        public static void StartPurchaseAction(Marketplace marketPlace, Buyer buyer)
        {
            if (Helper.ShowAllProductsOnSale(marketPlace) != Result.Success)
                return;
            Guid id = ReadInput.EnterIdOfProduct();
            Product product = Helper.GetProduct(marketPlace, id);
            if (Helper.CheckIsNull(product))
                return;

            ValidatePurchase validatePurchase = new ValidatePurchase();
            validatePurchase.CreateTransaction(product, buyer, marketPlace, out string message);

            Console.WriteLine(message);
        }
    }
}
