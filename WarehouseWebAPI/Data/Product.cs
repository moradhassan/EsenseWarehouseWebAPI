using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseWebAPI.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Stock { get; set; }
        public List<Order> orders { get; set; }
        public Warehouse wareHouse { get; set; }

        [ForeignKey("wareHouse")]
        public int WarehouseId { get; set; }

    }
}
