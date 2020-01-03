using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaCar.Models
{
    public class IncompleteOrders
    {
        [Key]
        public string itemName { get; set; }

        public int quantity { get; set; }
        public decimal itemPrice { get; set; }
    }
}
