using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Menu
{
    public class BuyerMenu
    {
        public static void ShowBuyerOptions(Buyer buyer, Marketplace marketPlace)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("1. Pregled svih dostupnih proizvoda \n2.Kupnja proizvoda s ID \n3.Povratak kupljenog proizvoda \n4.Dodavanje proizvoda u listu omiljenih \n5.Pregled povijesti kupljenih dogadaja \n6.Pregled liste omiljenih proizvoda");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        ShowAllProductsOnSale(marketPlace);
                        return;
                    //case '2':
                    //    ProductFunctions.ShowAllProductsOnSale(marketPlace);
                    //    ProductFunctions.PickProduct(marketPlace, buyer);
                    //    return;
                    //case '3':
                    //    ProductFunctions.ReturnProduct(marketPlace, buyer);
                    //    return;
                }
            }
        }
        private static void ShowAllProductsOnSale(Marketplace marketPlace)
        {
            var listOfProducts = ProductRepository.AllProductsOnSale(marketPlace);
            if (!listOfProducts.Any())
            {
                Console.WriteLine("Nema dostupnih proizvoda");
                return;
            }
            
            foreach (var product in listOfProducts)
            {
                Console.WriteLine($"Naziv proizvoda: {product.Name}, id proizvoda: {product.Id}, opis proizvoda: {product.Description}, kategorija: {product.ProductType}, cijena: {product.Price}");
            }
        }
    }
}
