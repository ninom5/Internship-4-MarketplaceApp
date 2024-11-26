using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Actions.NewProduct;
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
            while (true)
            {
                Console.WriteLine("1.Dodavanje proizvoda \n2.Pregled svih proizvoda odabranog prodavaca \n3.Pregled ukupno zarade od prodaje \n4.Pregled prodanih proizvoda po kategoriji " +
                    "\n5.Pregled zarade u odredenom vrem razdoblju \n0.Glavni izbornik");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        CreateProductAction createProductAction = new CreateProductAction();
                        createProductAction.GetProductData(marketPlace, seller);
                        return;
                    case '2':
                        //ProductFunctions.ShowAllProductsBySeller(seller, marketPlace);
                        return;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("ne ispravan unos");
                        break;
                }
            }
        }
    }
}
