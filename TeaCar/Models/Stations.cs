using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeaCar.Models
{
    public class Stations
    {
        [Key]
        public int stationId { get; set; }
        public String stationName { get; set; }
    }
}
