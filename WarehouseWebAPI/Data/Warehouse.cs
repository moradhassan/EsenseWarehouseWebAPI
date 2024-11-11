namespace WarehouseWebAPI.Data
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseManager { get; set; }
        public string Location { get;  set; }
        public bool Status { get;  set; }
        public int Capacity { get; set; }

        public List<Product> products { get; set; }

    }
}
