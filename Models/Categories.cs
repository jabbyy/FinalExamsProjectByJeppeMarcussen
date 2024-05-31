using System.ComponentModel.DataAnnotations;

namespace Svendeprøve_projekt_BodyFitBlazor.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public Boolean Visible { get; set; }

        public ICollection<TrainingExercises> Exercises { get; set; }
    }
}

