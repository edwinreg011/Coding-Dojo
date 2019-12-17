using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //COUNTER
            int? attempt = HttpContext.Session.GetInt32("attempt");
            if (attempt == null)
            {
                HttpContext.Session.SetInt32("attempt", 1);
            }
            else
            {
                attempt += 1;
                HttpContext.Session.SetInt32("attempt", (int) attempt);
            }

            //RANDOM PASSCODE
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string passcode = "";
            Random rand = new Random();
            for(int i = 1; i <= 14; i++)
            {
                int x = rand.Next(0,36);
                passcode += chars[x];
            }

            //WHAT WE PASS TO TEMPLATE
            ViewBag.passcode = passcode;
            ViewBag.attempt = HttpContext.Session.GetInt32("attempt");
            return View();
        }

        [HttpGet("clear")]
        public IActionResult Clear(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }




//EXTRA STUFF
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
