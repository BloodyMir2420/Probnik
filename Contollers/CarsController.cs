using Microsoft.AspNetCore.Mvc;
using probnik.Data.Interfaces;
using probnik.ViewModels;
using probnik.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using probnik.Data.Models;
using probnik.Contollers;


namespace probnik.Contollers
{
    public class CarsController : Controller
    {
        private readonly IAllCars /*Обращение идет к интерфейсу, так как при таком обращении используется его реализация, описанная в Mock*/ _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars AllCars, ICarsCategory CarsCategory) // Конструктор контроллера машин
        {
            _allCars = AllCars;
            _allCategories = CarsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Нихуя себе"; // Название страницы со списком машин
            CarsListViewModel Object1 = new CarsListViewModel(); // Объект класса для просмотра машин
            Object1.GetAllCars = _allCars.Cars; // Передача текущего списка машин
            Object1.CurrentCategory = "Автомобили"; // Текущая категория - автомобили (пока что только машини)
            return View(Object1); // Передача объекта для отображения
        }
    }
}
