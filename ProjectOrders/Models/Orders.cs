using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrders.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string OrderName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
    }
}
