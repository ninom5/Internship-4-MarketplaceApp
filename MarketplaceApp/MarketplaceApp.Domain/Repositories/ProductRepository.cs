using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MarketplaceApp.Domain.Repositories
{
    public class ProductRepository
    {

        public void ReturnProduct(Marketplace marketPlace, Buyer buyer)
        {
            var listOfBoughtProducts = BuyerProducts(marketPlace, buyer);
            PrintProducts(listOfBoughtProducts);
            
            Console.WriteLine("Uneiste id proizvoda kojeg zelite vratiti");
            var id = ReadInput.EnterIdOfProduct();

            bool isFound = false;
            foreach (var product in listOfBoughtProducts)
            {
                if (product.Id == id)
                {
                    isFound = true;
                    ProccessReturn(marketPlace, product, buyer);
                    
                    Console.WriteLine("Kupnja izbrisana s liste transakcija");
                    break;
                }
            }
            if (!isFound)
                Console.WriteLine("Proizvod nije pronaden");
        }


        private List<Product> BuyerProducts(Marketplace marketPlace, Buyer buyer)
        {
            return marketPlace.TransactionsList
                .Where(buyerFromList => buyerFromList.Buyer == buyer)
                .Select(product => product.Product).ToList();
        }
        private void ShowBuyerProducts(Marketplace marketplace, Buyer buyer, List<Transaction> boughtProducts)
        {
            if (!boughtProducts.Any())
            {
                Console.WriteLine("Nema proizvoda, unesite 0 za prekid");
                return;
            }

            Console.WriteLine("\n");
            foreach (var transaction in boughtProducts)
            {
                Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, kupac: {transaction.Buyer.Name}, " +
                    $"prodavac: {transaction.Seller.Name}, datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, kategorija proizvoda: {transaction.ProductType}");
            }
        }
        private static void ProccessReturn(Marketplace marketPlace,Product product, Buyer buyer)
        {
            var transaction = marketPlace.TransactionsList
                .FirstOrDefault(buy => buy.Buyer == buyer && buy.Product.Id == product.Id);
            if (transaction == null)
                Console.WriteLine("ne postoji transakcija za kupljeni proizvod");

            double amountToReturn = transaction.Product.Price * 0.8;

            buyer.Amount += amountToReturn;
            transaction.Seller.Earnings -= amountToReturn;

            transaction.Product.ProductStatus = ProductStatus.Na_prodaji;
            marketPlace.TransactionsList.Remove(transaction);

            Console.WriteLine($"Proizvod uspjesno vracen, vama je vraceno na racun: {Math.Round(transaction.Product.Price * 0.8, 2)}, trenutno stanje: {Math.Round(buyer.Amount, 2)}");
        }
        public static List<Product> AllProductsOnSale(Marketplace marketplace)
        {
            return marketplace.ProductList
                .Where(product => product.ProductStatus == Data.Enum.ProductStatus.Na_prodaji).ToList();
        }
        public static void PrintProducts(List<Product> productList)
        {
            Console.WriteLine("\n");
            foreach (var product in productList)
            {
                Console.WriteLine($"Ime proizvoda: {product.Name}, opis proizvoda: {product.Description}, id proizvoda: {product.Id}, cijena: {product.Price}, status proizvoda: {product.ProductStatus}, kategorija: {product.ProductType}, prodavac: {product.Seller.Name}");
            }
        }
        public static Product GetProduct(Marketplace marketplace, Guid id)
        {
            return marketplace.ProductList
                .FirstOrDefault(product => product.Id == id);
        }

    }
}