using MarketplaceApp.Data.Models;

namespace MarketplaceApp.Data.Seeds
{
    public class StartingData
    {
        public static void startingSeed(Marketplace marketplace)
        {
            Seller sellerAnte = new Seller("Ante", "ante@antic.a");
            marketplace.UserList.Add(sellerAnte);

            Seller sellerMate = new Seller("Mate", "m@m.m");
            marketplace.UserList.Add(sellerMate);

            Product productAnte1 = new Product("Kompjuter", "Gaming kompjuter", 1000.00, Enum.Category.Elektronika, sellerAnte);
            marketplace.ProductList.Add(productAnte1);

            Product productAnte2 = new Product("Majica", "Majica kratkih rukava", 24.00, Enum.Category.Odjeca, sellerAnte);
            marketplace.ProductList.Add(productAnte2);

            Product productMate1 = new Product("Laptop", "Lenovo", 649.99, Enum.Category.Elektronika, sellerMate);
            marketplace.ProductList.Add(productMate1);

            Buyer buyer1 = new Buyer("N", "n@n.n", 700);
            marketplace.UserList.Add(buyer1);

            Buyer buyer2 = new Buyer("A", "a@a.a", 10000);
            marketplace.UserList.Add(buyer2);
        }
    }
}
