using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Services.Models
{
    public class CreateRecipeDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(4)]
        public string Proteins { get; set; }
        [Required]
        [MaxLength(4)]
        public string Carbo { get; set; }
        [Required]
        [MaxLength(4)]
        public string Fat { get; set; }
        [Required]
        [MaxLength(4)]
        public string Calories { get; set; }
        public string Type { get; set; }
        public string Recipe { get; set; }

    }
}
