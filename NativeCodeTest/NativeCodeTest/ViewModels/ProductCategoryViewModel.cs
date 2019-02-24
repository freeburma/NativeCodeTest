using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeCodeTest.ViewModels
{
    /// <summary>
    /// This ProductCategoryViewModel object has both Product and Cateogry Objects. 
    /// </summary>
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; } // Product Object 

        public int CategoryId { get; set; }
        public List<Category> CategoryList { get; set; } // Category List
    }
}