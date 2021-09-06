using Microsoft.EntityFrameworkCore;
using ProjectOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OrderDbContext _context;
        private readonly IOrderDetailsService _orderDetailsService;
        public OrdersService(OrderDbContext context,IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetOrdersList()
        {
            return await _context.Orders
                .Include(x => x.OrderDetails)
                .ToListAsync();
        }

        public async Task<Orders> GetOrderById(int id)
        {
            return await _context.Orders
                .Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.OrderID == id);
        }

        public async Task<Orders> CreateOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.OrderDetails.Add(order.OrderDetails);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrder(Orders order)
        {
            _context.Orders.Update(order);
            _context.OrderDetails.Update(order.OrderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Orders order)
        {
            _context.Orders.Remove(order);
            _context.OrderDetails.Remove(order.OrderDetails);
            await _context.SaveChangesAsync();
        }
    }
}
