using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Models
{
    public class CreateWorkoutDto
    {
        public string WorkoutName { get; set; }
        public int UserId { get; set; }
    }
}
