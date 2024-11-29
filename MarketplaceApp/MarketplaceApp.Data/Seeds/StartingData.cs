using MarketplaceApp.Data.Models;
using MarketplaceApp.Data.Seeds.Factory;

namespace MarketplaceApp.Data.Seeds
{
    public class StartingData
    {
        public static void startingSeed(Marketplace marketplace)
        {
            Seller sellerAnte = FactoryList.CreateSeller("Ante", "ante@antic.a");
            Seller sellerMate = FactoryList.CreateSeller("Mate", "m@m.m");

            marketplace.UserList.AddRange(new List<User> { sellerAnte, sellerMate });


            Product productAnte1 = FactoryList.CreateProduct("Kompjuter", "Gaming kompjuter", 1000.00, Enum.Category.Elektronika, sellerAnte);
            Product productAnte2 = FactoryList.CreateProduct("Majica", "Majica kratkih rukava", 24.00, Enum.Category.Odjeca, sellerAnte);
            Product productMate1 = FactoryList.CreateProduct("Laptop", "Lenovo", 649.99, Enum.Category.Elektronika, sellerMate);

            marketplace.ProductList.AddRange(new List<Product> { productAnte1, productAnte2, productMate1 });


            Buyer buyer1 = FactoryList.CreateBuyer("N", "n@n.n", 700);
            Buyer buyer2 = FactoryList.CreateBuyer("A", "a@a.a", 10000);

            marketplace.UserList.AddRange(new List<Buyer> { buyer1, buyer2 });


            PromoCodes promoCode1 = FactoryList.CreatePromoCode(0.20, new DateTime(2025, 11, 7), Enum.Category.Elektronika);
            PromoCodes promoCode2 = FactoryList.CreatePromoCode(0.10, new DateTime(2024, 11, 7), Enum.Category.Odjeca);
            PromoCodes promoCode3 = FactoryList.CreatePromoCode(0.40, new DateTime(2025, 10, 11), Enum.Category.Obuća);

            marketplace.PromoCodesList.AddRange(new List<PromoCodes> { promoCode1, promoCode2, promoCode3 });
        }
    }
}
