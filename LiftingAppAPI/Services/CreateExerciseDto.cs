namespace LiftingAppAPI.Services
{
    public class CreateExerciseDto
    {
        public string ExerciseName { get; set; }
        public string Sets { get; set; }
        public string Amount { get; set; }
        public int WorkoutId { get; set; }
    }
}