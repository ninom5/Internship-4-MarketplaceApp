using MarketplaceApp.Data.Models;

namespace MarketplaceApp.Presentation.Show
{
    public class ShowTransaction
    {
        public static void ShowAllTransactions(Marketplace marketplace)
        {
            Console.Clear();

            var list = GetAllTransactions(marketplace);
            var returnedList = marketplace.ReturnedProductsTransactionList;

            if (!list.Any() && ! returnedList.Any())
            {
                Console.WriteLine("Nema transakcija");
                return;
            }

            Console.WriteLine("Transakcije kupljenih proizvoda");
            foreach (var transaction in list)
            {
                Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, kupac: {transaction.Buyer.Name}, " +
                    $"prodavac: {transaction.Seller.Name}, datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, kategorija proizvoda: {transaction.ProductType}, cijena: {Math.Round(transaction.Price, 2)}");
            }

            if (marketplace.ReturnedProductsTransactionList.Any())
            {
                Console.WriteLine("\n\nTransakcije vracenih proizvoda");
                foreach (var transaction in marketplace.ReturnedProductsTransactionList)
                {
                    Console.WriteLine($"Id transakcije: {transaction.IdOfTransaction}, naziv proizvoda: {transaction.Product.Name}, id proizvoda: {transaction.Id}, osoba koja vraca proizvod: {transaction.Returner.Name}, " +
                        $"prodavac: {transaction.Seller.Name}, datum i vrijeme transakcije: {transaction.DateTimeOfTransaction}, vraceni iznos kupcu: {Math.Round(transaction.AmountToReturn, 2)}, iznos koji je ostao prodavacu: {Math.Round(transaction.SellerReturnProvision, 2)}");
                }
            }

            Console.WriteLine("\nza povratak na glavni menu pritisnite bilo koju tipku");
            Console.ReadKey();
        }
        private static List<Transaction> GetAllTransactions(Marketplace marketplace)
        {
            return marketplace.TransactionsList;
        }
    }
}
