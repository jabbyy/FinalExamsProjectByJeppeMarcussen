using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Data;
using Svendeprøve_projekt_BodyFitBlazor.Models;

namespace Svendeprøve_projekt_BodyFitBlazor.Repository
{
    public interface ITrainingExercisesRepository
    {
        Task<List<TrainingExercises>> GetAllTrainingExercisesAsync();
        Task<TrainingExercises> GetTrainingExerciseByIdAsync(int id);
        Task AddTrainingExerciseAsync(TrainingExercises trainingExercise);
        Task UpdateTrainingExerciseAsync(TrainingExercises trainingExercise);
        Task DeleteTrainingExerciseAsync(int id);
    }

    public class TrainingExercisesRepo : ITrainingExercisesRepository
    {
        private readonly DatabaseContext _context;

        public TrainingExercisesRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<TrainingExercises>> GetAllTrainingExercisesAsync()
        {
            return await _context.trainingExercises.ToListAsync();
        }

        public async Task<TrainingExercises> GetTrainingExerciseByIdAsync(int id)
        {
            return await _context.trainingExercises.FindAsync(id);
        }

        public async Task AddTrainingExerciseAsync(TrainingExercises trainingExercises)
        {
            _context.trainingExercises.Add(trainingExercises);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTrainingExerciseAsync(TrainingExercises trainingExercise)
        {
            _context.Entry(trainingExercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTrainingExerciseAsync(int id)
        {
            var trainingExercise = await _context.trainingExercises.FindAsync(id);
            if (trainingExercise != null)
            {
                _context.trainingExercises.Remove(trainingExercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
