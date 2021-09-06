using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrders.Models
{
    public class DataGenerator
    {
        public static void Initialize(OrderDbContext context)
        {

            // Look for any board games.
            if (context.Orders.Any())
            {
                return;   // Data was already seeded
            }
            context.OrderDetails.AddRange(
                new OrderDetails
                {
                    OrderDetailID = 1,
                    Payment = "It can be detail Payment Success!",
                    OrderID = 1
                },
                new OrderDetails
                {
                    OrderDetailID = 2,
                    Payment = "It can be money 150$",
                    OrderID = 2
                },
                new OrderDetails
                {
                    OrderDetailID = 3,
                    Payment = "It can be order payment.",
                    OrderID = 3
                },
                new OrderDetails
                {
                    OrderDetailID = 4,
                    Payment = "According to the program we can change it.",
                    OrderID = 4
                },
                new OrderDetails
                {
                    OrderDetailID = 5,
                    Payment = "This is order payment detail.",
                    OrderID = 5
                }
                );
            context.SaveChanges();
            var data = context.OrderDetails.FirstOrDefault(x => x.OrderID == 1);
            context.Orders.AddRange(
                    new Orders
                    {
                        OrderID = 1,
                        OrderName = "Candy Land",
                        Description = "This is order description.",
                        OrderDetails = context.OrderDetails.FirstOrDefault(x => x.OrderID == 1)
                    },
                    new Orders
                    {
                        OrderID = 2,
                        OrderName = "Sorry!",
                        Description = "This should not be empty!",
                        OrderDetails = context.OrderDetails.FirstOrDefault(x => x.OrderID == 2)
                    },
                    new Orders
                    {
                        OrderID = 3,
                        OrderName = "Ticket to ROrderIDe",
                        Description = "It can show something about this order.",
                        OrderDetails = context.OrderDetails.FirstOrDefault(x => x.OrderID == 3)
                    },
                    new Orders
                    {
                        OrderID = 4,
                        OrderName = "The Settlers of Catan (Expanded)",
                        Description = "It belongs something about this order.",
                        OrderDetails = context.OrderDetails.FirstOrDefault(x => x.OrderID == 4)
                    },
                    new Orders
                    {
                        OrderID = 5,
                        OrderName = "Carcasonne",
                        Description = "This is order description.",
                        OrderDetails = context.OrderDetails.FirstOrDefault(x => x.OrderID == 5)
                    });
            context.SaveChanges();
        }
    }
}
