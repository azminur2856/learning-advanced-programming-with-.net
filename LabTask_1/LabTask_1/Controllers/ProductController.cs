using LabTask_1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask_1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        LabTask_1Entities db = new LabTask_1Entities();
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            var product = db.Products.Find(pro.Id);
            product.Name = pro.Name;
            product.Price = pro.Price;
            product.Qty = pro.Qty;
            product.Description = pro.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["Id"]);
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}