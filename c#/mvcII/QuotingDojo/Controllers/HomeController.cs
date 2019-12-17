using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //post quote in database
        [HttpPost("quotes")]
        public IActionResult Create(Quote newQuote)
        {
            string query = $"INSERT INTO quotes (Name, Content, created_at, updated_at) values ('{newQuote.Name}', '{newQuote.Content}', NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");
        }

        //DISPLAY ALL
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.info = AllUsers;
            return View();
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
