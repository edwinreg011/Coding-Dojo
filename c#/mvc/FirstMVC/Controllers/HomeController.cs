using System;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        //request for localhost 5000

        [HttpGet("")]
        public IActionResult HiThere()
        {
            // Views/Home/HiThere.cshtml
            return View();
        }



        //localhost:5000/hello

        [HttpGet("hello")]
        public RedirectToActionResult Hello()
        {
            //redirecting to action call
            Console.WriteLine("###########");
            var param = new{username="Edwin", location="Chicago"};
            return RedirectToAction("HelloUser", param);
        }

        //localhost:5000/users/***

        [HttpGet("users/{username}/{location}")]
        public string HelloUser(string username, string location)
        {
            return $"Hello, {username} from {location}";
        }
    }
}