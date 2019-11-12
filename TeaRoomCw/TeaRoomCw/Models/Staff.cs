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
        private int staffId { get; set; }

        private string staffName { get; set; }
    }
}
