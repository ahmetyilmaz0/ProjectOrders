using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOrders.Models;
using ProjectOrders.Services;

namespace ProjectOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _context;
        private readonly IOrdersService _ordersService;
        private readonly IOrderDetailsService _orderDetailsService;

        public OrdersController(OrderDbContext context,IOrdersService ordersService,IOrderDetailsService orderDetailsService)
        {
            _ordersService = ordersService;
            _orderDetailsService = orderDetailsService;
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await _ordersService.GetOrdersList();
            //return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            //var orders = await _context.Orders.FindAsync(id);
            var orders = await _ordersService.GetOrderById(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.OrderID)
            {
                return BadRequest();
            }

            //_context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _ordersService.UpdateOrder(orders);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            await _ordersService.CreateOrder(orders);
            //_context.Orders.Add(orders);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.OrderID }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            //var orderdetails = await _context.OrderDetails.FindAsync(x);
            if (orders == null)
            {
                return NotFound();
            }
            
            _context.Orders.Remove(orders);

            //if (orderdetails != null)
            //    _context.OrderDetails.Remove(orderdetails);

            await _context.SaveChangesAsync();

            //var data = _context.OrderDetails.ToList();

            return NoContent();
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
