using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Models;

namespace Svendeprøve_projekt_BodyFitBlazor.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<UserInfo> Users { get; set; }

        public DbSet<Categories> Categories { get; set; }

        //public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public DbSet<TrainingExercises> trainingExercises { get; set; }

        public DbSet<TrainingLog> trainingLog { get; set; }

        public DbSet<TrainingExerciseAddedToLog> trainingExerciseAddedToLogs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TrainingExercises>().Property(x => x.Description).HasMaxLength(160);

            /// Creating the 1 to many relationship between categories(1) and training exercises(many). 
            /// One category has many training exercises. One training exercise only has one category. 
            modelBuilder.Entity<TrainingExercises>().HasOne(c => c.Categories)
                .WithMany(c => c.Exercises)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<TrainingExerciseAddedToLog>().HasOne(t => t.TrainingExercises)
                .WithMany()
                .HasForeignKey(t => t.TrainingExerciseId);

            modelBuilder.Entity<TrainingExerciseAddedToLog>().HasOne(t => t.trainingLog)
                .WithMany()
                .HasForeignKey(t => t.TrainingLogId);

           



            /// Setting default value of th Visible propterty to false 
            modelBuilder.Entity<Categories>()
                .Property(b => b.Visible)
                .HasDefaultValue(false);
        }
    }
}

