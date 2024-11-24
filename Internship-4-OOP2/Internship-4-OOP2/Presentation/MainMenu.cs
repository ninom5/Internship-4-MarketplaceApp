using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Presentation
{
    public static class MainMenu
    {
        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1.Registracija korisnika \n2.Prijava korisnika \n3.Opcije za kupca \n4.Opcije za prodavače \n5.Transakcije \n0 - izlaz iz programa");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
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
