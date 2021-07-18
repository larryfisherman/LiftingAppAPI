using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class Exercises
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string Sets { get; set; }
        public string Amount { get; set; }
        public int WorkoutId { get; set; }
        public virtual Workouts Workouts { get; set; }
    }
}
