using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Entities
{
    public class Recipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proteins { get; set; }
        public string Carbo { get; set; }
        public string Fat { get; set; }
        public string Calories { get; set; }
        public string Type { get; set; }
        public string Recipe { get; set; }
    }
}
