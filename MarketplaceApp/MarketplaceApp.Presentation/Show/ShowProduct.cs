﻿using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Show
{
    public class ShowProduct
    {
        public static bool PrintProducts(List<Product> productList)
        {
            if(!productList.Any())
            {
                Console.WriteLine("\nnema dostupnih proizvoda");
                return false;
            }

            Console.WriteLine("\n");
            foreach (var product in productList)
            {
                Console.WriteLine($"Ime proizvoda: {product.Name}, opis proizvoda: {product.Description}, id proizvoda: {product.Id}, cijena: {product.Price}, status proizvoda: {product.ProductStatus}, kategorija: {product.ProductType}, prodavac: {product.Seller.Name}");
            }

            return true;
        }
    }
}
