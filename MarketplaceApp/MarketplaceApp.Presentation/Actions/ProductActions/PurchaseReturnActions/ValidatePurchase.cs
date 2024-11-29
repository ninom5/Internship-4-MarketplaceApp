using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain;
using MarketplaceApp.Domain.Interfaces;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Utility;
namespace MarketplaceApp.Presentation.Actions.ProductActions.PurchaseReturnActions
{
    public class ValidatePurchase
    {
        public IPromoCodeService PromoCodeService { get; set; }
        public ValidatePurchase(IPromoCodeService promoCodeService)
        {
            PromoCodeService = promoCodeService;
        }
        public void CreateTransaction(Product product, Buyer buyer, Marketplace marketplace, out string message)
        {
            PromoCodes promoCodes = null;
            double priceOfProduct = product.Price;

            if (product.ProductStatus != Data.Enum.ProductStatus.Na_prodaji)
            {
                message = "Proizvod je vec kupljen";
                return;
            }

            var promoCode = ReadInput.ReadPromoCode();
            if (!string.IsNullOrEmpty(promoCode))
            {
                promoCodes = PromoCodeService.GetPromoCode(marketplace, promoCode);

                if (promoCodes == null || !PromoCodeService.IsValidPromoCode(promoCodes, product))
                    Console.WriteLine("Promo kod nije valjan");
                else
                {
                    priceOfProduct = product.Price * (1 - promoCodes.Discount);
                    Console.WriteLine($"popust od {promoCodes.Discount * 100} posto primjenjen, nova cijena proizvoda: {Math.Round(priceOfProduct, 2)}");
                }
            }

            if (buyer.Amount < priceOfProduct)
            {
                message = "Nemate dovoljno para na racunu";
                return;
            }

            if (!ConfirmAction.Confirm($"Zelite li kupiti proizvod {product.Name} y/n?"))
            {
                message = "Odustali ste od kupnje proizvoda";
                return;
            }

            if (TransactionRepository.FinishTransaction(marketplace, product, buyer, promoCodes) != Domain.DomainEnums.Result.Success)
            {
                message = "pogreska pri izvrsavanju kupnje";
                return;
            }

            message = $"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {Math.Round(priceOfProduct, 2)}";
        }
    }
}
