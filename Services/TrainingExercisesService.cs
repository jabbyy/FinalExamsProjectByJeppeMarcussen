using Svendeprøve_projekt_BodyFitBlazor.Models;
using Svendeprøve_projekt_BodyFitBlazor.Repository;

namespace Svendeprøve_projekt_BodyFitBlazor.Services
{
    public class TrainingExercisesService
    {
        private readonly ITrainingExercisesRepository _trainingExercisesRepository;
        public TrainingExercisesService(ITrainingExercisesRepository trainingExercisesRepository)
        {
            _trainingExercisesRepository = trainingExercisesRepository;
        }
        public async Task<List<TrainingExercises>> GetAllTrainingExercises()
        {
            return await _trainingExercisesRepository.GetAllTrainingExercisesAsync();
        }
        public async Task<TrainingExercises> GetTrainingExerciseById(int id)
        {
            return await _trainingExercisesRepository.GetTrainingExerciseByIdAsync(id);
        }
        public async Task UpdateTrainingExercise(TrainingExercises trainingExercise)
        {
            await _trainingExercisesRepository.UpdateTrainingExerciseAsync(trainingExercise);
        }

        public async Task DeleteTrainingExercise(int id)
        {
            await _trainingExercisesRepository.DeleteTrainingExerciseAsync(id);
        }

        public async Task AddTrainingExercise(TrainingExercises trainingExercise)
        {
            await _trainingExercisesRepository.AddTrainingExerciseAsync(trainingExercise);
        }
    }
}
