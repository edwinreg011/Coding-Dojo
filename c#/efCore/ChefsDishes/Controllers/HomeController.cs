using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {

        //DEP INJECTION
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        //DISPLAY LIST OF CHEFS 
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
            .Include(d => d.CreatedDishes)
            .ToList();
            return View(AllChefs);
        }

        //DISPLAY DISHES
        [HttpGet("dishes")]
        public IActionResult DispDishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(c => c.Chef).ToList();
            return View(AllDishes);
        }




        //ADD CHEF FORM
        [HttpGet("new")]
        public IActionResult ChefForm()
        {
            return View();
        }

        //POST CHEF TO DB
        [HttpPost("new")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                //MATH FOR AGE INT
                DateTime today = DateTime.Now;
                DateTime dob = newChef.DateOfBirth;

                int age = today.Year - dob.Year;
                newChef.Age = age;

                //ADD AND SAVE TO CHEF DB
                dbContext.Chefs.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("ChefForm");
            }
        }

        //ADD DISH FORM
        [HttpGet("dishes/new")]
        public IActionResult DishForm()
        {
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }

        [HttpPost("dishes/new")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("DispDishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.Chefs.ToList();
                ViewBag.AllChefs = AllChefs;
                return View("DishForm");
            }
        }
    }
}
