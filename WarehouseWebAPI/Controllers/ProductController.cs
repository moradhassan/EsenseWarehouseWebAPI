using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Services;

namespace WarehouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {

        IProductService service;
        public ProductController(IProductService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductDTO productDTO)
        {           
           
            var result = await service.Add(productDTO);
            return result ? Ok() : BadRequest(new { message = "Warehouse Capacity Overflow" });
            ;

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Id should be greater than zero");
            }

            ProductDTO productDTO = await service.Load(Id);
            if (productDTO == null)
            {
                return NotFound("Product Does Not Exist");
            }
            await service.Delete(Id);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(string? name,[FromQuery]int warehouseId)
        {
            return Ok(await service.LoadAll(name, warehouseId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
        {

            if (productDTO != null)
            {
                if (productDTO.ProductId == 0)
                {
                    return BadRequest("Id should be greater than zero");
                }
                else
                {
                    await service.Update(productDTO);
                    return Ok();
                }

            }

            return NotFound("Product Not Exists");
        }

        [HttpGet]
        [Route("LoadById")]
        public async Task<IActionResult> LoadById(int Id)
        {
            return Ok(await service.Load(Id));
        }

        //[HttpGet]
        //[Route("SearchByName")]
        //public async Task<IActionResult> SearchByName(string name)
        //{
        //    return Ok(await service.LoadByName(name));
        //}
    }
}
