using probnik.Data.Interfaces;
using probnik.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Data.Mocks
{
    public class MockCar : IAllCars
    {
        private readonly ICarsCategory CategoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla",
                        shortDescription = "Elon Musk`s shit",
                        longDescription = "Elon Musk`s REAL shit",
                        Image = "/img/TESLA.jpg",
                        price = 45000,
                        isFavorite = true,
                        availeble = true,
                        Category = this.CategoryCars.AllCategories.First()
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
                        Category = this.CategoryCars.AllCategories.Last()
                    }
                };
            }
        }

        public IEnumerable<Car> GetFavoriteCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
