using AutoMapper;
using WarehouseWebAPI.Data;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Generics;

namespace WarehouseWebAPI.Services
{
    public class WarehouseService : IWarehouseService
    {
        IMapper mapper;
        WareHouseContext context;
        IGeneric<Warehouse> generic;
        public WarehouseService(IMapper _mapper, WareHouseContext _context, IGeneric<Warehouse> _generic)
        {
            mapper = _mapper;
            generic = _generic;
            context = _context;
        }

        public async Task Add(WarehouseDTO warehouseDTO)
        {

            Warehouse newWarehouse = mapper.Map<Warehouse>(warehouseDTO);
            await generic.Add(newWarehouse);

        }
        public async Task<List<WarehouseDTO>> LoadAll()
        {
            List<Warehouse> allWarehouses = await generic.LoadAll();

            List<WarehouseDTO> warehouse = mapper.Map<List<WarehouseDTO>>(allWarehouses);
            return warehouse;
        }

        public async Task Update(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse = mapper.Map<Warehouse>(warehouseDTO);
            await generic.Update(warehouse);
        }

        public async Task<WarehouseDTO> Load(int Id)
        {
            Warehouse warehouse = await generic.Load(Id);
            WarehouseDTO WarehouseDTO = mapper.Map<WarehouseDTO>(warehouse);
            return WarehouseDTO;
        }


        public async Task Delete(int Id)
        {
            await generic.Delete(Id);
        }
    }
}
