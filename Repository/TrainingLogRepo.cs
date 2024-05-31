using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Data;
using Svendeprøve_projekt_BodyFitBlazor.Models;

namespace Svendeprøve_projekt_BodyFitBlazor.Repository
{
    public interface ITrainingLogRepo
    {
        Task<List<TrainingLog>> GetTrainingLogs(int Id);
        Task<TrainingLog> GetTrainingLogById(int id);
        Task CreateTrainingLog(TrainingLog trainingLog);
        Task<TrainingLog> DeleteTrainingLog(int id);
        Task UpdateTrainingLog(TrainingLog trainingLog);
        Task<TrainingLog> GetTrainingLogByDate(DateTime date, int userId);
    }

    public class TrainingLogRepo : ITrainingLogRepo
    {
        private readonly DatabaseContext _databaseContext;

        public TrainingLogRepo(DatabaseContext context)
        {
            _databaseContext = context;
        }


        public async Task CreateTrainingLog(TrainingLog trainingLog)
        {
            _databaseContext.trainingLog.Add(trainingLog);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<TrainingLog> DeleteTrainingLog(int id)
        {
            var item = _databaseContext.trainingLog.Find(id);
            if (item != null)
            {
                _databaseContext.trainingLog.Remove(item);
                await _databaseContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<TrainingLog> GetTrainingLogByDate(DateTime date, int userId)
        {
            return await _databaseContext.trainingLog.FirstOrDefaultAsync(log => log.Date.Date == date.Date && log.userId == userId);
        }

        public async Task<TrainingLog> GetTrainingLogById(int id)
        {
            return await _databaseContext.trainingLog.FindAsync(id);
        }

        public async Task<List<TrainingLog>> GetTrainingLogs(int Id)
        {
            List<TrainingLog> trainingLogs = await _databaseContext
                .trainingLog.Include(I => I.ExerciseAddedToLog)
                .ThenInclude(TI => TI.TrainingExercises)
                .Where(c => c.userId == Id).ToListAsync();
            return trainingLogs;
        }

        public async Task UpdateTrainingLog(TrainingLog trainingLog)
        {
            _databaseContext.Entry(trainingLog).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();

        }
    }
}
