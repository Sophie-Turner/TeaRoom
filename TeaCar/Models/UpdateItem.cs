using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaCar.Models
{
    public class UpdateItem
    {
        public int itemId { get; set; }
        public string newItemName { get; set; }
        public string newItemInfo { get; set; }
        public bool newOnSale { get; set; }
        public decimal newItemPrice { get; set; }
        public int newCatId { get; set; }

    }
}
