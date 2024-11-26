using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Domain.NewFolder;

namespace MarketplaceApp.Presentation.LoginRegister.Register
{
    public class RegisterClass
    {
        public void RegisterBuyer(Marketplace marketplace)
        {
            UserRepository userRepository = new UserRepository();
            var user = GetNameAndEmail(marketplace, userRepository);

            double balance = ReadInput.ReadAmount();

            userRepository.AddUser(marketplace, user.name, user.email, balance);

            Console.WriteLine("Kupac uspjesno registriran");
        }

        public void RegisterSeller(Marketplace marketplace)
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
                //Console.Clear();
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
