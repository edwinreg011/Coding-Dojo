using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace BeltExam.Controllers
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
                HttpContext.Session.SetInt32("UserId", userinDb.UserId);
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
            ViewBag.User = userinDb;
            List<Meeting> AllMeetings = dbContext.Meetings.OrderBy(x=>x.Date).OrderBy(z=>z.Time).Include(a=>a.ComingList).ThenInclude(b=>b.Invited).Include(c=>c.Planner).ToList();
            if(userinDb == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            return View(AllMeetings);
        }

        ///////////////////////////////////////////////////////
        //END LOGIN AND REG CONTROLLERS///////////////////////
        //////////////////////////////////////////////////////


        //////////////////////////////////////////////////
        //BELT EXAM///////////////////////////////////////
        //////////////////////////////////////////////////

        //CREATE NEW ACTIVITY FORM  
        [HttpGet("new/activity")]
        public IActionResult AddMeeting()
        {
            if(HttpContext.Session.GetString("UserEmail")==null)
            {
                return RedirectToAction("LogOut");
            }

            else
            {   
                User userinDb = dbContext.Users.Include(u=>u.PlannedMeetings).FirstOrDefault(a=>a.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.User = userinDb;
                return View();
            }
        }

        //POST ACTIVITY TO DB
        [HttpPost("create")]
        public IActionResult Create (Meeting newMeet)
        {
            if(HttpContext.Session.GetString("UserEmail")==null)
            {
                return RedirectToAction("LogOut");
            }

            else
            {   
                if(ModelState.IsValid)
                {
                    dbContext.Meetings.Add(newMeet);
                    dbContext.SaveChanges();
                    return Redirect($"view/{newMeet.MeetingId}");
                }
                else
                {
                User userinDb = dbContext.Users.Include(u=>u.PlannedMeetings).FirstOrDefault(a=>a.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.User = userinDb;
                return View("AddMeeting");
                }
            }
        }

        //VIEW ACTIVITY
        [HttpGet("view/{meetingId}")]
        public IActionResult ViewActivity(int meetingId)
        {
            if(HttpContext.Session.GetString("UserEmail")==null)
            {
                return RedirectToAction("LogOut");
            }

            else
            {   
                User userinDb = dbContext.Users.Include(u=>u.PlannedMeetings).FirstOrDefault(a=>a.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.User = userinDb;

                Meeting vMeet = dbContext.Meetings.Include(b=>b.ComingList).ThenInclude(c=>c.Invited).Include(x=>x.Planner).FirstOrDefault(a=> a.MeetingId == meetingId);

                return View(vMeet);
            }
        }
        //DELETE ACTIVITY 
        [HttpGet("delete/{meetingId}")]
        public IActionResult Destroy(int meetingId)
        {
            if(HttpContext.Session.GetString("UserEmail")==null)
            {
                return RedirectToAction("LogOut");
            }

            else
            {   
                Meeting DelMeet = dbContext.Meetings.FirstOrDefault(a=>a.MeetingId == meetingId);
                dbContext.Meetings.Remove(DelMeet);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        //JOIN / LEAVE OPTION FOR ATTENDEES
        [HttpGet("coming/{meetingId}/{userId}/{status}")]
        public IActionResult JoinLeave(int meetingId, int userId, string status)
        {
            if(HttpContext.Session.GetString("UserEmail")==null)
            {
                return RedirectToAction("LogOut");
            }

            else
            {   
                if(status == "add")
                {
                    Attendant newPerson = new Attendant();
                    newPerson.UserId = userId;
                    newPerson.MeetingId = meetingId;
                    dbContext.Attendants.Add(newPerson);
                    dbContext.SaveChanges();
                }
                if(status == "remove")
                {
                    Attendant remove = dbContext.Attendants.FirstOrDefault(x=>x.MeetingId == meetingId && x.UserId == userId);
                    dbContext.Attendants.Remove(remove);
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Dashboard");
        }
    }
}
