using ProjectOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrders.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Orders>> GetOrdersList();
        Task<Orders> GetOrderById(int id);
        Task<Orders> CreateOrder(Orders order);
        Task UpdateOrder(Orders order);
        Task DeleteOrder(Orders order);
    }
}
