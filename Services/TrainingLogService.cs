using Svendeprøve_projekt_BodyFitBlazor.Models;
using Svendeprøve_projekt_BodyFitBlazor.Repository;

namespace Svendeprøve_projekt_BodyFitBlazor.Services
{
    public class TrainingLogService
    {
        private readonly ITrainingLogRepo _trainingLogRepo;

        public TrainingLogService(ITrainingLogRepo trainingLogRepo)
        {
            _trainingLogRepo = trainingLogRepo;
        }

        public async Task<List<TrainingLog>> GetAllTrainingLogs(int Id)
        {
            return await _trainingLogRepo.GetTrainingLogs(Id);
        }

        public async Task<TrainingLog> GetTrainingLogById(int Id)
        {
            return await _trainingLogRepo.GetTrainingLogById(Id);
        }

        public async Task UpdateTrainingLog(TrainingLog trainingLog)
        {
            await _trainingLogRepo.UpdateTrainingLog(trainingLog);
        }

        public async Task DeleteTrainingLog(int Id)
        {
            await _trainingLogRepo.DeleteTrainingLog(Id);
        }

        public async Task CreateTrainingLog(TrainingLog trainingLog)
        {
            await _trainingLogRepo.CreateTrainingLog(trainingLog);
        }
        public async Task<bool> CompareLogDateToToday(int userId, DateTime logDate)
        {
            TrainingLog trainingLog = await _trainingLogRepo.GetTrainingLogByDate(logDate, userId);

            if (trainingLog != null)
            {
                // Compare the log date with today's date
                DateTime today = DateTime.Today;
                if (trainingLog.Date.Date == today)
                {
                    return true; // Log date is today's date
                }
            }

            return false; // Log date is not today's date or not found
        }

        public async Task<List<int>> GetAllTrainingLogIds()
        {
            return await _trainingLogRepo.GetAllTrainingLogIds();
        }


    }
}
