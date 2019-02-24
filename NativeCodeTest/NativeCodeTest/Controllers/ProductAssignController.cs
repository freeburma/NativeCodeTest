using NativeCodeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NativeCodeTest.Controllers
{
    public class ProductAssignController : Controller
    {
        private readonly CodeTestDBEntities _db = new CodeTestDBEntities(); // Creating a database object to get access to the tables

        /// <summary>
        /// Displaying the product list. So the user can edit the product category's type.
        /// </summary>
        /// <returns>A Product List</returns>
        public ActionResult ProductList()
        {
            return View(_db.Products.ToList()); 
        }// end ProductList()

        /// <summary>
        /// Editing the product category.
        /// </summary>
        /// <param name="productId">A Product to </param>
        /// <returns></returns>
        public ActionResult EditProductCateogry(int? productID, int? messageType)
        {

            if (productID == null) return RedirectToAction("Index", "Home");

            // Calling the View Model to assign both product and category list
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();

            // Looking for a product depends on the id 
            productCategoryViewModel.Product = _db.Products.Find(productID);

            // Looking for Category type 
            var categoryType = _db.ProductInCategories
                                .Where(c => c.ProductID == productID)
                                .FirstOrDefault();
            productCategoryViewModel.CategoryId = categoryType.CategoryID; 
            
            // Getting the product list 
            productCategoryViewModel.CategoryList = _db.Categories.ToList();

            // Displaying the success message to the user
            if (messageType != null)
            {
                ViewBag.Flag = messageType;
                @ViewBag.Message = "Category has been successfully updated.";
            }

            return View(productCategoryViewModel);
        }// end EditProduct -> HttpGet



        [HttpPost]
        [ValidateAntiForgeryToken] // Checking the token from our resources
        public ActionResult EditProductCateogry (int? productID, int? categoryId, ProductCategoryViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

             // Looking for a product to update.
            var productToUpdate = _db.Products.Find(productID);
            productToUpdate.Price = model.Product.Price; 
            productToUpdate.ProductCode =  model.Product.ProductCode;

            // Updating the related product on the db 
            _db.SaveChanges();

            // Updating the Category type on ProductInCategories
            var prodInCat = _db.ProductInCategories.Where(pc => pc.ProductID == productID).FirstOrDefault();
            prodInCat.CategoryID = (int) categoryId; 

            // Updating the related product on the db 
            _db.SaveChanges();


            return RedirectToAction(nameof(EditProductCateogry), new { productID = productID, messageType = 1 }); 
        }// end -> HttpPost

    }
}