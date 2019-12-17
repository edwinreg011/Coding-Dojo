﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWTemp.Models;

namespace DojoSurveyWTemp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Survey(Survey yourSurvey)
        {
            return View(yourSurvey);
        }
    }
}
