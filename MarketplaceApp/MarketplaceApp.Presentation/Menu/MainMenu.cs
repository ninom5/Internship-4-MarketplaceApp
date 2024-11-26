using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.LoginRegister.Login;
using MarketplaceApp.Presentation.LoginRegister.Register;

namespace MarketplaceApp.Presentation.Menu
{
    public class MainMenu
    {
        public void ShowMainMenu(Marketplace marketPlace)
        {
            while (true)
            {
                //Thread.Sleep(1000);
                //Console.Clear();

                Console.WriteLine("\n1.Registracija korisnika \n2.Prijava korisnika \n3.Transakcije \n0 - izlaz iz programa");
                char option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case '1':
                        Console.Clear();
                        PickTypeOfUser(marketPlace);
                        break;
                    case '2':
                        Console.Clear();
                        LoginClass.Login(marketPlace);
                        break;
                    case '3':
                        Console.Clear();
                        TransactionMenu.ShowAllTransactions(marketPlace);
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
            RegisterClass register = new RegisterClass();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Registracija kupca \n2. Registracija prodavaca");
                char userOption = Console.ReadKey().KeyChar;

                switch (userOption)
                {
                    case '1':
                        register.RegisterBuyer(marketPlace);
                        return;
                    case '2':
                        register.RegisterSeller(marketPlace);
                        return;
                    default:
                        Console.WriteLine("ne ispravan unos");
                        break;
                }
            }
        }
    }
}