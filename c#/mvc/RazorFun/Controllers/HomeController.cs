using System;
using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers
{
    public class HomeController : Controller
    {
        // request for localhost: 5000/ 

        [HttpGet("")]

        public IActionResult Index()
        {
            return View();
        }
    }
}