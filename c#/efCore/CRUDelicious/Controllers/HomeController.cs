using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        //DEP INJECTION
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }



        //RESPONSE FOR LOCALHOST 5000
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            return View(AllDishes);
        }

        //RESPONSE FOR LOCALHOST 5000/{DISHID}
        [HttpGet("{dish_id}")]
        public IActionResult ViewDish(int dish_id)
        {
            Dish dispDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dish_id);


            
            ViewBag.dispDish = dispDish;
            return View("DishInfo");
        }

        //POST METHOD TO ADD DISH
        [HttpPost("new")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish");
            }
        }

        //NEW DISH FORM 
        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View();
        }

        [HttpGet("update/{dish_id}")]
        public IActionResult UpdateView(int dish_id)
        {
            Dish RetDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dish_id);
            return View("Update",RetDish);
        }

        [HttpPost("update/{dish_id}")]
        public IActionResult UpdateDish(int dish_id, Dish info)
        {

        Dish RetDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dish_id);
            if(ModelState.IsValid)
            {
                RetDish.Name = info.Name;
                RetDish.Chef = info.Chef;
                RetDish.Calories = info.Calories;
                RetDish.Tastiness = info.Tastiness;
                RetDish.Description = info.Description;
                RetDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Update", RetDish);
            }
        }

        [HttpGet("delete/{dish_id}")]
        public IActionResult Remove(int dish_id)
        {
            Dish DelDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dish_id);
            dbContext.Dishes.Remove(DelDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
