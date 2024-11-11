using WarehouseWebAPI.DTOs;

namespace WarehouseWebAPI.Services
{
    public interface IProductService
    {
        Task<bool> Add(ProductDTO productDTO);
        Task Delete(int Id);
        Task<ProductDTO> Load(int Id);
        Task<List<ProductDTO>> LoadAll(string? name, int warehouseId);
        Task Update(ProductDTO productDTO);

        Task<List<ProductDTO>> LoadByName(string name);
    }
}