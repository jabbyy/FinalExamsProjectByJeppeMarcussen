using System.ComponentModel.DataAnnotations;

namespace Svendeprøve_projekt_BodyFitBlazor.Models
{
    public class TrainingExerciseAddedToLog
    {
        [Key]
        public int Id { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public int weight { get; set; }

        // Navigation

        public TrainingExercises? TrainingExercises { get; set; }
        public int TrainingExerciseId { get; set; }
        public TrainingLog? trainingLog { get; set; }
        public int TrainingLogId { get; set; }
    }
}
