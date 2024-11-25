using Internship_4_OOP2.Domain.Classes;
using Internship_4_OOP2.Presentation;

namespace Internship_4_OOP2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MarketPlace marketPlace = new MarketPlace();
            MarketPlaceFunctions.SetMarketPlace(marketPlace);

            Seller sellerAnte = new Seller("ante", "ante@antic.a");
            marketPlace.SellerList.Add(sellerAnte);

            Seller sellerMate = new Seller("Mate", "m@m.m");
            marketPlace.SellerList.Add(sellerMate);

            Product productAnte1 = new Product("kompjuter", "gaming kompjuter", 1000.00, Data.Category.Elektronika, sellerAnte);
            marketPlace.ProductList.Add(productAnte1);
            Product productAnte2 = new Product("majica", "majica kratkih rukava", 24.00, Data.Category.Odjeca, sellerAnte);
            marketPlace.ProductList.Add(productAnte2);

            Product productMate1 = new Product("laptop", "Lenovo", 649.99, Data.Category.Elektronika, sellerMate);
            marketPlace.ProductList.Add(productMate1);

            Buyer buyer1 = new Buyer("n", "n@n.n", 120);
            marketPlace.BuyerList.Add(buyer1);


            MainMenu.ShowMainMenu(marketPlace);
        }
    }
}