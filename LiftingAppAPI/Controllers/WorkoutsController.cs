using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Controllers
{
    [Route("api/{userId}/workout")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromRoute]int userId, CreateWorkoutDto dto)
        {

        }
    }
}
