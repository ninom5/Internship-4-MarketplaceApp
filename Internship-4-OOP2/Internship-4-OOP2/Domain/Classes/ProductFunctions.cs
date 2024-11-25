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
            var productId = EnterIdOfProduct();
            if(productId == Guid.Empty)
                return;

            var product = FindProduct(productId, marketPlace);
            if (product == null)
            {
                Console.WriteLine("proizvod s unesenim id-om nije pronaden ili nije na prodaji");
                return;
            }

            if (buyer.Amount < product.Price)
            {
                Console.WriteLine("nemate dovoljno novca na racunu");
                return;
            }

            var transaction = TransactionFunctions.CreateTransaction(product.getId(), buyer, product.Seller, product, product.ProductType);
            marketPlace.TransactionsList.Add(transaction);

            BuyerFunctions.SubstractAmountBuyer(buyer, product.Price);
            SellerFunctions.AddAmountSeller(product.Seller, product.Price * 0.95);

            product.ProductStatus = ProductStatus.Prodano;
            marketPlace.MarketPlaceBalance += (product.Price * 0.05);

            Console.WriteLine($"Proizvod: {product.Name} je uspjesno kupljen po cijeni od {product.Price}");
            
        }
        private static Guid EnterIdOfProduct()
        {
            Console.WriteLine("Unesite id proizvoda");
            var id = Console.ReadLine();

            if (!Guid.TryParse(id, out var productId))
            {
                Console.WriteLine("Ne ispravan unos");
                return Guid.Empty;
            }

            return productId;
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

        public static void ReturnProduct(MarketPlace marketPlace, Buyer buyer)
        {
            var boughtProducts = marketPlace.TransactionsList
                .Where(buyerFromList => buyerFromList.Buyer == buyer).ToList();

            UtilityFunctions.ShowBuyerProducts(marketPlace, buyer, boughtProducts);
            Console.WriteLine("Uneiste id proizvoda kojeg zelite vratiti");
            var id = EnterIdOfProduct();

            bool isFound = false;
            foreach(var transaction in boughtProducts)
            {
                if(transaction.Id == id)
                {
                    isFound = true;
                    ReturnProd(transaction, buyer);
                    marketPlace.TransactionsList.Remove(transaction);
                    break;
                }
            }
            if(!isFound)
                Console.WriteLine("Proizvod nije pronaden");
        }

        private static void ReturnProd(Transaction transaction, Buyer buyer)
        {
            BuyerFunctions.AddAmountBuyer(buyer, transaction.Product.Price * 0.8);
            SellerFunctions.SubstractAmountSeller(transaction.Seller, transaction.Product.Price * 0.8);
            transaction.Product.ProductStatus = ProductStatus.Na_prodaji;


            Console.WriteLine($"Proizvod uspjesno vracen, vama je vraceno na racun: {Math.Round(transaction.Product.Price * 0.8, 2)}, trenutno stanje: {Math.Round(buyer.Amount, 2)}");
        }
    }
}