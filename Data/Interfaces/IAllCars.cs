using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using probnik.Data.Models;

namespace probnik.Data.Interfaces
{
    public interface IAllCars // Интерфейс с объявлением методов управления списком машин
    {
        IEnumerable<Car> Cars { get; } // Перечисление объектов модели машин
        IEnumerable<Car> GetFavoriteCars { get; } // Перечисление машин, которые добавлены в избранное
        Car getObjectCar(int carId); // Метод получение информации по машине по указанию id в базе данных
    }
}
