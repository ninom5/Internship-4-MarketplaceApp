using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using System.Transactions;

namespace MarketplaceApp.Presentation.Utility
{
    public class ConfirmAction
    {
        public static bool Confirm(string actionMessage)
        {
            while (true)
            {
                Console.WriteLine(actionMessage);
                return ReadInput.CheckConfirmationInput();
            }
        }
    }
}
