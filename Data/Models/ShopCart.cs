<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Models
{
    public class ShopCart // Класс корзины покупок (без понимания, почему реализация сразу в модели)
    {
        private readonly AppDBContent AppDBContent; // Содержимое базы данных

        public ShopCart(AppDBContent AppDBContent /*Внешнее данные, передаваемые из вне*/)
        {
            this.AppDBContent /*Внитренние данный БД*/ = AppDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider Services)
        {
            ISession session = Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var Context = Services.GetService<AppDBContent>();
            string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", ShopCartId);

            return new ShopCart(Context)
            {
                ShopCartId = ShopCartId
            };
        }

        public void AddToCart(Car Car) // Метод добавления товара в корзину
        {
            this.AppDBContent.ShopCartItem.Add(new ShopCartItem // Добавление сначала передаваемой машины, как предмета корзины...
            {
                ShopCartId = ShopCartId,
                Car = Car,
                Price = Car.price
            });

            AppDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems() // ...После чего создается список товаров в корзине
        {
            return AppDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId/*Если ID совпадает...*/).Include(s => s.Car/*...В список включается машина с таким же*/).ToList();
        }

    }
}
=======
﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Models
{
    public class ShopCart // Класс корзины покупок (без понимания, почему реализация сразу в модели)
    {
        private readonly AppDBContent AppDBContent; // Содержимое базы данных

        public ShopCart(AppDBContent AppDBContent /*Внешнее данные, передаваемые из вне*/)
        {
            this.AppDBContent /*Внитренние данный БД*/ = AppDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider Services)
        {
            ISession session = Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var Context = Services.GetService<AppDBContent>();
            string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", ShopCartId);

            return new ShopCart(Context)
            {
                ShopCartId = ShopCartId
            };
        }

        public void AddToCart(Car Car) // Метод добавления товара в корзину
        {
            this.AppDBContent.ShopCartItem.Add(new ShopCartItem // Добавление сначала передаваемой машины, как предмета корзины...
            {
                ShopCartId = ShopCartId,
                Car = Car,
                Price = Car.price
            });

            AppDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems() // ...После чего создается список товаров в корзине
        {
            return AppDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId/*Если ID совпадает...*/).Include(s => s.Car/*...В список включается машина с таким же*/).ToList();
        }

    }
}
>>>>>>> c17b4e4bed93115ced44cc65a878e9e75dd571aa
