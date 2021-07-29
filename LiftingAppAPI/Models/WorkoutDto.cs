using LiftingAppAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Models
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string WorkoutName { get; set; }
        public int UserId { get; set; }
        public virtual List<ExerciseDto> Exercises { get; set; }
    }
}
