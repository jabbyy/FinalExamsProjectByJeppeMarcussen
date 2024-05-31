using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Data;
using Svendeprøve_projekt_BodyFitBlazor.Models;

namespace Svendeprøve_projekt_BodyFitBlazor.Repository
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetCategoriesByIdAsync(int id);
        Task AddCategories(Categories category);
        Task DeleteCategoriesAsync(int id);
        Task UpdateCategoriesAsync(Categories category);
    }
    public class CategoriesRepo : ICategoriesRepository
    {
        private readonly DatabaseContext _context;
        public CategoriesRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddCategories(Categories category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoriesAsync(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories != null)
            {
                _context.Categories.Remove(categories);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Include(c => c.Exercises).ToListAsync();
        }

        public async Task<Categories> GetCategoriesByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateCategoriesAsync(Categories category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
