﻿using MarketplaceApp.Data.Enum;
using MarketplaceApp.Data.Models;
using MarketplaceApp.Domain.NewFolder;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Utility;

namespace MarketplaceApp.Presentation.Actions.NewProduct
{
    public class CreateProductAction
    {
        public void GetProductData(Marketplace marketPlace, Seller seller)
        {
            var name = ReadInput.ReadProductName();
            
            var productDescription = ReadInput.ReadProductDescription();
            
            var price = ReadInput.ReadPrice();

            Category category = Helper.ChooseCategory();

            Product product = new Product(name, productDescription, price, category, seller);
            if(!ConfirmAction.Confirm())
            {
                Console.WriteLine("Dodavanje novog proizvoda prekinuto");
                return;
            }

            if(ProductRepository.AddNewProduct(marketPlace, product) == Domain.DomainEnums.Result.Failed)
            {
                Console.WriteLine("Greska pri dodavanju novog proizvod");
                return;
            }

            Console.WriteLine("Novi proizvod uspjesno dodan");
        }
    }
}