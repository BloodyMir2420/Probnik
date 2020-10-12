using Microsoft.EntityFrameworkCore;
using probnik.Data.Models;
using probnik.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data
{
    public class AppDBContent : DbContext // Класс данных, которые потом внесутся в БД
    {
        public AppDBContent(DbContextOptions<AppDBContent> Options) : base(Options)
        {

        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
    }
}
