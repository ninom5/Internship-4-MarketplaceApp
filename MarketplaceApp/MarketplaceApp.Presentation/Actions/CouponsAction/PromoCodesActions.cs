
using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain;
using MarketplaceApp.Domain.NewFolder;

namespace MarketplaceApp.Presentation.Actions.PromoCodesAction
{
    public class PromoCodesActions
    {
        public void CreateCoupon(Marketplace marketplace)
        {
            var name = ReadInput.ReadName();
            var discount = ReadInput.ReadDiscount();
            DateTime validUntil = ReadInput.ReadDate("krajnji");
            Category category = ReadInput.ReadCategory();
            PromoCodeService codeService = new PromoCodeService();
            codeService.AddCoupon(marketplace, name, discount, validUntil, category);
        }
    }
}
