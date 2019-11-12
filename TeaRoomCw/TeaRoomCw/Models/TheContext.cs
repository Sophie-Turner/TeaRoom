using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeaRoomCw.Models
{
    public class TheContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public TheContext(DbContextOptions<TheContext> options) : base(options) { }

    }
}
