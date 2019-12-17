using Microsoft.AspNetCore.Mvc;

namespace portfolioI.Controllers
{
    public class HomeController : Controller
    {

        //LocalHost:5000/
        [HttpGet("")]
        public IActionResult Index(){
            return View("Index");
        }

        [HttpGet("projects")]
        public IActionResult Projects(){
            return View("Projects");
        }

        [HttpGet("contact")]
        public IActionResult Contact(){
            return View("Contact");
        }
    }
}