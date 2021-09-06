using ProjectOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectOrders.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly OrderDbContext _context;

        public OrderDetailsService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<OrderDetails> Add(OrderDetails orderdetail)
        {
            _context.OrderDetails.Add(orderdetail);
            await _context.SaveChangesAsync();
            return orderdetail;
        }

        public Task Delete(OrderDetails orderdetail)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetails>> List()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public Task Update(OrderDetails orderdetail)
        {
            throw new NotImplementedException();
        }
    }
}
