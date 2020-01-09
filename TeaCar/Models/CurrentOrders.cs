using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaCar.Models
{
    public class CurrentOrders
    {
        [Key]
        public DateTime orderTime { get; set; }

        public int orderId { get; set; }
        public int tableNum { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
    }
}
