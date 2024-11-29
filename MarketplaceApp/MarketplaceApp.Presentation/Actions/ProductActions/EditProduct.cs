using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Presentation.Utility;

namespace MarketplaceApp.Presentation.Actions.ProductActions
{
    public class EditProduct
    {
        public void ChangeProductPrice(List<Product> listOfProducts, Marketplace marketPlace)
        {
            Guid id = ReadInput.ReadIdOfProduct();
            Product product = Helper.GetProduct(marketPlace, id);

            if (product == null)
            {
                Console.WriteLine("proizvod nije pronaden");
                return;
            }

            Console.WriteLine("Unesite cijenu novog proizvoda");
            double newPrice = ReadInput.ReadPrice();

            if(!ConfirmAction.Confirm($"Zelite li stvarno promijeniti cijenu proizvoda: {product.Name}? y/n"))
            {
                Console.WriteLine("Odustali ste od mijenjanja cijene proizvoda");
                return;
            }

            product.Price = newPrice;

            Console.WriteLine("Cijena proizvoda uspjesno promijenjena");
        }
    }
}
