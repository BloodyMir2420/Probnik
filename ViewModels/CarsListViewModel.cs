<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using probnik.Data.Interfaces;
using probnik.Data.Models;
using probnik.Contollers;

namespace probnik.ViewModels
{
    public class CarsListViewModel // Класс для просмотра списка машин
    {
        public IEnumerable<Car> GetAllCars { get; set; } // Перечисление всех машин (нужно убрать с название Get, но мне впадло)
        public string CurrentCategory { get; set; } // Текущая категория, с котой ведется работа
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using probnik.Data.Interfaces;
using probnik.Data.Models;
using probnik.Contollers;

namespace probnik.ViewModels
{
    public class CarsListViewModel // Класс для просмотра списка машин
    {
        public IEnumerable<Car> GetAllCars { get; set; } // Перечисление всех машин (нужно убрать с название Get, но мне впадло)
        public string CurrentCategory { get; set; } // Текущая категория, с котой ведется работа
    }
}
>>>>>>> c17b4e4bed93115ced44cc65a878e9e75dd571aa
