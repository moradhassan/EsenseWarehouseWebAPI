using WarehouseWebAPI.DTOs;

namespace WarehouseWebAPI.Services
{
    public interface IWarehouseService
    {
        Task Add(WarehouseDTO warehouseDTO);
        Task Delete(int Id);
        Task<WarehouseDTO> Load(int Id);
        Task<List<WarehouseDTO>> LoadAll();
        Task Update(WarehouseDTO warehouseDTO);
    }
}