using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Services;

namespace WarehouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        IWarehouseService service;
        public WarehouseController(IWarehouseService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(WarehouseDTO warehouseDTO)
        {
            await service.Add(warehouseDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Id should be greater than zero");
            }

            WarehouseDTO warehouseDTO = await service.Load(Id);
            if (warehouseDTO == null)
            {
                return NotFound("Warehouse Does Not Exist");
            }
            await service.Delete(Id);
            return Ok(new { message = "Warehouse deleted successfully" });
        }


        [HttpGet]
        [Route("GetAllWarehouses")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            return Ok(await service.LoadAll());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse(WarehouseDTO warehouseDTO)
        {
            if (warehouseDTO != null)
            {
                if (warehouseDTO.WarehouseId == 0)
                {
                    return BadRequest("Id should be greater than zero");
                }
                else
                {
                    await service.Update(warehouseDTO);
                    return Ok(new {Message="Warehouse Updated Successfully"});
                }

            }

            return NotFound("Warehouse Not Exists");
        }

        [HttpGet]
        [Route("LoadById")]
        public async Task<IActionResult> LoadById(int Id)
        {
            return Ok(await service.Load(Id));
        }
    }
}
