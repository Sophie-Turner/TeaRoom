using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TeaCar.Models;

namespace TeaCar.Models
{
    public partial class ISAD251_STurnerContext : DbContext
    {
        public ISAD251_STurnerContext()
        {
        }

        public ISAD251_STurnerContext(DbContextOptions<ISAD251_STurnerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ItemOrders> ItemOrders { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_STurner; User Id=STurner; Password=ISAD251_22201703;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("pk_Category");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.CatInfo)
                    .HasColumnName("catInfo")
                    .HasColumnType("text");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasColumnName("catName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CatPicFile)
                    .HasColumnName("catPicFile")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemOrders>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("pk_ItemOrder");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemOrders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemOrder_Items");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ItemOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ItemOrders_Orders");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("pk_Item");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.ItemInfo)
                    .HasColumnName("itemInfo")
                    .HasColumnType("text");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPicFile)
                    .HasColumnName("itemPicFile")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("itemPrice")
                    .HasColumnType("money");

                entity.Property(e => e.OnSale).HasColumnName("onSale");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Items");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("pk_Orders");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("orderTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StaffId).HasColumnName("staffId");

                entity.Property(e => e.TableNum).HasColumnName("tableNum");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice")
                    .HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<TeaCar.Models.CurrentOrders> CurrentOrders { get; set; }
    }
}
