using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain;
using MarketplaceApp.Domain.DomainEnums;
using MarketplaceApp.Domain.Interfaces;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.ProductActions.PurchaseReturnActions
{
    public class StartPurchase
    {
        public static void StartPurchaseAction(Marketplace marketPlace, Buyer buyer)
        {
            if (Helper.AllProductsOnSale(marketPlace) != Result.Success)
                return;

            Guid id = ReadInput.ReadIdOfProduct();
            Product product = Helper.GetProduct(marketPlace, id);

            if (product == null) return;

            IPromoCodeService promoCodeService = new PromoCodeService();
            ValidatePurchase validatePurchase = new ValidatePurchase(promoCodeService);

            validatePurchase.CreateTransaction(product, buyer, marketPlace, out string message);

            Console.WriteLine(message);
        }
    }
}
