using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Show;

namespace MarketplaceApp.Presentation.PurchaseReturnActions
{
    public class ReturnAction
    {
        public void ReturnProduct(Marketplace marketPlace, Buyer buyer)
        {
            var listOfBoughtProducts = ProductRepository.BuyerProducts(marketPlace, buyer);
            if(!ShowProduct.PrintProducts(listOfBoughtProducts))
                return;

            Console.WriteLine("Unesite id proizvoda kojeg zelite vratiti");
            var id = ReadInput.EnterIdOfProduct();

            bool isFound = false;
            foreach (var product in listOfBoughtProducts)
            {
                if (product.Id == id)
                {
                    isFound = true;
                    ProccessReturn(marketPlace, product, buyer);

                    Console.WriteLine("Kupnja izbrisana s liste transakcija");
                    break;
                }
            }
            if (!isFound)
                Console.WriteLine("Proizvod nije pronaden");
        }
        
        
        private static void ProccessReturn(Marketplace marketPlace, Product product, Buyer buyer)
        {
            var transaction = TransactionRepository.FindTransaction(marketPlace, buyer, product);

            if (transaction == null)
            { 
                Console.WriteLine("ne postoji transakcija za kupljeni proizvod"); 
                return;
            }

            ProductRepository.SetProductOnSale(transaction.Product);
            if(TransactionRepository.ProcessReturnTransaction(marketPlace, transaction, buyer) == Domain.DomainEnums.Result.Failed)
            {
                Console.WriteLine("Pogreska prilikom vracanja proizvoda");
                return;
            }

            Console.WriteLine($"Proizvod uspjesno vracen, vama je vraceno na racun: {Math.Round(transaction.Product.Price * 0.8, 2)}, trenutno stanje: {Math.Round(buyer.Amount, 2)}");
        }
    }
}
