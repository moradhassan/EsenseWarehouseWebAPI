using AutoMapper;
using WarehouseWebAPI.Data;

namespace WarehouseWebAPI.DTOs
{
    [AutoMap(typeof(Warehouse), ReverseMap = true)]
    public class WarehouseDTO
    {
        public int WarehouseId { get; set; }
        public string WarehouseManager { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public int Capacity { get; set; }

       
    }
}
