using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NativeCodeTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly CodeTestDBEntities _db = new CodeTestDBEntities(); // Creating a database object to get access to the tables

        /// <summary>
        /// Editing the product.
        /// </summary>
        /// <param name="productId">A Product to </param>
        /// <returns></returns>
        public ActionResult EditProduct(int? productID, int? messageType)
        {

            if (productID == null) return RedirectToAction("Index", "Home");

            // Looking for a product depends on the id 
            var product = _db.Products.Find(productID); 

            // Displaying the success message to the user
            if (messageType != null)
            {
                ViewBag.Flag = messageType;
                @ViewBag.Message = "Price has been successfully updated.";
            }

            return View(product);
        }// end EditProduct -> HttpGet



        [HttpPost]
        [ValidateAntiForgeryToken] // Checking the token from our resources
        public ActionResult EditProduct (int? Id, Product product)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

             // Looking for a product to update.
            var productToUpdate = _db.Products.Find(Id);
            productToUpdate.Price = product.Price; 
            productToUpdate.ProductCode = product.ProductCode;

            // Updating the related product on the db 
            _db.SaveChanges(); 


            return RedirectToAction(nameof(EditProduct), new { productID = Id, messageType = 1 }); 
        }// end -> HttpPost

    }
}