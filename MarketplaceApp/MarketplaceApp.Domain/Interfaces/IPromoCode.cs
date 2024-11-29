using MarketplaceApp.Data.Models;

namespace MarketplaceApp.Domain.Interfaces
{
    public interface IPromoCodeService
    {
        PromoCodes GetPromoCode(Marketplace marketplace, string promoCode);
        bool IsValidPromoCode(PromoCodes promoCode, Product product);
    }
}
