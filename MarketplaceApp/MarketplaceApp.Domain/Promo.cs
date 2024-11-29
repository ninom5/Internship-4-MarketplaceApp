using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Interfaces;


namespace MarketplaceApp.Domain
{
    public class PromoCodeService : IPromoCodeService
    {
        public PromoCodes GetPromoCode(Marketplace marketplace, string promoCode)
        {
            return marketplace.PromoCodesList
                .FirstOrDefault(p => p.Name.Equals(promoCode, StringComparison.OrdinalIgnoreCase));
        }
        public bool IsValidPromoCode(PromoCodes promoCode, Product product)
        {
            return promoCode != null && promoCode.Category == product.ProductType && DateTime.Now <= promoCode.ValidUntil;
        }
        public void AddCoupon(Marketplace marketPlace, string name, double discount, DateTime validUntil, Category category)
        {
            PromoCodes promoCodes = new PromoCodes(name, discount, validUntil, category);

            marketPlace.PromoCodesList.Add(promoCodes);
        }
    }
}
