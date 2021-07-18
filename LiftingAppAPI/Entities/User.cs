using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string ProfilePhoto { get; set; }
        public virtual List<Workouts> Workouts { get; set; }
        
    }
}
