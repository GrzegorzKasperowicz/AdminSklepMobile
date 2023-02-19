using AdminServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class ProductCategoryForView
    {
        public int IdProductCategory { get; set; }
        public string Title { get; set; }


        public string Description { get; set; }

        public ProductCategoryForView() { }
        public ProductCategoryForView(ProductCategory productCategory)
        {
            IdProductCategory = productCategory.IdProductCategory;
            Title = productCategory.Title;
        
            Description = productCategory.Description;
        }
    }
}
