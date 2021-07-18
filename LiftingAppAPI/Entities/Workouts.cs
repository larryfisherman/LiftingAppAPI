using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class Workouts
    {
        public int Id { get; set; }
        public string WorkoutName { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
