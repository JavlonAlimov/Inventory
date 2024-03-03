using Lesson07.Data;
using Lesson07.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson07.Stores
{
    internal class ProductsDataStore : IDisposable
    {
        private readonly InventoryDbContext _context;

        public ProductsDataStore()
        {
            _context = new InventoryDbContext();
        }

        public async Task<List<Product>> GetProductsAsync(int pageSize, int currentPage, string? searchString = null, int? categoryId = null)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .AsQueryable(); 

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
            }

            if (categoryId is not null and > 0)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }

            var products = await query.Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products;
        }

        public async Task<int> GetProductsCountAsync() => await _context.Products.CountAsync();

        public Product? GetProductById(int id) 
            => _context.Products.FirstOrDefault(x => x.Id == id);

        public Product CreateProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            var createdProduct = _context.Products.Add(product);
            _context.SaveChanges();

            return createdProduct.Entity;
        }

        public void UpdateProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (!EntityExists(product.Id))
            {
                throw new InvalidOperationException($"Product with id: {product.Id} does not exist");
            }

            _context.Products.Attach(product);
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (!EntityExists(id))
            {
                throw new InvalidOperationException($"Product with id: {id} does not exist");
            }

            var product = _context.Products.First(x => x.Id == id);
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        private bool EntityExists(int id) => _context.Products.Any(x => x.Id == id);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
