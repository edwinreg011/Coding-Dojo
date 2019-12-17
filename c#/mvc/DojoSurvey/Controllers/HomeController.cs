using System;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class HomeController: Controller
    {
        //request for localhost 5000/

        [HttpGet("")]
        public IActionResult Index(){
            return View();
        }

        //post request for form
        [HttpPost("process")]
        public IActionResult Survey(string name, string location, string language, string comments){
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comments = comments;
            ViewBag.Date = DateTime.Now;


            return View();
        }
    }
}