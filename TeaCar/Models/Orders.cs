using System;
using System.Collections.Generic;

namespace TeaCar.Models
{
    public partial class Orders
    {
        public Orders()
        {
            ItemOrders = new HashSet<ItemOrders>();
        }

        public int OrderId { get; set; }
        public int TableNum { get; set; }
        public bool Completed { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public int StaffId { get; set; }

        public virtual ICollection<ItemOrders> ItemOrders { get; set; }
    }
}
