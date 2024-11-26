using MarketplaceApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Utility
{
    public class ConfirmAction
    {
        public static bool Confirm(Product product)
        {
            while (true)
            {
                Console.WriteLine($"Zelite li kupiti proizvod: {product.Name}. \ny/n");
                char option = char.ToLower(Console.ReadKey().KeyChar);

                if(option == 'y')
                    return true;
                else if(option == 'n')
                    return false;

                Console.WriteLine("Ne ispravan unos.\n");
            }
        }
    }
}
