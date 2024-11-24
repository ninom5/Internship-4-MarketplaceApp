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
        public static Buyer BuyerRegistration()
        {
            bool isValid = false;
            var user = UserFunctions.UserDetail();
            double balance = 0.0;
            while(!isValid)
            {
                Console.WriteLine("Unesite pocetni iznos");
                if(!double.TryParse(Console.ReadLine(), out balance))
                    Console.WriteLine("Ne ispravan unos, unesite opet");
                else
                {
                    Console.WriteLine("Uspjesno registriran novi kupac");
                    isValid = true;
                }
            }
            return new Buyer(user.Name, user.Email, balance);
        }
    }
}
