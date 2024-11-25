using Internship_4_OOP2.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Presentation
{
    public class SellerMenu
    {
        public static void ShowSellerOptions(Seller seller, MarketPlace marketPlace)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1.Dodavanje proizvoda \n2.Pregled svih proizvoda odabranog prodavaca \n3.Pregled ukupno zarade od prodaje \n4.Pregled prodanih proizvoda po kategoriji \n5.Pregled zarade u odredenom vrem razdoblju");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        ProductFunctions.CreateNewProduct(seller);
                        return;
                    case '2':
                        ProductFunctions.ShowAllProductsBySeller(seller, marketPlace);
                        return;
                }
            }
        }
    }
}