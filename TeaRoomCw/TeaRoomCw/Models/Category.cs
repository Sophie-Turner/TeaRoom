using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeaRoomCw.Models
{
    public class Category
    {
        [Key]
        public int catId { get; set; }

        public string catName { get; set; }
        public string catInfo { get; set; }
        public string catPicFile { get; set; }
    }
}
