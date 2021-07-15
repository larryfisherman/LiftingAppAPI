using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class LiftingAppDbContext : DbContext
    {
        private string _connectionString = "Server=LAPTOP-0LINFDL7\\LIFTINGAPPAPI;Database=LiftingAppDb;Trusted_Connection=True;";

        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workouts> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var recipe = modelBuilder.Entity<Recipes>();
            recipe.Property(r => r.Name).IsRequired().HasMaxLength(25);
            recipe.Property(r => r.Calories).IsRequired().HasMaxLength(4);
            recipe.Property(r => r.Carbo).IsRequired().HasMaxLength(4);
            recipe.Property(r => r.Proteins).IsRequired().HasMaxLength(4);

            var account = modelBuilder.Entity<User>();
            account.Property(a => a.Email).IsRequired();
            account.Property(a => a.PasswordHash).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }

}
