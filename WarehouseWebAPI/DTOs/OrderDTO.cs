using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseWebAPI.Data;

namespace WarehouseWebAPI.DTOs
{
    [AutoMap(typeof(Order),ReverseMap =true)]
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public double? TotalPrice { get; set; }
        public string Status { get; set; }
        public int ProductId { get; set; }
        public ProductDTO? Product { get; set; }



    }
}
