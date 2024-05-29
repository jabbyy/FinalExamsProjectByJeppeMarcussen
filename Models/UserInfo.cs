using System.ComponentModel.DataAnnotations;

namespace Svendeprøve_projekt_BodyFitBlazor.Models
{
    public class UserInfo
    {
        [Key] public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? City { get; set; }
        public int? Postal { get; set; }
        public int? Age { get; set; }


        /// Navigation
        //public ICollection<TrainingProgram> programs { get; set; }
        public ICollection<TrainingLog> log { get; set; }
    }
}
