using LiftingAppAPI.Entities;
using LiftingAppAPI.Services;
using LiftingAppAPI.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpPost]
        public ActionResult CreateRecipe([FromBody] CreateRecipeDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _recipesService.Create(dto);
            return Created($"/api/recipes/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipes>> GetAllRecipes()
        {
            var recipes = _recipesService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _recipesService.Delete(id);
            return Ok("Recipe removed");
        }

    }
}
