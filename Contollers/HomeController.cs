using Microsoft.AspNetCore.Mvc;
using probnik.Data.Interfaces;
using probnik.Data.Models;
using probnik.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnik.Contollers
{
    public class HomeController : Controller
    {
        private readonly IAllCars CarRep;

        public HomeController(IAllCars CarRep)
        {
            this.CarRep = CarRep;
        }

        public ViewResult Index()
        {
            var HomeCars = new HomeViewModel
            {
                FavoriteCars = this.CarRep.GetFavoriteCars
            };

            return View(HomeCars);
        }
    }
}
