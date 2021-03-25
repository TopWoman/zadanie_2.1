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
        public DbSet<Dimensions> Dimensions { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB;Trusted_Connection=True");
        }
    }
}
