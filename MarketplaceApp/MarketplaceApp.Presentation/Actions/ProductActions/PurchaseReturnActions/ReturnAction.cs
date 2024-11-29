using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Show;
using MarketplaceApp.Presentation.Utility;

namespace MarketplaceApp.Presentation.Actions.ProductActions.PurchaseReturnActions
{
    public class ReturnAction
    {
        public void ReturnProduct(Marketplace marketPlace, Buyer buyer)
        {
            var listOfBoughtProducts = ProductRepository.BuyerProducts(buyer, marketPlace);
            if (!ShowProduct.PrintProducts(listOfBoughtProducts))
                return;

            Console.WriteLine("Unesite id proizvoda kojeg zelite vratiti");
            var id = ReadInput.ReadIdOfProduct();

            bool isFound = false;
            foreach (var product in listOfBoughtProducts)
            {
                if (product.Id == id)
                {
                    isFound = true;
                    ProccessReturn(marketPlace, product, buyer);

                    break;
                }
            }
            if (!isFound)
                Console.WriteLine("Proizvod nije pronaden");
        }

        private static void ProccessReturn(Marketplace marketPlace, Product product, Buyer buyer)
        {
            ProductRepository productRepository = new ProductRepository();

            var transaction = TransactionRepository.FindTransaction(marketPlace, buyer, product);

            if (transaction == null)
            {
                Console.WriteLine("ne postoji transakcija za kupljeni proizvod");
                return;
            }

            if (!ConfirmAction.Confirm($"Zelite li vratiti proizvod: {transaction.Product.Name} y/n"))
            {
                Console.WriteLine("odustali ste od vracanja proizvoda");
                return;
            }

            productRepository.SetProductOnSale(transaction.Product);

            if (TransactionRepository.ProcessReturnTransaction(marketPlace, transaction, buyer) == Domain.DomainEnums.Result.Failed)
            {
                Console.WriteLine("Pogreska prilikom vracanja proizvoda");
                return;
            }

            Console.WriteLine("Kupnja izbrisana s liste transakcija");

            Console.WriteLine($"\nProizvod uspjesno vracen, vama je vraceno na racun: {Math.Round(transaction.Price * 0.8, 2)}, trenutno stanje: {Math.Round(buyer.Amount, 2)}");
        }
    }
}
