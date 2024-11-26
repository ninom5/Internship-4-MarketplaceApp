using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Menu;
using MarketplaceApp.Data.Seeds;

namespace MarketplaceApp.Presentation
{
    class Program
    {
        public static void Main(string[] args)
        {
            Marketplace marketPlace = new Marketplace();
            StartingData.startingSeed(marketPlace);

            MainMenu mainMenu = new MainMenu();

            mainMenu.ShowMainMenu(marketPlace);
        }
    }
}