using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation
{
    public class ReadInput
    {
        public static string ReadName()
        {
            string name = "";
            Console.WriteLine("Unesite ime:");
            
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Ne ispravan unos");
                    continue;
                }

                return name;
            }
        }
        public static string ReadEmail()
        {
            while(true)
            {
                Console.WriteLine("Unesite email");
                string email = Console.ReadLine();

                if (IsEmailValid(email))
                {
                    return email;
                }
                else
                    Console.WriteLine("Ne ispravan unos, unesite opet");
            }
        }
        private static bool IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            var indexOfAt = email.IndexOf('@');
            var indexOfDot = email.IndexOf('.');

            return indexOfAt > 0 && indexOfAt + 1 < indexOfDot && indexOfDot < email.Length - 1;
        }

        public static double ReadAmount()
        {
            while (true)
            {
                double balance = 0.0;
                Console.WriteLine("Unesite pocetni iznos");

                if (!double.TryParse(Console.ReadLine(), out balance) || balance < 0)
                {
                    Console.WriteLine("Ne ispravan unos, unesite opet");
                    continue;
                }
            }
        }
    }
}
