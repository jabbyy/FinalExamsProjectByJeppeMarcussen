namespace Svendeprøve_projekt_BodyFitBlazor.Models
{
    public class TrainingLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TrainingExerciseAddedToLog> ExerciseAddedToLog { get; set; }
        public int userId { get; set; }
        
    }
}
