using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaRoomCw.Models
{
    public class Items
    {
        [Key]
        public int itemId { get; set; }

        public string itemName { get; set; }
        public string itemInfo { get; set; }
        public string itemPicFile { get; set; }
        public int onSale { get; set; }
        public double itemPrice { get; set; }
        public int catId { get; set; }
    }
}
