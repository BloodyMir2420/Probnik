using probnik.Data.Interfaces;
using probnik.Data.Models;
using probnik.Data.Mocks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Repository
{
    public class CarsRepository : IAllCars // Новый класс реализации интерфейсов (вместо MockCars) уже с учетом наличия базы данных
    {
        
        private readonly AppDBContent AppDBContent; // Содержимое базы данных

        public CarsRepository(AppDBContent AppDBContent /*Внешнее данные, передаваемые из вне*/)
        {
            this.AppDBContent /*Внитренние данный БД*/ = AppDBContent; 
        }

        public IEnumerable<Car> Cars => /*Запись метода в одну строку*/ this.AppDBContent.Car.Include(c => c.Category); // Добавление к списку перечисляемых машин объекта категории
        public IEnumerable<Car> GetFavoriteCars => this.AppDBContent.Car.Where(p => p.isFavorite).Include(c => c.Category); // Если значение IsFavorite == true, то записывается в значение p
        public Car getObjectCar(int carId) => this.AppDBContent.Car.FirstOrDefault(p => p.id == carId); // Получение объекта машини по идентификатору
        
    }
}
