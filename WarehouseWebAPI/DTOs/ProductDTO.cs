using AutoMapper;
using WarehouseWebAPI.Data;

namespace WarehouseWebAPI.DTOs
{
    [AutoMap(typeof(Product), ReverseMap = true)]
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Stock { get; set; }
        public int WarehouseId { get; set; }
    }
}
