using probnik.Data.Interfaces;
using probnik.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {

        public IEnumerable<Category> AllCategories 
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромашина", description = "Машина с электромотором"},
                    new Category { categoryName = "Бензомашина", description = "Пизда тебе, экология ебаная"}
                };
            }
        }
    }
}
