using Microsoft.AspNetCore.Mvc;
using probnik.Data.Interfaces;
using probnik.Data.Models;
using probnik.Data.Repository;
using probnik.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Contollers
{
    public class ShopCartController : Controller // Контроллер корзины товаров
    {
        private readonly IAllCars CarRep;
        private readonly ShopCart ShopCart;

        public ShopCartController(IAllCars CarRep, ShopCart ShopCart)
        {
            this.CarRep = CarRep;
            this.ShopCart = ShopCart;
        }

        public ViewResult Index()
        {
            var Items = this.ShopCart.GetShopItems();
            this.ShopCart.ListShopItems = Items;

            var Object = new ShopCartViewModel
            {
                ShopCart = this.ShopCart
            };

            return View(Object);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var Item = this.CarRep.Cars.FirstOrDefault(i => i.id == id);

            if (Item != null)
                ShopCart.AddToCart(Item);

            return RedirectToAction("Index");
        }
    }
}
