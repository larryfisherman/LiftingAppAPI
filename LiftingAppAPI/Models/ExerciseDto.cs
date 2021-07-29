using LiftingAppAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Models
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string Sets { get; set; }
        public string Amount { get; set; }
    }
}
