using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOs;
using NorthWind.Sales.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.EFCore.DataContext
{
    public class NorthWindSalesContext : DbContext
    {
        public NorthWindSalesContext(DbContextOptions<NorthWindSalesContext> options)
            :base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetailt> OrderDetails { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCity)
                .HasMaxLength(15);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry)
                .HasMaxLength(15);

            modelBuilder.Entity<Order>()
               .Property(o => o.ShipPostalCode)
               .HasMaxLength(10);

            modelBuilder.Entity<OrderDetailt>()
                .HasKey(od => new { od.OrderId, od.ProductId });
        }

    }
}
