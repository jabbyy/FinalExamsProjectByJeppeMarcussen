using Svendeprøve_projekt_BodyFitBlazor.Models;
using Svendeprøve_projekt_BodyFitBlazor.Repository;

namespace Svendeprøve_projekt_BodyFitBlazor.Services
{
    public class CategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            return await _categoriesRepository.GetAllCategoriesAsync();
        }
        public async Task<Categories> GetCategoriesByIdAsync(int id)
        {
            return await _categoriesRepository.GetCategoriesByIdAsync(id);
        }
        public async Task UpdateCategoriesAsync(Categories categories)
        {
            await _categoriesRepository.UpdateCategoriesAsync(categories);
        }

        public async Task DeleteCategoriesAsync(int id)
        {
            await _categoriesRepository.DeleteCategoriesAsync(id);
        }

        public async Task AddCategory(Categories category)
        {
            await _categoriesRepository.AddCategories(category);
        }
    }
}
