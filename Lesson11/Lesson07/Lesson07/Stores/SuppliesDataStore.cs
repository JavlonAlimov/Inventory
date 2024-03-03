using Lesson07.Data;
using Lesson07.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Lesson07.Stores
{
    internal class SuppliesDataStore : IDisposable
    {
        private readonly InventoryDbContext _context;

        public SuppliesDataStore()
        {
            _context = new InventoryDbContext();
        }

        public async Task<List<Supply>> GetSupplies(int pageList, int currentPage, DateTime? search = null)
        {
            var query = _context.Supplies.AsQueryable();
            if (search is DateTime searchData)
            {
                var formatSearchData = searchData.ToString("M/d/yyyy");
                query = _context.Supplies
                    .Where(x => x.Date.Date == searchData.Date);
            }
            var supplies = await query.Skip((currentPage - 1) * pageList)
                .Take(pageList)
                .ToListAsync();

            return supplies;
        }

        public async Task<int> GetCountSupplesAsync()
        {
            int count = 0;
            try
            {
                count = await _context.Supplies.CountAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return count;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
