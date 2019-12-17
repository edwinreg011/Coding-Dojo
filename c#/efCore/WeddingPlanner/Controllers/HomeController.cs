using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace WeddingPlanner.Controllers
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

        //////////////////////////
        //localhost 5000 reg page 
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
                    ////////////////////////////
                    ///////////////////////////
                    HttpContext.Session.SetInt32("UserId", register.UserId);
                    ////////////////////////////
                    ///////////////////////////
                    return RedirectToAction("Dashboard");
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
                ////////////////////////////
                ///////////////////////////
                HttpContext.Session.SetInt32("UserId", userinDb.UserId);
                ////////////////////////////
                ///////////////////////////
                return RedirectToAction("Dashboard");
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

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User userinDb = dbContext.Users.FirstOrDefault(u => u.Email == HttpContext.Session.GetString("UserEmail"));
            string loggedUser = HttpContext.Session.GetString("UserEmail");
            if(userinDb == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            List<Wedding> AllWeddings = dbContext.Weddings.Include(a => a.Users).ThenInclude(b => b.User).ToList();
            ViewBag.Creator = loggedUser;
            return View(AllWeddings);
        }

        ///////////////////////////////////////////////////////
        //END LOGIN AND REG CONTROLLERS///////////////////////
        //////////////////////////////////////////////////////




        //////////////////////////////////////////////////
        //BEGIN WEDDING PLANNER///////////////////////////
        //////////////////////////////////////////////////


        //DISPLAY WEDDING CREATION FORM 
        [HttpGet("newwedding")]
        public IActionResult CreateWedding()
        {
            return View();
        }

        //CREATE WEDDING IN DB
        [HttpPost("processwedding")]
        public IActionResult ProcessWedding(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                string loggedUser = HttpContext.Session.GetString("UserEmail");
                newWedding.Creator = loggedUser;
                dbContext.Weddings.Add(newWedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("CreateWedding");
            }
        }

        //VIEW WEDDING AND GUESTS
        [HttpGet("{wed_id}")]
        public IActionResult DispWed(int wed_id)
        {
            Wedding DispWedding = dbContext.Weddings.Include(a => a.Users).ThenInclude(b => b.User).FirstOrDefault(c => c.WeddingId == wed_id);


            return View(DispWedding);
        }

        //DELETE WEDDING
        [HttpGet("delete/{wed_id}")]
        public IActionResult DelWed(int wed_id)
        {
            Wedding retWed = dbContext.Weddings.FirstOrDefault(weddings => weddings.WeddingId == wed_id);
            dbContext.Weddings.Remove(retWed);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        //ADD GUEST TO WEDDING
        [HttpGet("rsvp")]
        public IActionResult RSVPWed(int wed_id)
        {
            Wedding rsvpWedding = dbContext.Weddings.FirstOrDefault(u => u.WeddingId == wed_id);
            User rsvpUser = dbContext.Users.FirstOrDefault(e => e.Email == HttpContext.Session.GetString("UserEmail"));
            Rsvp newRsvp = new Rsvp();
            newRsvp.UserId = rsvpUser.UserId;
            newRsvp.WeddingId = wed_id;
            dbContext.Add(newRsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("unrsvp")]
        public IActionResult UNRSVPWed(int wed_id)
        {

            IEnumerable <Rsvp> users = dbContext.Rsvps.Where(a => a.WeddingId == wed_id);

            Rsvp rsvpUser = users.SingleOrDefault(e => e.UserId == HttpContext.Session.GetInt32("UserId"));

            dbContext.Remove(rsvpUser);
            dbContext.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}
