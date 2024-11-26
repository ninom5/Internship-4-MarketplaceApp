 using MarketplaceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Domain.NewFolder
{
    public class ReadInput
    {
        public static string ReadName()
        {
            while (true)
            {
                Console.WriteLine("Unesite ime:");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
                {
                    Console.WriteLine("Ne ispravan unos");
                    continue;
                }

                return name;
            }
        }
        public static string ReadEmail()
        {
            while (true)
            {
                Console.WriteLine("Unesite email");
                var email = Console.ReadLine();

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
                return balance;
            }
        }
        public static Guid EnterIdOfProduct()
        {
            while (true)
            {
                Console.WriteLine("Unesite id proizvoda");
                var id = Console.ReadLine();

                if (!Guid.TryParse(id, out var productId))
                {
                    Console.WriteLine("Ne ispravan unos");
                    continue;
                }

                return productId;
            }
        }
    }
}