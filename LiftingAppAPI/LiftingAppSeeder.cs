using LiftingAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyClone
{
    public class LiftingAppSeeder
    {
        private readonly LiftingAppDbContext _dbContext;

        public LiftingAppSeeder(LiftingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Recipes.Any())
                {
                    var recipes = GetRecipes();
                    _dbContext.Recipes.AddRange(recipes);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Recipes> GetRecipes()
        {
            var recipes = new List<Recipes>()
            {
                new Recipes()
                {
                    Name = "Protein omlette",
                    Description = "A jumbo sweet semi thick omelette laced with Pulsin's Natural Vanilla Whey Protein for sweetness which is ideal for filling and topping with berries, yogurt, a little maple syrup and whatever other goodies you fancy.",
                    Proteins = "23g",
                    Carbo = "65g",
                    Fat = "12g",
                    Calories = "468kcal",
                    Type = "reduction",
                    Recipe = "2 large whole eggs, 10g Pulsin Vanilla Whey Protein, 1 tbsp milk of choice¼ cup (60ml),  egg whites (2 large egg whites), 2 tsp butter"
                }
            };

            return recipes;
        }

    }
}