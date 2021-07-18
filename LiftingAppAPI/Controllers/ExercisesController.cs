using LiftingAppAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Controllers
{
    [Route("api/account/{workoutId}/exercise")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int workoutId, [FromBody]CreateExerciseDto dto)
        {
            var newExerciseId = _exerciseService.Create(workoutId, dto);
            return Created($"api/{workoutId}/exercise/{newExerciseId}", null);
        } 
    }
}
