using Data.Model;
using Utils.Extensions;

namespace API.Model
{
    public class ProductForView
    {
        public int IdProduct { get; set; }
        public string Code { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int IdProductCategory { get; set; }
        public string ProductCategoryTitle { get; set; }
        public int IdProductType { get; set; }
        public string ProductTypeTitle { get; set; }
        public int IdProductProducer { get; set; }
        public string ProductProducerTitle { get; set; }

        public static explicit operator Product(ProductForView productForView)
        {
            return new Product().CopyPropertiesReturnExtension(productForView);
        }
        public static explicit operator ProductForView(Product product)
        {
            var productForView = new ProductForView().CopyPropertiesReturnExtension(product);
            productForView.ProductCategoryTitle = product.ProductCategory?.Title;
            productForView.ProductProducerTitle = product.ProductProducer?.Title;
            productForView.ProductTypeTitle = product.ProductType?.Title;
            return productForView;
        }
    }
}
