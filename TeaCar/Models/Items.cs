using System;
using System.Collections.Generic;

namespace TeaCar.Models
{
    public partial class Items
    {
        public Items()
        {
            ItemOrders = new HashSet<ItemOrders>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemInfo { get; set; }
        public string ItemPicFile { get; set; }
        public bool OnSale { get; set; }
        public decimal ItemPrice { get; set; }
        public int CatId { get; set; }

        public virtual Categories Cat { get; set; }
        public virtual ICollection<ItemOrders> ItemOrders { get; set; }
    }
}
