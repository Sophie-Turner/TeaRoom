using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaCar.Models
{
    public class CreateNewItemOrder
    {
        public int orderId { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
    }
}
