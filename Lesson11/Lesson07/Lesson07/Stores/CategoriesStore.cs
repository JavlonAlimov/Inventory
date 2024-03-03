using Lesson07.Data;
using Lesson07.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson07.Stores
{
    internal class CategoriesStore
    {
        private readonly InventoryDbContext _context;
        public CategoriesStore()
        {
            _context = new InventoryDbContext();
        }
        public async Task<List<Category>> GetCategoriesAsync(int pageSize, int currentPage, string? searchString = null)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => (x.Name).Contains(searchString));
            }
            var categories = await query.Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
            => _context.Categories.FirstOrDefault(x => x.Id == id);
        
        
        public Category CreateCatigory(Category category)
        {
            var createdProduct = _context.Categories.Add(category);
            _context.SaveChanges();

            return createdProduct.Entity;
        }
        public void UpdateCatigory(Category category)
        {


            if (!EntityExists(category.Id))
            {
                throw new InvalidOperationException($"Category with id: {category.Id} does not exist");
            }

            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task<int> DeleteCategory(int id)
        {
            if (!EntityExists(id))
            {
                throw new InvalidOperationException($"Category with id: {id} does not exist");
            }
            var category = _context.Categories.First(x => x.Id == id);
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }
        private bool EntityExists(int id) => _context.Categories.Any(x => x.Id == id);
        public async Task<List<Category>> GetCategoriesAsync()
          => await _context.Categories.ToListAsync();
        public async Task<int> GetCustomersCountAsync() => await _context.Categories.CountAsync();
    }
}
