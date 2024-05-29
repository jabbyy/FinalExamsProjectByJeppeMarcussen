using System.ComponentModel.DataAnnotations;

namespace Svendeprøve_projekt_BodyFitBlazor.Models
{
    public class TrainingExercises
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        // Navigation
        public Categories Categories { get; set; }
    }
}
