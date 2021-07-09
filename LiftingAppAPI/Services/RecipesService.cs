using AutoMapper;
using LiftingAppAPI.Entities;
using LiftingAppAPI.Exceptions;
using LiftingAppAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Services
{
    public interface IRecipesService
    {
        public int Create(CreateRecipeDto dto);
        public void Delete(int id);
        public IEnumerable<Recipes> GetAllRecipes();
    }
    public class RecipesService : IRecipesService
    {
        private readonly LiftingAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public RecipesService(LiftingAppDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public int Create(CreateRecipeDto dto)
        {
            var recipe = _mapper.Map<Recipes>(dto);
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();

            return recipe.Id;
        }

        public void Delete(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == id);
            
            if(recipe is null)
            {
                throw new NotFoundException("Recipe not found"); 
            }

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Recipes> GetAllRecipes()
        {
            var recipes = _dbContext.Recipes.ToList();
            var result = _mapper.Map<List<Recipes>>(recipes);
            return result;
        }
    }
}
