using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Utility;
namespace MarketplaceApp.Presentation.FinishPurchase
{
    public class ValidatePurchase
    {
        public void CreateTransaction(Product product, Buyer buyer, Marketplace marketplace, out string message)
        {
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

            if (!ConfirmAction.Confirm(product))
            {
                message = "Odustali ste od kupnje proizvoda";
                return;
            }

            if (TransactionRepository.FinishTransaction(marketplace, product, buyer) != Domain.DomainEnums.Result.Success)
            {
                message = "pogreska pri izvrsavanju kupnje";
                return;
            }

            message = $"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {product.Price}";
        }
    }
}
