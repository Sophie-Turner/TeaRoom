using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaCar.Models
{
    public class CustomerMenu
    {
        [Key]
        public int itemId { get; set; }
        
        public string itemName { get; set; }
        public string itemInfo { get; set; }
        public decimal itemPrice { get; set; }
        public int catId { get; set; }
    }
}
