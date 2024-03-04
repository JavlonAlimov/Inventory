using Lesson07.Stores;
using Lesson07.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07.ViewModels
{
    public class DashboardViewModal : BaseViewModel
    {
        public ObservableCollection<LineChartModel> DataPoints { get; private set; }
        public ObservableCollection<SalesByCategoryModel> CategoryDataPoints { get; private set; }
        private readonly SalesDataStore salesDataStore;
        private readonly SuppliesDataStore suppliesDataStore;
        private decimal _totalSales;
        public decimal TotalSales
        {
            get => _totalSales;
            set => SetProperty(ref _totalSales, value);
        }

        private decimal _totalSupplies;
        public decimal TotalSupplies
        {
            get => _totalSupplies;
            set => SetProperty(ref _totalSupplies, value);
        }
        public int LowStockProducts { get; set; } = 12;

        public DashboardViewModal()
        {
            suppliesDataStore = new SuppliesDataStore();
            salesDataStore = new SalesDataStore();
        }

        public async Task LoadData()
        {
            TotalSupplies = await suppliesDataStore.GetCountSupplesAsync();
            TotalSales = await salesDataStore.GetCountSalesAsync();
            DataPoints = new ObservableCollection<LineChartModel>();
            CategoryDataPoints = new ObservableCollection<SalesByCategoryModel>();
            DateTime year = new DateTime(2020, 1, 1);

            DataPoints.Add(new LineChartModel { Year = year.AddYears(1), Sales = 20, Supplies = 30 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(2), Sales = 35, Supplies = 80 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(3), Sales = 40, Supplies = 23 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(4), Sales = 65, Supplies = 30 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(5), Sales = 76, Supplies = 62 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(6), Sales = 22, Supplies = 45 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(7), Sales = 29, Supplies = 15 });
            DataPoints.Add(new LineChartModel { Year = year.AddYears(8), Sales = 40, Supplies = 32 });

            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 1", Percentage = 20 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 2", Percentage = 10 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 3", Percentage = 10 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 4", Percentage = 15 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 5", Percentage = 15 });
            CategoryDataPoints.Add(new SalesByCategoryModel { Category = "Category 6", Percentage = 30 });
        }
    }
    public class LineChartModel
    {
        public DateTime Year { get; set; }
        public double Supplies { get; set; }
        public double Sales { get; set; }
    }

    public class SalesByCategoryModel
    {
        public string Category { get; set; }
        public double Percentage { get; set; }
    }
}
