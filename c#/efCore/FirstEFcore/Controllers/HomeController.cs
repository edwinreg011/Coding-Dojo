using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstEFcore.Models;

namespace FirstEFcore.Controllers
{
    public class HomeController : Controller
    {

        //dependency injection
        private MainContext dbContext;
        public HomeController(MainContext context)
        {
            dbContext = context;
        }


        //http response for localhost 5000;
        public IActionResult Index()
        {
            //GETS ALL FROM USERS TABLE
            List<User> AllUsers = dbContext.Users.ToList();

                //GET USERS WITH THE LASTNAME "JEFFERSON"
                List<User> Jeffersons = dbContext.Users.Where(u => u.LastName == "Jefferson").ToList();


            //GET THE 5 MOST RECENTLY ADDED USERS 
            List<User> MostRecent = dbContext.Users.OrderByDescending(u => u.CreatedAt).Take(5).ToList();
            return View();
        }

        //GRAB JUST ONE INSTANCE OF A USER BY SET PARAM
        public IActionResult GetOneUser(string Email)
        {
            var oneUser = dbContext.Users.FirstOrDefault(user => user.Email == Email);
            return View();
        }

        //ADDING TO DATABASE TABLES
        [HttpPost("create")]
        public IActionResult CreateUser(User newUser)
        {
            //takes info from form submission and pushes it to db
            dbContext.Add(newUser);
            dbContext.SaveChanges();
            return View();
        }

        //UPDATING MODELS
        [HttpGet("update/{userId}")]
        public IActionResult UpdateUser(int userId)
        {
            User RetUser = dbContext.Users.FirstOrDefault(user => user.UserId == userId);
            RetUser.FirstName = "New Name";
            RetUser.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return View();
        }

        //REMOVING FROM THE TABLE
        [HttpGet("delete/{user.Id}")]
        public IActionResult DeleteUser(int userId)
        {
            User RetUser = dbContext.Users.SingleOrDefault(user => user.UserId == userId);
            dbContext.Users.Remove(RetUser);
            dbContext.SaveChanges();
            return View();
        }
    }
}
