using Internship_4_OOP2.Data;
using Internship_4_OOP2.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Domain.Classes
{
    public static class ProductFunctions
    {
        public static void CreateNewProduct(Seller seller)
        {
            var productDetails = EnterProductData(seller);
            MarketPlaceFunctions.AddProduct(productDetails);
        }
        private static Product EnterProductData(Seller seller)
        {
            while (true)
            {
                Console.WriteLine("Unesite naziv proizvoda");
                var nameOfProduct = Console.ReadLine();
                if (string.IsNullOrEmpty(nameOfProduct))
                {
                    Console.WriteLine("ne ispravan unos");
                    continue;
                }

                Console.WriteLine("Unesite opis proizvoda");
                var productDescription = Console.ReadLine();
                if (string.IsNullOrEmpty(productDescription))
                {
                    Console.WriteLine("ne ispravan unos");
                    continue;
                }

                Console.WriteLine("Unesite cijenu proizvoda");
                double price;
                if (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                {
                    Console.WriteLine("ne ispravan unos");
                    continue;
                }

                Data.Category category = UtilityFunctions.ChooseCategory();
                return new Product(nameOfProduct, productDescription, price, category, seller);
            }
        }

        public static void PickProduct(MarketPlace marketPlace, Buyer buyer)
        {
            Console.WriteLine("Unesite id proizvoda");
            var id = Console.ReadLine();
            
            if(!Guid.TryParse(id, out var productId))
            {
                Console.WriteLine("Ne ispravan unos");
                return;
            }

            var product = FindProduct(productId, marketPlace);
            if (product == null)
            {
                Console.WriteLine("proizvod s unesenim id-om nije pronaden ili nije na prodaji");
                return;
            }

            if(buyer.Amount < product.Price)
            {
                Console.WriteLine("nemate dovoljno novca na racunu");
                return;
            }

            buyer.Amount -= product.Price;
            product.ProductStatus = ProductStatus.Prodano;

            Console.WriteLine($"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {product.Price}");

        }
        private static Product FindProduct(Guid productId, MarketPlace marketPlace)
        {
            foreach (var product in marketPlace.ProductList)
            {
                if (product.getId() == productId)
                {
                    if (product.ProductStatus != Data.ProductStatus.Na_prodaji)
                        return null;
                    return product;
                }
            }
            return null;
        }
        public static void ShowAllProductsBySeller(Seller seller, MarketPlace marketPlace)
        {
            var filteredProducts = marketPlace.ProductList
                .Where(product => product.Seller == seller);

            foreach (var product in filteredProducts)
            {
                ProductDetails.PrintProductDetails(product);
            }
        }
        public static void ShowAllProductsOnSale(MarketPlace marketPlace)
        {
            var filteredProducts = marketPlace.ProductList
                .Where(product => product.ProductStatus == ProductStatus.Na_prodaji);
            foreach (var product in filteredProducts)
            {
                ProductDetails.PrintProductDetails(product);
            }
        }
    }
}
