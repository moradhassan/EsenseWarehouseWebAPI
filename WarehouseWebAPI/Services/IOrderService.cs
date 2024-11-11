using WarehouseWebAPI.DTOs;

namespace WarehouseWebAPI.Services
{
    public interface IOrderService
    {
        Task Add(OrderDTO orderDTO);
        Task Delete(int Id);
        Task<OrderDTO> Load(int Id);
        Task<List<OrderDTO>> LoadAll(string? status, bool priceOrder = false);
        Task Update(OrderDTO orderDTO);
        
    }
}