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
            double sellerEarning = 0.0;

            DateTime startingDate = ReadInput.ReadDate("pocetni");
            DateTime endingDate = ReadInput.ReadDate("krajnji");

            if (startingDate > endingDate)
            {
                Console.WriteLine("pocetni datum ne moze biti nakon krajnjeg");
                return;
            }

            var listOfTransactionsWithinDates = transactionRepository.GetTransactionsWithinDateRange(marketPlace, startingDate, endingDate);

            foreach(var transaction in listOfTransactionsWithinDates)
            {
                sellerEarning += transaction.Product.Price * 0.95;
            }

            Console.WriteLine($"Zarada od: {startingDate} do: {endingDate} iznosi: {sellerEarning}");
        }
    }
}
