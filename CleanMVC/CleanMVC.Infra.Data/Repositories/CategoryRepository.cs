using CleanMVC.Domain.Entities;
using CleanMVC.Domain.Interfaces;
using CleanMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanMVC.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            //return await _categoryContext.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id)) ?? new Category();
            return await _categoryContext.Categories.FirstAsync(c => c.Id == id);   
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
