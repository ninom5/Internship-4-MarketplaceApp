using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Actions.NewProduct;
using MarketplaceApp.Presentation.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Menu
{
    public class SellerMenu
    {
        public static void ShowSellerOptions(Seller seller, Marketplace marketPlace)
        {
            ProductRepository repository = new ProductRepository();
            while (true)
            {
                Console.WriteLine("1.Dodavanje proizvoda \n2.Pregled svih proizvoda odabranog prodavaca \n3.Pregled ukupne zarade od prodaje \n4.Pregled prodanih proizvoda po kategoriji " +
                    "\n5.Pregled zarade u odredenom vrem razdoblju \n0.Glavni izbornik");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        CreateProductAction createProductAction = new CreateProductAction();
                        createProductAction.GetProductData(marketPlace, seller);
                        return;
                    case '2':
                        var listOfSellerProducts = repository.SellerProducts(marketPlace, seller);
                        ShowProduct.PrintProducts(listOfSellerProducts);
                        return;
                    case '3':
                        Console.WriteLine($"Trenutna vasa zarada: {Math.Round(seller.Earnings, 2)}");
                        return;
                    case '4':
                        Category category = ReadInput.ReadCategory();
                        var sellerSoldProductsCategorically = repository.SellerProducts(marketPlace, seller, category);
                        ShowProduct.PrintProducts(sellerSoldProductsCategorically);
                        return;
                    default:
                        Console.WriteLine("ne ispravan unos");
                        break;
                }
            }
        }
    }
}
