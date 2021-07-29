using LiftingAppAPI.Entities;
using LiftingAppAPI.Models;
using LiftingAppAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Controllers
{
    [Route("api/account/{userId}/workout/{workoutId}/exercise")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        //[HttpGet("{exerciseId}")]
        //public ActionResult<Exercises> Get([FromRoute] int workoutId, [FromRoute] int exerciseId)
        //{
        //    Exercises exercise = _exerciseService.GetById(workoutId, exerciseId);
        //    return Ok(exercise);
        //}

        [HttpGet]
        public ActionResult<List<ExerciseDto>> Get([FromRoute] int workoutId)
        {
            var result = _exerciseService.GetAll(workoutId);
            return result;
        }

        [HttpPost]
        public ActionResult Post([FromRoute]int userId, [FromRoute] int workoutId, [FromBody]CreateExerciseDto dto)
        {
            var newExerciseId = _exerciseService.Create(workoutId, dto);
            return Created($"api/account/{userId}/workout/{workoutId}/exercise/{newExerciseId}", null);
        }


    }
}
