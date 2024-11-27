
using MarketplaceApp.Data.Enum;

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
        public static Guid ReadIdOfProduct()
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
        public static string ReadProductName()
        {
            while (true)
            {
                Console.WriteLine("Unesite naziv proizvoda:");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Ne ispravan unos");
                    continue;
                }

                return name;
            }
        }
        public static string ReadProductDescription()
        {
            while (true)
            {
                Console.WriteLine("Unesite opis proizvoda:");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Ne ispravan unos, opis ne moze biti prazan");
                    continue;
                }

                return name;
            }
        }
        public static double ReadPrice()
        {
            while (true)
            {
                Console.WriteLine("Unesite cijenu proizvoda");
                double price;
                if (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                {
                    Console.WriteLine("ne ispravan unos");
                    continue;
                }
                return price;
            }
        }
        public static DateTime ReadDate(string messageDate)
        {
            Console.WriteLine($"Unesite {messageDate} datum(format: dd/MM/yyyy)");
            DateTime userDate;

            while (true)
            {
                var date = Console.ReadLine();
                if(!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out userDate))
                {
                    Console.WriteLine("Ne ispravan format unesite opet");
                    continue;
                }

                return userDate;
            }
        }
        public static Category ReadCategory()
        {
            while(true)
            {
                Console.WriteLine("Odaberite kategoriju\n\t 1.Elektronika \n\t 2.Odjeca \n\t 3.Knjige \n\t 4.Obuca");
                char option = Console.ReadKey().KeyChar;

                switch(option)
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
        public static bool CheckConfirmationInput()
        {
            while (true)
            {
                char option = char.ToLower(Console.ReadKey().KeyChar);

                if (option == 'y')
                    return true;
                else if (option == 'n')
                    return false;

                Console.WriteLine("Ne ispravan unos.\n");
            }
        }
    }
}