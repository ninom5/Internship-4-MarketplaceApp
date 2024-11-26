using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Presentation.Utility;

namespace MarketplaceApp.Presentation.Menu
{
    public class BuyerMenu
    {
        public static void ShowBuyerOptions(Buyer buyer, Marketplace marketPlace)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Pregled svih dostupnih proizvoda \n2.Kupnja proizvoda s ID \n3.Povratak kupljenog proizvoda \n4.Dodavanje proizvoda u listu omiljenih \n5.Pregled povijesti kupljenih dogadaja \n6.Pregled liste omiljenih proizvoda");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        Helper.ShowAllProductsOnSale(marketPlace);
                        return;
                    case '2':
                        Helper.ShowAllProductsOnSale(marketPlace);
                        Guid id = ReadInput.EnterIdOfProduct();
                        Product product = Helper.GetProduct(marketPlace, id);

                        if (Helper.CheckIsNull(product))
                            return;

                        TransactionRepository transactionRepository = new TransactionRepository();
                        transactionRepository.CreateTransaction(product, buyer, marketPlace, out string message);

                        Console.WriteLine(message);

                        return;
                    case '3':
                        ProductRepository productRepository = new ProductRepository();
                        productRepository.ReturnProduct(marketPlace, buyer);
                        
                        return;
                    case '4':
                        return;
                }
            }
        }
       
    }
}
