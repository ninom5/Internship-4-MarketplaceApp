using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.LoginRegister.Login
{
    public class LoginClass
    {
        public static void Login(Marketplace marketPlace)
        {
            Console.WriteLine("Unesite email s kojim se zelite prijaviti");
            var email = Console.ReadLine();

            CheckEmail(email, marketPlace);
        }
        private static void CheckEmail(string email, Marketplace marketPlace)
        {
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Ne ispravan unos\n");
                CheckEmail(email, marketPlace);
                return;
            }

            UserRepository userRepository = new UserRepository();

            var user = userRepository.FindUser(email, marketPlace);

            if (user == null)
            {
                Console.WriteLine("Korisnik s tim emailom nije pronaden");
                return;
            }

            if (user is Buyer buyer)
            {
                Console.Clear();
                Console.WriteLine($"Dobro dosli, {user.Name}, {user.UserType()}");
                BuyerMenu.ShowBuyerOptions(buyer, marketPlace);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Dobro dosli, {user.Name}, {user.UserType()}");
                
            }
        }
    }
}
