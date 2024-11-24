using Internship_4_OOP2.Domain.Classes;
using Internship_4_OOP2.Presentation;

namespace Internship_4_OOP2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MarketPlace marketPlace = new MarketPlace();
            MarketPlaceFunctions.SetMarketPlace(marketPlace);
            MainMenu.ShowMainMenu(marketPlace);
        }
    }
}