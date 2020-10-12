using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using probnik.Data.Mocks;
using probnik.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data
{
    public class DBObjects // Класс объектов БД
    {
        private static Dictionary<string, Category> Category; // Словарь описания категории (первый параметр - формат описание, второй параметр - объект описания)
        public static void Initial(AppDBContent Content)
        {
            if (!Content.Category.Any())
                Content.Category.AddRange(Categories.Select(c => c.Value));

            if (!Content.Car.Any()) // Если объект не пустой
            {
                Content.AddRange // Добавление списка объектов
                (
                        new Car // Сами объекты
                        {
                            name = "Tesla",
                            shortDescription = "Elon Musk`s shit",
                            longDescription = "Elon Musk`s REAL shit",
                            Image = "/img/TESLA.jpg",
                            price = 45000,
                            isFavorite = true,
                            availeble = true,
                            Category = Categories["Электромашина"]
                        },
                        new Car
                        {
                            name = "Lamorghini",
                            shortDescription = "It is fast",
                            longDescription = "It is real fucking fast",
                            Image = "/img/LAMBA.jpg",
                            price = 55000,
                            isFavorite = false,
                            availeble = true,
                            Category = Categories["Бензомашина"]
                        }
                 );
            }

            Content.SaveChanges(); // Сохранение изминений
        }

        public static Dictionary<string, Category> Categories // Реализация описания категории
        {
            get
            {
                if (Category == null) // Если объект не пустой
                {
                    var List = new Category[] // Список категорий
                    {
                        new Category { categoryName = "Электромашина", description = "Машина с электро двигатилем" },
                        new Category { categoryName = "Бензомашина", description = "Машина со старыми двигателями" }
                    };

                    Category = new Dictionary<string, Category>(); // Переопредиление словаря
                    foreach (Category Element in List) // 
                        Category.Add(Element.categoryName, Element); // Добавление категорий с их описанием в словарь             
                }

                return Category; // Возвращение уже готовго словаря
            }
        }
    }
}
