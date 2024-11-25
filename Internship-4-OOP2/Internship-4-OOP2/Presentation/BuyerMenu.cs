using Internship_4_OOP2.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Presentation
{
    public class BuyerMenu
    {
        public static void ShowBuyerOptions(Buyer buyer, MarketPlace marketPlace)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Pregled svih dostupnih proizvoda \n2.Kupnja proizvoda s ID \n3.Povratak kupljenog proizvoda \n4.Dodavanje proizvoda u listu omiljenih \n5.Pregled povijesti kupljenih dogadaja \n6.Pregled liste omiljenih proizvoda");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        ProductFunctions.ShowAllProductsOnSale(marketPlace);
                        return;
                    case '2':
                        ProductFunctions.ShowAllProductsOnSale(marketPlace);
                        ProductFunctions.PickProduct(marketPlace, buyer);
                        return;
                    case '3':
                        ProductFunctions.ReturnProduct(marketPlace, buyer);
                        return;
                }
            }
        }
    }
}