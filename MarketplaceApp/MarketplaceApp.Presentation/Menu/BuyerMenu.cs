﻿using MarketplaceApp.Data.Models;
using MarketplaceApp.Presentation.Utility;
using MarketplaceApp.Presentation.Show;
using System.Collections.Generic;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Actions.ProductActions.PurchaseReturnActions;
using MarketplaceApp.Presentation.Actions.ProductActions.Favourites;

namespace MarketplaceApp.Presentation.Menu
{
    public class BuyerMenu
    {
        public static void ShowBuyerOptions(Buyer buyer, Marketplace marketPlace)
        {
            Thread.Sleep(2000);
            Console.Clear();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("\n1. Pregled svih dostupnih proizvoda \n2.Kupnja proizvoda s ID \n3.Povratak kupljenog proizvoda \n4.Dodavanje proizvoda u listu omiljenih \n5.Pregled povijesti kupljenih proizvoda" +
                    "\n6.Pregled liste omiljenih proizvoda \n\n0.Povratak na glavni izbornik");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    case '1':
                        Helper.AllProductsOnSale(marketPlace);
                        break;
                    case '2':
                        StartPurchase.StartPurchaseAction(marketPlace, buyer);
                        break;
                    case '3':
                        ReturnAction action = new ReturnAction();
                        action.ReturnProduct(marketPlace, buyer);
                        break;
                    case '4':  
                        FavouriteProduct favourite = new FavouriteProduct();
                        favourite.StartNewFavoriteAction(marketPlace, buyer);
                        break;
                    case '5':
                        Console.WriteLine("\nKupljeni proizvodi:\n");
                        var boughtProducts = ProductRepository.BuyerProducts(buyer, marketPlace);
                        ShowProduct.PrintProducts(boughtProducts);
                        break;
                    case '6':
                        FavouriteProduct.ShowFavouriteProducts(buyer);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("\nne ispravan unos");
                        break;
                }
            }
        }
    }
}
