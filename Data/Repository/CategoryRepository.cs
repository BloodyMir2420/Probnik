using probnik.Data.Interfaces;
using probnik.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent AppDBContent;
        public CategoryRepository(AppDBContent AppDBContent)
        {
            this.AppDBContent = AppDBContent;
        }
        public IEnumerable<Category> AllCategories => this.AppDBContent.Category;
    }
}
