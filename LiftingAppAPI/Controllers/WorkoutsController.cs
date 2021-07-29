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
    [Route("api/account/{userId}/workout")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutsService _workoutsService;

        public WorkoutsController(IWorkoutsService workoutsService)
        {
            _workoutsService = workoutsService;
        
        }

        [HttpGet("{workoutId}")]
        public ActionResult<Workouts> Get([FromRoute] int userId, [FromRoute] int workoutId)
        {
            Workouts workout = _workoutsService.GetById(userId, workoutId);
            return Ok(workout);
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int userId, [FromBody]CreateWorkoutDto dto)
        {
            var newWorkoutId = _workoutsService.Create(userId, dto);
            return Created($"api/{userId}/workout/{newWorkoutId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkoutDto>> GetAll()
        {
            var workouts = _workoutsService.GetAll();
            return Ok(workouts);
        }
    }
}
