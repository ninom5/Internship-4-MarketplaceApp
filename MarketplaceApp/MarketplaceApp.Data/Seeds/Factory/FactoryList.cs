using MarketplaceApp.Data.Models;

namespace MarketplaceApp.Data.Seeds.Factory
{
    public class FactoryList
    {
        public static Seller CreateSeller(string name, string email) => new Seller(name, email);
        public static Buyer CreateBuyer(string name, string email, double balance) => new Buyer(name, email, balance);
        public static Product CreateProduct(string name, string description, double price, Enum.Category category, Seller seller)
            => new Product(name, description, price, category, seller);

        public static PromoCodes CreatePromoCode(double discount, DateTime expiryDate, Enum.Category category)
            => new PromoCodes(discount, expiryDate, category);
    }
}
