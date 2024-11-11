using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseWebAPI.Data;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Generics;

namespace WarehouseWebAPI.Services
{
    public class ProductService : IProductService
    {
        IMapper mapper;
        WareHouseContext context;
        IGeneric<Product> generic;
        public ProductService(IMapper _mapper, WareHouseContext _context, IGeneric<Product> _generic)
        {
            mapper = _mapper;
            generic = _generic;
            context = _context;
        }

        public async Task<bool> Add(ProductDTO productDTO)
        {
            var warehouse = await context.Warehouse.FirstAsync(w => w.WarehouseId == productDTO.WarehouseId);
            if (warehouse.Capacity - productDTO.Stock >= 0)
            {
                Product newProduct = mapper.Map<Product>(productDTO);
                await generic.Add(newProduct);
                return true;
            }

            return false;

        }
        public async Task<List<ProductDTO>> LoadAll(string? name,int warehouseId)
        {
            
            List<Product> allProducts = new List<Product>();
            if (!string.IsNullOrEmpty(name))
            {
                allProducts = await context.Products.Where(p => p.ProductName.Contains(name)&&p.WarehouseId== warehouseId).ToListAsync();

            }
            else
            {
                 allProducts = await context.Products.Where(p=> p.WarehouseId == warehouseId).ToListAsync();

            }

            List<ProductDTO> products = mapper.Map<List<ProductDTO>>(allProducts);
            return products;
        }

        public async Task Update(ProductDTO productDTO)
        {

            Product product = mapper.Map<Product>(productDTO);
            await generic.Update(product);

        }

        public async Task<ProductDTO> Load(int Id)
        {

            Product product = await generic.Load(Id);
            ProductDTO ProductDTO = mapper.Map<ProductDTO>(product);
            return ProductDTO;
        }

        public async Task<List<ProductDTO>> LoadByName(string name)
        {
            List<Product> products = await context.Products.Where(p=>p.ProductName.Contains(name)).ToListAsync();

            if (products == null || !products.Any())
            {
                return null;
            }
            List<ProductDTO> ProductDTO = mapper.Map<List<ProductDTO>>(products);
            return ProductDTO;
        }


        public async Task Delete(int Id)
        {
            await generic.Delete(Id);
        }
    }
}
