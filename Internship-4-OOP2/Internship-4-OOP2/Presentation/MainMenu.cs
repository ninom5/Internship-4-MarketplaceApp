using Internship_4_OOP2.Data;
using Internship_4_OOP2.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Presentation
{
    public static class MainMenu
    {
        public static void ShowMainMenu(MarketPlace marketPlace)
        {
            while (true)
            {
                Console.WriteLine("\n1.Registracija korisnika \n2.Prijava korisnika \n3.Transakcije \n0 - izlaz iz programa");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        UtilityFunctions.PickTypeOfUser(marketPlace);
                        break;
                    case '2':
                        UtilityFunctions.Login(marketPlace);
                        break;
                    case '3':
                        TransactionFunctions.ShowAllTransactions(marketPlace);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("\nne ispravan unos, unesite opet");
                        break;
                }
            }
        }
    }
}
