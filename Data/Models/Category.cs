using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Models
{
    public class Category // Описание сущности категории
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string description { set; get; }
        public List<Car> cars { set; get; } // Список всех машин, которые пренадлежат данной категории

    }
}
