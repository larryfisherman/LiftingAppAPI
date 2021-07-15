using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Models
{
    public class CreateWorkoutDto
    {
        public string ExerciseName { get; set; }
        public string Amount { get; set; }
        public string UserId { get; set; }
    }
}
