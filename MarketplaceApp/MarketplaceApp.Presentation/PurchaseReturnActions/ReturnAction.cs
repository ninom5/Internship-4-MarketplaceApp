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
            var listOfBoughtProducts = BuyerProducts(marketPlace, buyer);
            if(!ShowProduct.PrintProducts(listOfBoughtProducts))
                return;

            Console.WriteLine("Uneiste id proizvoda kojeg zelite vratiti");
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
        private List<Product> BuyerProducts(Marketplace marketPlace, Buyer buyer)
        {
            return marketPlace.TransactionsList
                .Where(buyerFromList => buyerFromList.Buyer == buyer)
                .Select(product => product.Product).ToList();
        }
        
        private static void ProccessReturn(Marketplace marketPlace, Product product, Buyer buyer)
        {
            var transaction = marketPlace.TransactionsList
                .FirstOrDefault(buy => buy.Buyer == buyer && buy.Product.Id == product.Id);

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
