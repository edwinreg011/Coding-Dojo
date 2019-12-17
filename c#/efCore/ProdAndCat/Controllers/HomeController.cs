using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdAndCat.Models;

namespace ProdAndCat.Controllers
{
    public class HomeController : Controller
    {
        //DEP INJECTION
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        //REQUEST FOR
        public IActionResult Index()
        {
            return View();
        }


        //REQUEST FOR ADD PRODUCT FORM AND DISPLAY ALL PRODUCTS 
        [HttpGet("products")]
        public IActionResult AllProducts()
        {
            List<Product> AllProducts = dbContext.Products.Include(p => p.Categories).ThenInclude(a => a.Category).ToList();
            ViewBag.Products = AllProducts;
            return View();
        }
        //POST REQUEST FOR PRODUCT 
        [HttpPost("create/product")]
        public IActionResult CreateProd(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            else
            {
                List<Product> AllProducts = dbContext.Products.Include(p => p.Categories).ThenInclude(a => a.Category).ToList();
                ViewBag.Products = AllProducts;
                return View("AllProducts");
            }
        }

        //VIEW PRODUCT AND ITS CATS 
        [HttpGet("{prod_id}")]
        public IActionResult DispProd(int prod_id)
        {
            Product DispProduct = dbContext.Products.Include(p => p.Categories).ThenInclude(a => a.Category).FirstOrDefault(b=>b.ProductId == prod_id);

            List<Category> NotOnProduct = dbContext.Categories.Include(c=>c.Products).Where(c=>c.Products.All(a=>a.ProductId!= prod_id)).ToList();
            ViewBag.NotCats = NotOnProduct;


            return View(DispProduct);
        }

        //ADD CAT TO PRODUCT

        [HttpPost("categoryadd")]
        public IActionResult AddCat(int productId, int CategoryId)
        {
            Association newCategory = new Association();
            newCategory.ProductId = productId;
            newCategory.CategoryId = CategoryId;
            dbContext.Associations.Add(newCategory);
            dbContext.SaveChanges();
            return RedirectToAction("AllProducts");
        }














        //REQUEST FOR CATEGORIES PAGE WITH ALL CATEGORIES DISPLAYED
        [HttpGet("categories")]
        public IActionResult AllCategories()
        {
            List<Category> AllCats = dbContext.Categories.Include(a => a.Products).ThenInclude(p=>p.Product).ToList();
            ViewBag.AllCats = AllCats;
            return View();
        }

        //POST REQUEST FOR CATEGORY
        public IActionResult CreateCat(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                dbContext.Categories.Add(newCategory);
                dbContext.SaveChanges();
                return RedirectToAction("AllCategories");
            }
            else
            {
                List<Category> AllCats = dbContext.Categories.Include(a => a.Products).ThenInclude(p=>p.Product).ToList();
                ViewBag.AllCats = AllCats;
                return View("AllCategories");
            }
        }

        [HttpGet("category/{cat_id}")]
        public IActionResult DispCats(int cat_id)
        {
            Category DispCategory = dbContext.Categories.Include(p=>p.Products).ThenInclude(a=>a.Product).FirstOrDefault(b=>b.CategoryId == cat_id);

            List<Product> NotInCategory = dbContext.Products.Include(c=>c.Categories).Where(c=>c.Categories.All(a=>a.CategoryId!=cat_id)).ToList();
            ViewBag.NotProd = NotInCategory;
            return View(DispCategory);
        }

        [HttpPost("productadd")]
        public IActionResult AddProd(int categoryId, int ProductId)
        {
            Association newProduct = new Association();
            newProduct.CategoryId = categoryId;
            newProduct.ProductId = ProductId;
            dbContext.Associations.Add(newProduct);
            dbContext.SaveChanges();
            return RedirectToAction("AllCategories");
        }
    }
}
