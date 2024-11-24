using Internship_4_OOP2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public class UserFunctions
    {
        public static (string Name, string Email) UserDetail()
        {
            bool isValidName = false;
            bool isValidEmail = false;
            string name = "";
            string email = "";
            while(!isValidName)
            {
                Console.WriteLine("Unesite ime: ");
                name = Console.ReadLine();

                if(string.IsNullOrEmpty(name))
                    Console.WriteLine("Ne ispravan unos, unesite opet");
                else
                    isValidName = true;
            }

            while(!isValidEmail)
            {
                Console.WriteLine("Unesite email");
                email = Console.ReadLine();

                if(UtilityFunctions.IsEmailValid(email))
                {
                    isValidEmail = true;
                }
                else
                    Console.WriteLine("Ne ispravan unos, unesite opet");
            }


            return (name, email);
        }
    }
}
