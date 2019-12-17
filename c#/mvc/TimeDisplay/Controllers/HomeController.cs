using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class HomeController : Controller
    {
        //request for localhost5000/

        [HttpGet("")]

        public IActionResult Index(){
            return View();
        }
    }
}