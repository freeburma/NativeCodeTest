using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NativeCodeTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index ()
        {
            return View();
        }

        public ActionResult Products ()
        {
            using (CodeTestDBEntities db = new CodeTestDBEntities())
            {
                var p = db.Categories;
                return View(p.ToList<Category>());
            }

        }

        [HttpGet]
        // [ValidateAntiForgeryToken]
        public JsonResult ProductsInCategory (int categoryID)
        {
            using (CodeTestDBEntities db = new CodeTestDBEntities())
            {
                var category = from c in db.Categories select c;

                
                // Complete this, its wrong at the moment as it returns all products.
                // This is Many to Many relationship.
                var _products = (from pc in db.ProductInCategories  // Getting ProductInCategories data
                                 join p in db.Products              // Getting the Products with Inner Join
                                 on pc.ProductID equals p.Id        // Searching the with Id, return only the records which exist on both tables
                                 where pc.CategoryID == categoryID  // Filtering with Category ID 
                                 select p);

                return Json(_products.ToList<Product>(), JsonRequestBehavior.AllowGet); // Returning the Product List as JSON object

            }

            // return Json("OK", JsonRequestBehavior.AllowGet); // Testing purpose. Return OK message.

        }
    }
}