using DeliveryCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore
{
    class AppContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<CourierDriver> CourierDrivers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }
        public DbSet<CanceledOrder> CanceledOrders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<CompletedOrderLine> CompletedOrderLines { get; set; }
        public DbSet<CanceledOrderLine> CanceledOrderLines { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryLine> DeliveryLines { get; set; }
        public DbSet<CompletedDelivery> CompleteDeliveries { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB;Trusted_Connection=True");
        }
    }
}
