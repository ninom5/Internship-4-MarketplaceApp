using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class MarketPlaceFunctions
    {
        private static MarketPlace marketPlace;
        public static void SetMarketPlace(MarketPlace _marketPlace)
        {
            marketPlace = _marketPlace;
        }

        public static void AddBuyer(Buyer buyer)
        {
            marketPlace.BuyerList.Add(buyer);
            Console.WriteLine("Kupac dodan na listu kupaca");
        }
        public static void AddSeller(Seller seller)
        {
            marketPlace.SellerList.Add(seller);
            Console.WriteLine("Prodavac uspjesno dodan na listu prodavaca");
        }
    }
}
