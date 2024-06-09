using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Data;
using Svendeprøve_projekt_BodyFitBlazor.Models;

namespace Svendeprøve_projekt_BodyFitBlazor.Repository
{
    public interface IExercisesAddedToLogRepo
    {
        Task<List<TrainingExerciseAddedToLog>> GetTrainingExerciseAddedToLog();
        Task<TrainingExerciseAddedToLog> GetTrainingExerciseAddedToLogById(int id);
        Task CreateExerciseAddedToLog(TrainingExerciseAddedToLog exerciseAddedToLog);
        Task DeleteExerciseAddedToLog(int id);
        Task UpdateExercisesAddedToLog(TrainingExerciseAddedToLog exerciseAddedToLog);
        Task<int> GetLatestTrainingLogId();
        Task<List<TrainingExerciseAddedToLog>> GetTrainingExerciseAddedToLogByTrainingLogId(int trainingLogId);
    }
    public class ExerciseAddedToLogRepo : IExercisesAddedToLogRepo
    {
        private readonly DatabaseContext _databaseContext;

        public ExerciseAddedToLogRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task CreateExerciseAddedToLog(TrainingExerciseAddedToLog exerciseAddedToLog)
        {
            _databaseContext.trainingExerciseAddedToLogs.Add(exerciseAddedToLog);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteExerciseAddedToLog(int id)
        {
            var ExerciseAdded = await _databaseContext.trainingExerciseAddedToLogs.FindAsync(id);
            if (ExerciseAdded != null)
            {
                _databaseContext.trainingExerciseAddedToLogs.Remove(ExerciseAdded);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetLatestTrainingLogId()
        {
            return await _databaseContext.trainingLog.OrderByDescending(t => t.Id).Select(t => t.Id).FirstOrDefaultAsync();
        }

        public async Task<List<TrainingExerciseAddedToLog>> GetTrainingExerciseAddedToLog()
        {
            return await _databaseContext.trainingExerciseAddedToLogs.ToListAsync();
        }

        public async Task<TrainingExerciseAddedToLog> GetTrainingExerciseAddedToLogById(int id)
        {
            return await _databaseContext.trainingExerciseAddedToLogs.Include(s => s.TrainingExercises).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateExercisesAddedToLog(TrainingExerciseAddedToLog exerciseAddedToLog)
        {
            _databaseContext.Entry(exerciseAddedToLog).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<List<TrainingExerciseAddedToLog>> GetTrainingExerciseAddedToLogByTrainingLogId(int trainingLogId)
        {
            return await _databaseContext.trainingExerciseAddedToLogs
                .Include(teal => teal.TrainingExercises) // Include the TrainingExercises
                .Where(teal => teal.TrainingLogId == trainingLogId) // Filter by TrainingLogId
                .ToListAsync();
        }

    }
}
