using ProjectOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrders.Services
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetails>> List();
        Task<OrderDetails> GetOrderById(int id);
        Task<OrderDetails> Add(OrderDetails orderdetail);
        Task Update(OrderDetails orderdetail);
        Task Delete(OrderDetails orderdetail);
    }
}
