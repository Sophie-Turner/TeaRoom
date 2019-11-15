using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaRoomCw.Models
{
    public class Staff
    {
        [Key]
        public int staffId { get; set; }

        public string staffName { get; set; }
    }
}
