using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Actions.NewFolder;
using MarketplaceApp.Presentation.Actions.ProductActions;
using MarketplaceApp.Presentation.Actions.ProductActions.NewProduct;
using MarketplaceApp.Presentation.Show;


namespace MarketplaceApp.Presentation.Menu
{
    public class SellerMenu
    {
        public static void ShowSellerOptions(Seller seller, Marketplace marketPlace)
        {
            Thread.Sleep(2000);
            Console.Clear();

            ProductRepository repository = new ProductRepository();
            EditProduct editProduct = new EditProduct();
            while (true)
            {
                Console.WriteLine("\n1.Dodavanje proizvoda \n2.Pregled svih proizvoda odabranog prodavaca \n3.Pregled ukupne zarade od prodaje \n4.Pregled prodanih proizvoda po kategoriji " +
                    "\n5.Pregled zarade u odredenom vrem razdoblju \n6.Promjena cijene proizvoda \n7.Dodavanje kupona \n0.Glavni izbornik");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        CreateProductAction createProductAction = new CreateProductAction();
                        createProductAction.GetProductData(marketPlace, seller);
                        break;
                    case '2':
                        var listOfSellerProducts = repository.SellerProducts(marketPlace, seller);
                        ShowProduct.PrintProducts(listOfSellerProducts);
                        break;
                    case '3':
                        Console.WriteLine($"Trenutna vasa zarada: {Math.Round(seller.Earnings, 2)}");
                        break;
                    case '4':
                        Category category = ReadInput.ReadCategory();
                        var sellerSoldProductsCategorically = repository.SellerProducts(marketPlace, seller, category);
                        ShowProduct.PrintProducts(sellerSoldProductsCategorically);
                        break;
                    case '5':
                        Earnings earnings = new Earnings();
                        earnings.CalculateEarnings(marketPlace, seller);
                        break;
                    case '6':
                        var sellerProducts = repository.SellerProducts(marketPlace, seller);
                        ShowProduct.PrintProducts(sellerProducts);
                        editProduct.ChangeProductPrice(sellerProducts, marketPlace);
                        break;
                    case '7':

                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("ne ispravan unos");
                        break;
                }
            }
        }
    }
}
