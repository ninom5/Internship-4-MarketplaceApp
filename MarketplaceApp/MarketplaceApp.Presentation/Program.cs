using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Menu;

namespace MarketplaceApp.Presentation
{
    class Program
    {
        public static void Main(string[] args)
        {
            Marketplace marketPlace = new Marketplace();
            MainMenu mainMenu = new MainMenu();

            mainMenu.ShowMainMenu(marketPlace);
        }
    }
}