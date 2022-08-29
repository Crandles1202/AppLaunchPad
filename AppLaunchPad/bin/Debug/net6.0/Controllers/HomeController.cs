using AppLaunchPad.Models;
using AppLaunchPad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLaunchPad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMeals _meals;

        public HomeController(ILogger<HomeController> logger, IMeals meals)
        {
            _logger = logger;
            _meals = meals;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _meals.printOutInt();
            var MealsModel = new MealsModel
            { 
                mealsID = 1,
                mealsDescription = "Mac & Cheese with Peas and Veggie Chicken Nuggets",
                mealsProtien = "Veggie Chicken Nuggets",
                mealsCarb = "Mac & Cheese",
                mealsVeggie = "Peas",
                mealsFat = "Butter"
            };

            return View(MealsModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}