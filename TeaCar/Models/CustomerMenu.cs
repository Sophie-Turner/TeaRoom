using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TeaCar.Models
{
    public class CustomerMenu
    {
        [Key]
        [JsonIgnore]
        public int itemId { get; set; }
        
        public string itemName { get; set; }
        public string itemInfo { get; set; }
        public decimal itemPrice { get; set; }
        public int catId { get; set; }
    }
}
