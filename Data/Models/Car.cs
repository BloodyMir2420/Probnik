using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Models
{
    public class Car // Описание самой сущности (в данному случае машины и всех её параметров)
    {
        public int id { set; get; } // Идентификатор в базе данных
        public string name { get; set; } 
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string Image { get; set; } // Изображение
        public ushort price { get; set; }
        public bool isFavorite { get; set; }
        public bool availeble { get; set; }
        public int categoryId { get; set; } // Идентификатор категории (тоже бд)
        public virtual Category Category { get; set; } // Сама категория
    }
}
