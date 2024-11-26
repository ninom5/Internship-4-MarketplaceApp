using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;

namespace MarketplaceApp.Presentation.FinishPurchase
{
    public class ValidatePurchase
    {
        public void CreateTransaction(Product product, Buyer buyer, Marketplace marketplace, out string message)
        {
            if (buyer.Amount < product.Price)
            {
                message = "Nemate dovoljno para na racunu";
                return;
            }

            if (product.ProductStatus != Data.Enum.ProductStatus.Na_prodaji)
            {
                message = "Proizvod je vec kupljen";
                return;
            }

            if(TransactionRepository.FinishTransaction(marketplace, product, buyer) != Domain.DomainEnums.Result.Success)
            {
                message = "pogreska pri izvrsavanju kupnje";
                return;
            }

            message = $"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {product.Price}";
        }
    }
}
