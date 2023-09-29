using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        ProductDbContext db = new ProductDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());

        }
        public ActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddItem(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditItem(int id)
        {
            var product = db.Products.First(x=> x.ProductId == id);
            return View();
        }



    }
}