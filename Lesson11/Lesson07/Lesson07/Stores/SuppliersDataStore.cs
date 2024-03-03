using Lesson07.Data;
using Lesson07.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Lesson07.Stores
{
    internal class SuppliersDataStore : IDisposable
    {
        private readonly InventoryDbContext _context;

        public SuppliersDataStore()
        {
            _context = new InventoryDbContext();
        }

        public async Task<List<Supplier>> GetSupplierAsync(int pageSize, int currentPage, string? searchString = null)
        {
            var query = _context.Suppliers
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => (x.FirstName).Contains(searchString));
            }

            var supplier = await query.Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return supplier;
        }

        public async Task<int> GetSupplierCountAsync() => await _context.Suppliers.CountAsync();

        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {

            var createdCustomres = _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return createdCustomres.Entity;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);

            if (!EntityExists(supplier.Id))
            {
                throw new InvalidOperationException($"Product with id: {supplier.Id} does not exist");
            }
            _context.Suppliers.Attach(supplier);
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<int> DeleteSuppler(int id)
        {
            if (!EntityExists(id))
            {
                throw new InvalidOperationException($"Supplier with id: {id} does not exist");
            }
            var supplier = _context.Suppliers.First(x => x.Id == id);
            _context.Suppliers.Remove(supplier);
            return await _context.SaveChangesAsync();
        }

        private bool EntityExists(int id) => _context.Suppliers.Any(x => x.Id == id);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
