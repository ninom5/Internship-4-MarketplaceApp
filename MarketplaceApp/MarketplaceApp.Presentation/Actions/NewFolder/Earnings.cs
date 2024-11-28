using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Utility;

namespace MarketplaceApp.Presentation.Actions.NewFolder
{
    public class Earnings
    {
        public void CalculateEarnings(Marketplace marketPlace, Seller seller)
        {
            TransactionRepository transactionRepository = new TransactionRepository();

            DateTime startingDate = ReadInput.ReadDate("pocetni");
            DateTime endingDate = ReadInput.ReadDate("krajnji");

            if (startingDate > endingDate)
            {
                Console.WriteLine("pocetni datum ne moze biti nakon krajnjeg");
                return;
            }

            var transactions = transactionRepository.GetTransactionsWithinDateRange(marketPlace, startingDate, endingDate);
            var returnedTransactions = transactionRepository.GetReturnedTransactionsWithinDateRange(marketPlace, startingDate, endingDate);

            double sellerEarning = EarningsFromSoldProducts(transactions);
            double sellerEarningFromReturnedProducts = EarningsFromReturnedProducts(returnedTransactions);

            if(sellerEarning + sellerEarningFromReturnedProducts == 0)
                Console.WriteLine("\n Nije bilo transakcija u odabranom vremenu");
            

            Console.WriteLine($"Zarada prodanih proizvoda od: {startingDate} do: {endingDate} iznosi: {Math.Round(sellerEarning, 2)}, zarada od postotka vracenih proizvoda: {Math.Round(sellerEarningFromReturnedProducts, 2)}, " +
                $"ukupno zarada iznosi: {Math.Round(sellerEarning + sellerEarningFromReturnedProducts, 2)}.");
        }
        private double EarningsFromSoldProducts(List<Transaction> transactions)
        {
            return transactions.Sum(transaction => transaction.Product.Price * 0.95);
        }

        private double EarningsFromReturnedProducts(List<ReturnedTransaction> returnedTransactions)
        {
            return returnedTransactions.Sum(transaction => transaction.Product.Price * 0.15);
        }
    }
}
