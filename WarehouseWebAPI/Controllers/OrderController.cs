using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Services;

namespace WarehouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
    
            IOrderService service;
            public OrderController(IOrderService _service) 
            {
                service = _service; 
            }


        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null) 
            {
                return BadRequest("Order is empty");
            }

          await service.Add(orderDTO);
          return Ok();

        }

        [HttpDelete]
            public async Task<IActionResult> Delete(int Id)
            {
                if (Id == 0)
                {
                    return BadRequest("Id should be greater than zero");
                }

                OrderDTO orderDTO = await service.Load(Id);
                if (orderDTO == null)
                {
                    return NotFound("Order Does Not Exist");
                }
               await  service.Delete(Id);
                return Ok();
            }


            [HttpGet]
            [Route("GetAllOrders")]
            public async Task<IActionResult> GetAllOrders(string? status,bool priceOrder=false)
            {
               return Ok(await service.LoadAll(status, priceOrder));
            }

            [HttpPut]
        
            public async Task<IActionResult> UpdateOrder(OrderDTO orderDTO)
              {
                if (orderDTO != null)
               {
                  if (orderDTO.OrderId == 0)
                  {
                    return BadRequest("Id should be greater than zero");
                  }
                  else
                  {
                    await service.Update(orderDTO);
                    return Ok(new {Message="Order Updated Successfully"});
                  }

              }
            
            return NotFound("Order Not Exists");
        }

        [HttpGet]
        [Route("LoadById")]
        public async Task<IActionResult> LoadById(int Id)
        {
            return Ok ( await service.Load(Id));

        }

    }
    
}
