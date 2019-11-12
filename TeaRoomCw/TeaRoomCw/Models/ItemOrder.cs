using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaRoomCw.Models
{
    public class ItemOrder
    {
        [Key]
        public int orderId { get; set; }

        public int itemId { get; set; }
        public int quantity { get; set; }
    }
}
