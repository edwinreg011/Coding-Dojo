using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace BankAccount.Controllers
{

    //ROUTE FOR THIS CONTROLLER
    [Route("bank")]
    public class BankController : Controller
    {
        private MyContext dbContext; 
        public BankController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            User userInDb = dbContext.Users.Include(u => u.MyTransactions).FirstOrDefault(u => u.Email == HttpContext.Session.GetString("UserEmail"));
            double balance = userInDb.MyTransactions.Sum(t => t.Amount);
            ViewBag.Balance = balance;
            if(userInDb == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.User = userInDb;
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(Transaction trans)
        {
            User userInDb = dbContext.Users.Include(u => u.MyTransactions).FirstOrDefault(u => u.Email == HttpContext.Session.GetString("UserEmail"));
            double balance = userInDb.MyTransactions.Sum(t => t.Amount);

            if(userInDb == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    double calculate = balance + trans.Amount;
                    if(calculate < 0)
                    {
                        ModelState.AddModelError("Amount", "Amount can not be negative after withdrawl");
                        ViewBag.User = userInDb;
                        ViewBag.Balance = balance;
                        return View("Index");
                    }
                    else
                    {
                        trans.UserId = userInDb.UserId;
                        dbContext.Transactions.Add(trans);
                        dbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Balance = balance;
                    ViewBag.User = userInDb;
                    return View("Index");
                }
            }
        }
    }
}