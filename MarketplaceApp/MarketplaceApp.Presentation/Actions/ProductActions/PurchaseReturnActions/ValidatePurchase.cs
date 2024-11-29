using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Utility;
namespace MarketplaceApp.Presentation.Actions.ProductActions.PurchaseReturnActions
{
    public class ValidatePurchase
    {
        public void CreateTransaction(Product product, Buyer buyer, Marketplace marketplace, out string message)
        {
            PromoCodes promoCodes = null;

            if (product.ProductStatus != Data.Enum.ProductStatus.Na_prodaji)
            {
                message = "Proizvod je vec kupljen";
                return;
            }

            if (buyer.Amount < product.Price)
            {
                message = "Nemate dovoljno para na racunu";
                return;
            }
            
            var promoCode = ReadInput.ReadPromoCode();
            if (!string.IsNullOrEmpty(promoCode))
            {
                promoCodes = Helper.GetPromoCode(marketplace, promoCode);
                if(promoCodes == null || promoCodes.Category != product.ProductType || DateTime.Now > promoCodes.ValidUntil)
                    Console.WriteLine("Promo kod nije valjan");
                else
                    Console.WriteLine($"popust od {promoCodes.Discount * 100} posto primjenjen");
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

            double price = promoCodes == null ? product.Price : product.Price * (1 - promoCodes.Discount);

            message = $"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {Math.Round(price, 2)}";
        }
    }
}
