using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WarehouseWebAPI.Data;
using WarehouseWebAPI.DTOs;
using WarehouseWebAPI.Generics;

namespace WarehouseWebAPI.Services
{
    public class OrderService : IOrderService
    {
        IMapper mapper;
        WareHouseContext context;
        IGeneric<Order> generic;
        public OrderService(IMapper _mapper, WareHouseContext _context, IGeneric<Order> _generic)
        {
            mapper = _mapper;
            generic = _generic;
            context = _context;
        }

        public async Task Add(OrderDTO orderDTO)
        {
            try
            {
                var product =  await context.Products.FirstAsync(p => p.ProductId == orderDTO.ProductId);

                if(product.Stock - orderDTO.Quantity >= 0) { 
                product.Stock = product.Stock - orderDTO.Quantity;
                double price = product.Price;

                Order newOrder = new Order
                {
                    OrderId = orderDTO.OrderId,
                    Status = orderDTO.Status,
                    Quantity = orderDTO.Quantity,
                    TotalPrice = orderDTO.Quantity * price,
                    CustomerName = orderDTO.CustomerName,
                    ShippingAddress = orderDTO.ShippingAddress,
                    PaymentMethod = orderDTO.PaymentMethod,
                    ProductId = orderDTO.ProductId,
               
                };
                context.Products.Update(product);
                await context.SaveChangesAsync();
                await generic.Add(newOrder);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("An Error Occurd :" +ex.Message, ex);
            }
        }


        public async Task<List<OrderDTO>> LoadAll(string? status, bool priceOrder = false)
        {
            IQueryable<Order> query = context.Orders.Include(p => p.product);

         
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Status.ToLower() == status.ToLower());
            }


            if (priceOrder)
            {
                query = query.OrderBy(o => o.TotalPrice);
            }
            else
            {
                query = query.OrderByDescending(o => o.TotalPrice);
            }


            List<Order> orders = await query.ToListAsync();
            List<OrderDTO> orderDTO = mapper.Map<List<OrderDTO>>(orders);

            return orderDTO;
        }

        public async Task Update(OrderDTO orderDTO)
        {
            var product = await context.Products.FirstAsync(p => p.ProductId == orderDTO.ProductId);
            double price = product.Price;
            orderDTO.TotalPrice = price*orderDTO.Quantity;
            

            Order order = mapper.Map<Order>(orderDTO);
            await generic.Update(order);

        }

        public async Task<OrderDTO> Load(int Id)
        {

            Order order = await context.Orders.Where(o=>o.OrderId==Id).Include(p => p.product).FirstOrDefaultAsync();
            OrderDTO orderDTO = mapper.Map<OrderDTO>(order);
            return orderDTO;

        }


        public async Task Delete(int Id)
        {
            await generic.Delete(Id);
        }


    }
}
