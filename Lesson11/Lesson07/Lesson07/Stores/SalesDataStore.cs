﻿using Lesson07.Data;
using Lesson07.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows;

namespace Lesson07.Stores
{
    internal class SalesDataStore : IDisposable
    {
        private readonly InventoryDbContext _context;

        public SalesDataStore()
        {
            _context = new InventoryDbContext();
        }

        public async Task<List<Sale>> GetSales(int pageList, int currentPage, DateTime? search = null, int? customerID = null)
        {
            var query = _context.Sales.AsQueryable();
            if (search is DateTime searchData)
            {
                var formatSearchData = searchData.ToString("M/d/yyyy");
                query = _context.Sales
                    .Where(x => x.SaleDate.Date == searchData.Date);
            }
            var sales = await query.Skip((currentPage - 1) * pageList)
                .Take(pageList)
                .ToListAsync();

            return sales;
        }

        public async Task<int> GetCountSalesAsync()
        {
            int count = 0;
            try
            {
                count = await _context.Sales.CountAsync();
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