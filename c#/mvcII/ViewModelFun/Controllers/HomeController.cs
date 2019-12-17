using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Message somemessage = new Message
            {
                Msg = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi obcaecati atque ratione architecto quidem quos odio porro a quis minima consequatur, excepturi eligendi debitis voluptatibus repudiandae dolores sint natus maiores?"
            };
            return View(somemessage);
        }


        //display array of ints
        [HttpGet("numbers")]
        public IActionResult Numbers(){
            Number num = new Number()
            {
                numberList = new int[] {1,2,3,10,43,5}
            };
            return View(num);
        }


        //display one user
        [HttpGet("user")]
        public IActionResult UserPage(){
            User someuser = new User()
            {
                FirstName = "Edwin",
                LastName = "Regalado"
            };
            return View(someuser);
        }


        //display list of users
        [HttpGet("users")]
        public IActionResult ManyUsers(){
            User someuser = new User()
            {
                FirstName = "Edwin",
                LastName = "Regalado"
            };

            User auser = new User()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            User anotheruser = new User()
            {
                FirstName = "Jane",
                LastName = "Doe"
            };

            List<User> viewModel = new List<User>()
            {
                someuser, auser, anotheruser
            };
            return View(viewModel);
        }
    }
}
