using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseWebAPI.Data;
using WarehouseWebAPI.DTOs;

namespace WarehouseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        WareHouseContext context;

        public DashboardController(WareHouseContext _context)
        {
            context = _context;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashBoardInfo()
        {
            var result = new List<ChartDataDto>();

            var productCount = await context.Products.CountAsync();
            var product = new ChartDataDto
            {
                Category = "Product",
                Value = productCount
            };
            result.Add(product);

            var warehouseCount = await context.Warehouse.CountAsync();
            var warehouse = new ChartDataDto
            {
                Category = "Warehouse",
                Value = warehouseCount
            };
            result.Add(warehouse);

            var orderCount = await context.Orders.CountAsync();
            var order = new ChartDataDto
            {
                Category = "Order",
                Value = orderCount
            };
            result.Add(order);


            return Ok(result);
        }
    }
}
