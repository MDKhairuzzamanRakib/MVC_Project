using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            return View(product);
        }
        [HttpPost]
        public ActionResult EditItem(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult DeleteItem(int id)
        {
            var product = db.Products.First(x => x.ProductId == id);
            return View(product);
        }
        [HttpPost]
        [ActionName("DeleteItem")]
        public ActionResult DoDelete(int id)
        {
            var p = new Product { ProductId=id};
            db.Entry(p).State=System.Data.Entity.EntityState.Deleted; 
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }

    }
}