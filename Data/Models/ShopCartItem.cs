﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Models
{
    public class ShopCartItem // Модель товара в корзине
    {
        public int id { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
