using DefinitiveChallenge.API.Entities;
using DefinitiveChallenge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DefinitiveChallenge.API.DbContexts
{
    public class ProductInfoContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public ProductInfoContext(DbContextOptions<ProductInfoContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                new Product()
                {
                    Id = 1,
                    Description = "Automovil Twingo",
                    Type = "Vehículos",
                    Value = 20000000.00,
                    BuyDate = new DateTime(2022, 3, 28),
                    State = true
                },

                new Product()
                {
                    Id = 2,
                    Description = "Finca con piscina, salón de juegos, patio, cuarto de cocina, cuarto de ropas y 8 habitaciones",
                    Type = "Bienes",
                    Value = 400000000.00,
                    BuyDate = new DateTime(2022, 3, 28),
                    State = false
                },

                new Product()
                {
                    Id = 3,
                    Description = "Telefono móvil iphone 14",
                    Type = "Bienes",
                    Value = 5487599.99,
                    BuyDate = new DateTime(2022, 3, 28),
                    State = true
                });
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
