using Data.Model;
using Utils.Extensions;

namespace API.Model
{
    public class OrderForView
    {
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int IdProduct { get; set; }
        public string ProductTitle { get; set; }
        public double Quantity { get; set; }
        public double Total { get; set; }
        public int IdClient { get; set; }
        public string ClientLastName { get; set; }


        public static explicit operator Order(OrderForView orderForView)
        {
            return new Order().CopyPropertiesReturnExtension(orderForView);
        }
        public static explicit operator OrderForView(Order order)
        {
            var orderForView = new OrderForView().CopyPropertiesReturnExtension(order);
            orderForView.ProductTitle = order.Product?.Title;
            orderForView.ClientLastName = order.Client?.LastName;
            return orderForView;
        }
    }
}
