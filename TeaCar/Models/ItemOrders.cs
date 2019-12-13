using System;
using System.Collections.Generic;

namespace TeaCar.Models
{
    public partial class ItemOrders
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Items Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
