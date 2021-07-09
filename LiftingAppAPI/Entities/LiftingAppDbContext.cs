using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class LiftingAppDbContext : DbContext
    {
        private string _connectionString = "Server=ALBERT-PC\\LiftingAppApi;Database=LiftingAppDb;Trusted_Connection=True;";

        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }

}
