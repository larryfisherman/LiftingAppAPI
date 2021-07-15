using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class Workouts
    {
        public string Id { get; set; }
        public string ExerciseName { get; set; }
        public string Amount { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
