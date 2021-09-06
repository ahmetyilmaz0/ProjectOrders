using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrders.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Payment { get; set; }
        public int OrderID { get; set; }
    }
}
