using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RestaurantRaterAPI.Data
{
    public class RestaurantDbContext : DbContext  
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) {}

        public DbSet<Restaurant> Restaurants {get; set;}
        public DbSet<Rating> Ratings {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant()
                {
                    Id = 1,
                    Name = "Super Mario Pasta Cavern",
                    Address = "1Up Lane"
                },
                new Restaurant()
                {
                    Id = 2,
                    Name = "Bowsers Hot Chili Shop",
                    Address = "123 GRRR CT"
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating()
                {
                    Id = 1,
                    RestaurantId = 1,
                    FoodScore = Math.Round(7.5,2),
                    EnvironmentScore = Math.Round(8.8d,2),
                    CleanlinessScore = Math.Round(10d,2)
                },
                new Rating()
                {
                    Id = 2,
                    RestaurantId = 1,
                    FoodScore = Math.Round(8.5,2),
                    EnvironmentScore = Math.Round(9.8d,2),
                    CleanlinessScore = Math.Round(9.9,2)
                },
                new Rating()
                {
                    Id = 3,
                    RestaurantId = 2,
                    FoodScore = Math.Round(3.5,2),
                    EnvironmentScore = Math.Round(5.8d,2),
                    CleanlinessScore = Math.Round(10d,2)
                },
                new Rating()
                {
                    Id = 4,
                    RestaurantId = 2,
                    FoodScore = Math.Round(6.5,2),
                    EnvironmentScore = Math.Round(6.8d,2),
                    CleanlinessScore = Math.Round(7.0d,2)
                }
            );
        }

    }
}