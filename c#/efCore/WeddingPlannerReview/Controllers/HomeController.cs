using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlannerReview.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace WeddingPlannerReview.Controllers
{
    public class HomeController : Controller
    {
        //dep injection
        private MyContext dbContext; 
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        //////////////////////////////////////////////////
        //LOGIN AND REG CONTROLLERS///////////////////////
        //////////////////////////////////////////////////
        public IActionResult Index()
        {
            return View();
        }


        //LOGIN PAGE DISPLAY
        [HttpGet("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == register.Email ))
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    register.Password = Hasher.HashPassword(register, register.Password);

                    dbContext.Users.Add(register);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("UserEmail", register.Email);
                    HttpContext.Session.SetInt32("UserId", register.UserId);
                    return RedirectToAction("Dashboard", "Wedding");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult LogIn(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User userinDb = dbContext.Users.FirstOrDefault(u => u.Email == login.LoginEmail);
                if(userinDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email/password");
                    return View("SignIn");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(login, userinDb.Password, login.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email/password");
                    return View("SignIn");
                }
                else
                HttpContext.Session.SetString("UserEmail", login.LoginEmail);
                HttpContext.Session.SetInt32("UserId", userinDb.UserId);
                return RedirectToAction("Dashboard", "Wedding");
            }
            else{
                return View("SignIn");
            }
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        ///////////////////////////////////////////////////////
        //END LOGIN AND REG CONTROLLERS///////////////////////
        //////////////////////////////////////////////////////


        //////////////////////////////////////////////////
        //BEGIN WEDDING PLANNER///////////////////////////
        //////////////////////////////////////////////////




    }
}
