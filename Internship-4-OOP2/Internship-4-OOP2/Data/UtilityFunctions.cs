using Internship_4_OOP2.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Internship_4_OOP2.Presentation;
namespace Internship_4_OOP2.Data
{
    public class UtilityFunctions
    {
        public static bool IsEmailValid(string email)
        {
            if(string.IsNullOrEmpty(email)) return false;
            var indexOfAt = email.IndexOf('@');
            var indexOfDot = email.IndexOf('.');

            return indexOfAt > 0 && indexOfAt + 1 < indexOfDot && indexOfDot < email.Length - 1;
        }
        public static void PickTypeOfUser(MarketPlace marketPlace)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Registracija kupca \n2. Registracija prodavaca");
                char userOption = Console.ReadKey().KeyChar;
                switch (userOption)
                {
                    case '1':
                        Buyer newBuyer = BuyerFunctions.BuyerRegistration(marketPlace);
                        if(newBuyer == null)
                        {
                            Console.WriteLine("prekinuta registracija novog kupca");
                            return;
                        }
                        isValid = true;
                        MarketPlaceFunctions.AddBuyer(newBuyer);
                        break;
                    case '2':
                        Seller newSeller = SellerFunctions.SellerRegistration(marketPlace);
                        if (newSeller == null)
                        {
                            Console.WriteLine("prekinuta registracija novog prodavaca");
                            return;
                        }
                        isValid = true;
                        MarketPlaceFunctions.AddSeller(newSeller);
                        break;
                }
            }
        }
        public static void Login(MarketPlace marketPlace)
        {
            Console.WriteLine("Unesite email s kojim se zelite prijaviti");
            var email = Console.ReadLine();
            CheckEmail(email, marketPlace);
        }
        private static void CheckEmail(string email, MarketPlace marketPlace)
        {
            if(string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Uneseni email nije poronaden\n");
                return;
            }
            
            Buyer buyer = CheckIsBuyer(email, marketPlace);
            if (buyer != null)
            {
                BuyerMenu.ShowBuyerOptions(buyer, marketPlace);
                return;
            }
            
            Seller seller = CheckIsSeller(email, marketPlace);
            if (seller != null)
            {
                SellerMenu.ShowSellerOptions(seller, marketPlace);
                return;
            }

            Console.WriteLine("Korisnik s tim emailom nije pronaden");
        }
        private static Buyer CheckIsBuyer(string email, MarketPlace marketPlace)
        {
            foreach(var buyer in marketPlace.BuyerList)
            {
                if (buyer.Email == email)
                {
                    return buyer;
                }
            }
            return null;
        }
        public static Buyer GetBuyer(string email, MarketPlace marketPlace)
        {
            return CheckIsBuyer(email, marketPlace);
        }
        private static Seller CheckIsSeller(string email, MarketPlace marketPlace)
        {
            foreach (var seller in marketPlace.SellerList)
            {
                if (seller.Email == email)
                {
                    return seller;
                }
            }
            return null;
        }
        public static bool DoesEmailExists(string email, MarketPlace marketPlace)
        {
            if (CheckIsBuyer(email, marketPlace) != null)
                return true;
            if(CheckIsSeller(email,marketPlace) != null)
                return true;

            return false;
        }

        public static void ShowBuyerProducts(MarketPlace marketplace, Buyer buyer, List<Transaction> boughtProducts)
        {
            if(!boughtProducts.Any())
            {
                Console.WriteLine("Nema proizvoda, unesite 0 za prekid");
                return; 
            }
            foreach(var transaction in boughtProducts)
            {
                Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, kupac: {transaction.Buyer.Name}, " +
                    $"prodavac: {transaction.Seller.Name}, datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, kategorija proizvoda: {transaction.ProductType}");
            }
        }
        public static Data.Category ChooseCategory()
        {
            while (true)
            {
                Console.WriteLine("Odaberite kategoriju: \n\t1.Elektronika \n\t2.Odjeca \n\t3.Knjige \n\t4.Obuca");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        return Category.Elektronika;
                    case '2':
                        return Category.Odjeca;
                    case '3':
                        return Category.Knjige;
                    case '4':
                        return Category.Obuća;
                    default:
                        Console.WriteLine("Ne ispravan unos");
                        break;
                }
            }
        }
    }
}