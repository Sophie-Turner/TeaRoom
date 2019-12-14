using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaCar.Models
{
    public class CreateNewItem
    {
        public string itemName { get; set; }
        public string itemInfo { get; set; }
        public string itemPicFile { get; set; }
        public int onSale { get; set; }
        public decimal itemPrice { get; set; }
        public int catId { get; set; }
    }
}
