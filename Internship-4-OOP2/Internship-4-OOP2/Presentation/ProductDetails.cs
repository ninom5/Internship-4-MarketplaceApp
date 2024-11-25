using Internship_4_OOP2.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_OOP2.Presentation
{
    public class ProductDetails
    {
        public static void PrintProductDetails(Product product)
        {
            Console.WriteLine($"Ime proizvoda: {product.Name}, opis proizvoda: {product.Description}, id proizvoda: {product.getId()}, cijena: {product.Price}, status proizvoda: {product.ProductStatus}, kategorija: {product.ProductType}, prodavac: {product.Seller.Name}");
        }
    }
}
