using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaRoomCw.Models
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }

        public int tableNum { get; set; }
        public int completed { get; set; }
        public double totalPrice { get; set; }
        public DateTime orderTime { get; set; }
    }
}
