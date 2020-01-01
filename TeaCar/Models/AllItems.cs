using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaCar.Models
{
    public class AllItems
    {
        public string itemName { get; set; }
        public int catId { get; set; }
        public string itemInfo { get; set; }
        public decimal itemPrice { get; set; }
        public bool onSale { get; set; }
    }
}
