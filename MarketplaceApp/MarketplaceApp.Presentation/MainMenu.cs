using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;

namespace MarketplaceApp.Presentation
{
    public class MainMenu
    {
        public void ShowMainMenu(Marketplace marketPlace)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n1.Registracija korisnika \n2.Prijava korisnika \n3.Transakcije \n0 - izlaz iz programa");
                char option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':
                        //PickTypeOfUser(marketPlace);
                        break;
                    case '2':
                        //Login(marketPlace);
                        break;
                    case '3':
                        //ShowAllTransactions(marketPlace);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("\nne ispravan unos, unesite opet");
                        break;
                }
            }
        }
        public void PickTypeOfUser(Marketplace marketPlace)
        {
            Console.Clear();

            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Registracija kupca \n2. Registracija prodavaca");
                char userOption = Console.ReadKey().KeyChar;

                switch (userOption)
                {
                    case '1':
                        RegisterBuyer(marketPlace);
                        break;
                    case '2':
                        RegisterSeller(marketPlace);
                        break;
                    default:
                        Console.WriteLine("ne ispravan unos");
                        break;
                }
            }
        }
        private void RegisterBuyer(Marketplace marketplace)
        {
            UserRepository userRepository = new UserRepository();
            var user = GetNameAndEmail(marketplace, userRepository);

            double balance = ReadInput.ReadAmount();
            
            userRepository.AddUser(marketplace, user.name, user.email, balance);

            Console.WriteLine("Kupac uspjesno registriran");
        }

        private void RegisterSeller(Marketplace marketplace)
        {
            UserRepository userRepository = new UserRepository();
            var user = GetNameAndEmail(marketplace, userRepository);
            
            userRepository.AddUser(marketplace, user.name, user.email);

            Console.WriteLine("Prodavac uspjesno registriran");
        }
        private (string name, string email) GetNameAndEmail(Marketplace marketplace, UserRepository userRepository)
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.Clear();
                string name = ReadInput.ReadName();

                string email = ReadInput.ReadEmail();

                if (userRepository.DoesEmailExist(marketplace, email))
                {
                    Console.WriteLine("uneseni email vec postoji, unesite opet");
                    continue;
                }
                return (name, email);
            }
            return ("", "");
        }
    }
}