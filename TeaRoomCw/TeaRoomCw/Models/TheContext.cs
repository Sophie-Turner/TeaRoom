using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeaRoomCw.Models
{
    public class TheContext : DbContext
    {
        public TheContext(DbContextOptions<TheContext> options) : base(options) { }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ItemOrders> ItemOrders { get; set; }
        public DbSet<Orders> Orders { get; set; }   

    }
}
