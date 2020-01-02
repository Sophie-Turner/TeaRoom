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
        public DateTime OrderTime { get; set; }
        
        public int tableNum { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
    }
}
