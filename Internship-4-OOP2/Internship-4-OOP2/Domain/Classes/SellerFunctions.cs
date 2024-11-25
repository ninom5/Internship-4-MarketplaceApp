using Internship_4_OOP2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class SellerFunctions
    {
        public static Seller SellerRegistration(MarketPlace marketPlace)
        {
            var user = UserFunctions.UserDetail();
            Console.WriteLine($"Uspjesno registriran novi prodavac, ime: {user.Name}, email: {user.Email}\n");
            if (UtilityFunctions.DoesEmailExists(user.Email, marketPlace))
            {
                Console.WriteLine("Uneseni email vec postoji");
                return null;
            }
            return new Seller(user.Name, user.Email);
        }
        public static void SubstractAmountSeller(Seller seller, double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("iznos ne moze biti negativan");
                return;
            }

            seller.SetNewEarnings(-amount);
        }
        public static void AddAmountSeller(Seller seller, double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("iznos ne moze biti negativan");
                return;
            }
            seller.SetNewEarnings(amount);
        }
    }
}
