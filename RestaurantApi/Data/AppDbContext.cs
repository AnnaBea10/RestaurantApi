using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantApi.Models;

namespace RestaurantApi.Data{

    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlite("DataSource = app.db; Cache = Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Order>()
            .HasKey(c => c.Id);
        }
    }
}