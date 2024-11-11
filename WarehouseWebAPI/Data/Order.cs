using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseWebAPI.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public double? TotalPrice { get; set; }
        public string Status { get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }
        public Product? product { get; set; }

       

        //public Order(int orderId, string status, int quantity, double totalPrice,
        //            string customerName, string shippingAddress, string paymentMethod,
        //            int productId,string productName)
        //{
        //    OrderId = orderId;
        //    Status = status;
        //    Quantity = quantity;
        //    TotalPrice = totalPrice;
        //    CustomerName = customerName;
        //    ShippingAddress = shippingAddress;
        //    PaymentMethod = paymentMethod;
        //    product.ProductId = productId;
        //    product.ProductName = productName;
        //}
        //public Order()
        //{
        //}
    }
}