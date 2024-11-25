using Internship_4_OOP2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class BuyerFunctions
    {
        public static Buyer BuyerRegistration(MarketPlace marketPlace)
        {
            bool isValid = false;
            var user = UserFunctions.UserDetail();
            if (UtilityFunctions.DoesEmailExists(user.Email, marketPlace))
            {
                Console.WriteLine("Uneseni email vec postoji");
                return null;
            }
            double balance = 0.0;
            while (!isValid)
            {
                Console.WriteLine("Unesite pocetni iznos");
                if (!double.TryParse(Console.ReadLine(), out balance) || balance < 0)
                    Console.WriteLine("Ne ispravan unos, unesite opet");
                else
                {
                    //Console.WriteLine("Uspjesno registriran novi kupac");
                    isValid = true;
                }
            }
            Console.WriteLine($"Uspjesno registriran novi kupac, ime: {user.Name}, email: {user.Email}, pocetni iznos: {balance}\n");
            return new Buyer(user.Name, user.Email, balance);
        }
        public static void SubstractAmountBuyer(Buyer buyer, double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("iznos ne moze biti negativan");
                return;
            }

            buyer.SetNewAmount(-amount);
        }
        public static void AddAmountBuyer(Buyer buyer, double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("iznos ne moze biti negativan");
                return;
            }
            buyer.SetNewAmount(amount);
        }
    }
}