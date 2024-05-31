using Svendeprøve_projekt_BodyFitBlazor.Models;
using Svendeprøve_projekt_BodyFitBlazor.Repository;

namespace Svendeprøve_projekt_BodyFitBlazor.Services
{
    public class ExerciseAddedToLogService
    {
        private readonly IExercisesAddedToLogRepo _exerciseAddedRepo;

        public ExerciseAddedToLogService(IExercisesAddedToLogRepo exercisesAddedToLogRepo)
        {
            _exerciseAddedRepo = exercisesAddedToLogRepo;
        }

        public async Task<List<TrainingExerciseAddedToLog>> GetAllExercisesAdded()
        {
            return await _exerciseAddedRepo.GetTrainingExerciseAddedToLog();
        }

        public async Task<TrainingExerciseAddedToLog> GetTrainingExerciseAddedById(int Id)
        {
            return await _exerciseAddedRepo.GetTrainingExerciseAddedToLogById(Id);
        }

        public async Task UpdateExerciseAdded(TrainingExerciseAddedToLog exerciseAddedToLog)
        {
            await _exerciseAddedRepo.UpdateExercisesAddedToLog(exerciseAddedToLog);
        }

        public async Task DeleteExerciseAdded(int Id)
        {
            await _exerciseAddedRepo.DeleteExerciseAddedToLog(Id);
        }

        public async Task CreateExerciseAdded(TrainingExerciseAddedToLog exerciseAddedToLog)
        {
            await _exerciseAddedRepo.CreateExerciseAddedToLog(exerciseAddedToLog);
        }

        public async Task<int> GetLatestTrainingLogId()
        {
            return await _exerciseAddedRepo.GetLatestTrainingLogId();
        }

    }
}
