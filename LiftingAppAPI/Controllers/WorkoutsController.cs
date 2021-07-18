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

        [HttpPost]
        public ActionResult Post([FromRoute] int userId, [FromBody]CreateWorkoutDto dto)
        {
            var newWorkoutId = _workoutsService.Create(userId, dto);
            return Created($"api/{userId}/workout/{newWorkoutId}", null);
        }
    }
}
